namespace CBE.Feature.Search.Infrastructure.Providers
{
    using System.Collections.Generic;
    using System.Configuration.Provider;
    using CBE.Feature.Search.Repositories;
    using CBE.Foundation.DependencyInjection;
    using CBE.Foundation.Indexing.Models;

    [Service]
    public class DefaultFacetProvider : ProviderBase, IQueryFacetProvider
    {
        public DefaultFacetProvider(ISearchContextRepository searchContextRepository)
        {
            this.SearchContextRepository = searchContextRepository;
        }

        public IEnumerable<IQueryFacet> GetFacets()
        {
            var context = this.SearchContextRepository.Get();
            return context.Facets;
        }

        public ISearchContextRepository SearchContextRepository { get; }
    }
}