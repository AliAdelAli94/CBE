using System;
using System.Collections.Generic;
using System.Linq;
using CBE.Feature.Maps.Models;
using CBE.Foundation.DependencyInjection;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace CBE.Feature.Maps.Repositories
{
    [Service(typeof(IMapPointRepository))]
    public class MapPointRepository : IMapPointRepository
    {
        private readonly Foundation.Indexing.Repositories.ISearchServiceRepository searchServiceRepository;

        public MapPointRepository(Foundation.Indexing.Repositories.ISearchServiceRepository searchServiceRepository)
        {
            this.searchServiceRepository = searchServiceRepository;
        }

        public IEnumerable<MapPoint> GetAll(Item contextItem)
        {
            if (contextItem == null)
            {
                throw new ArgumentNullException(nameof(contextItem));
            }
            if (contextItem.DescendsFrom(Templates.MapPoint.ID))
            {
                return new List<MapPoint>
                {
                    new MapPoint(contextItem)
                };
            }
            if (!contextItem.DescendsFrom(Templates.MapPointsFolder.ID))
            {
                throw new ArgumentException("Item must derive from MapPointsFolder or MapPoint", nameof(contextItem));
            }

            var searchService = this.searchServiceRepository.Get(new Foundation.Indexing.Models.SearchSettingsBase { Templates = new[] { Templates.MapPoint.ID } });
            searchService.Settings.Root = contextItem;

            return searchService.FindAll().Results.Select(x => new MapPoint(x.Item));
        }
    }
}