namespace CBE.Feature.Person.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Sitecore.Data.Items;
    using CBE.Foundation.DependencyInjection;
    using CBE.Foundation.Indexing.Models;
    using CBE.Foundation.Indexing.Repositories;

    [Service]
    public class PersonRepository
    {
        public PersonRepository(ISearchServiceRepository searchServiceRepository)
        {
            this.SearchServiceRepository = searchServiceRepository;
        }

        public IEnumerable<Item> Get(Item contextItem)
        {
            var searchService = this.SearchServiceRepository.Get(new SearchSettingsBase { Templates = new[] { Templates.Person.ID } });
            searchService.Settings.Root = contextItem;
            return searchService.FindAll().Results.Select(x => x.Item).Where(x => x != null);
        }

        public ISearchServiceRepository SearchServiceRepository { get; }
    }
}