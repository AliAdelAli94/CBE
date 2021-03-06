namespace CBE.Feature.Demo.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Sitecore.Analytics;
    using Sitecore.Analytics.Model;
    using Sitecore.Analytics.Tracking;
    using Sitecore.Common;
    using Sitecore.Data;
    using CBE.Feature.Demo.Models;
    using CBE.Foundation.DependencyInjection;
    using CBE.Foundation.Dictionary.Repositories;
    using Sitecore.Marketing.Definitions;
    using Sitecore.Marketing.Definitions.Goals;
    using Sitecore.Marketing.Definitions.PageEvents;
    using Sitecore.Marketing.Definitions.PageEvents.Data;
    using Sitecore;

    [Service]
    public class PageEventRepository
    {
        private readonly IDefinitionManager<IPageEventDefinition> pageEventDefinitionManager;

        public PageEventRepository(IDefinitionManager<IPageEventDefinition> pageEventDefinitionManager)
        {
            this.pageEventDefinitionManager = pageEventDefinitionManager;
        }

        public IEnumerable<PageEvent> GetGoals()
        {
            var current = this.GetCurrentGoals();
            var historic = this.GetHistoricGoals();

            return current.Union(historic);
        }

        public IEnumerable<PageEvent> GetPageEvents()
        {
            return this.GetCurrentPageEvents();
        }

        private IEnumerable<PageEvent> GetHistoricGoals()
        {
            var keyBehaviourCache = Tracker.Current.Contact.KeyBehaviorCache;
            foreach (var cachedGoal in keyBehaviourCache.Goals)
            {
                var goal = GetGoalDefinition(cachedGoal.Id);

                yield return new PageEvent
                             {
                                 Title = goal?.Name ?? DictionaryPhraseRepository.Current.Get("/Demo/Goals/Unknown Goal", "(Unknown)"),
                                 Date = cachedGoal.DateTime,
                                 EngagementValue = goal?.EngagementValuePoints ?? 0,
                                 IsCurrentVisit = false,
                                 Data = cachedGoal.Data
                             };
            }
        }

        private IPageEventDefinition GetGoalDefinition(Guid goalId)
        {
            return pageEventDefinitionManager.Get(goalId, Context.Language.CultureInfo) ?? pageEventDefinitionManager.Get(goalId, CultureInfo.InvariantCulture);
        }

        private IEnumerable<PageEvent> GetCurrentGoals()
        {
            return Tracker.Current.Interaction.GetPages().SelectMany(page => page.PageEvents.Where(pe => pe.IsGoal)).Reverse().Select(this.Create);
        }

        private IEnumerable<PageEvent> GetCurrentPageEvents()
        {
            return Tracker.Current.Interaction.GetPages().SelectMany(page => page.PageEvents.Where(pe => !pe.IsGoal)).Reverse().Select(this.Create);
        }

        private PageEvent Create(PageEventData pageEventData)
        {
            return new PageEvent
                   {
                       IsCurrentVisit = true,
                       Date = pageEventData.DateTime,
                       EngagementValue = pageEventData.Value,
                       Title = pageEventData.Name,
                       Data = pageEventData.Text
                   };
        }

        public IEnumerable<PageEvent> GetLatest()
        {
            return this.GetGoals().Take(10);
        }
    }
}