namespace CBE.Foundation.Indexing.Repositories
{
    using CBE.Foundation.DependencyInjection;
    using CBE.Foundation.Indexing.Models;
    using CBE.Foundation.Indexing.Services;

    [Service(typeof(ISearchServiceRepository))]
    public class SearchServiceRepository : ISearchServiceRepository
    {
        public virtual SearchService Get(ISearchSettings settings)
        {
            return new SearchService(settings);
        }
    }
}