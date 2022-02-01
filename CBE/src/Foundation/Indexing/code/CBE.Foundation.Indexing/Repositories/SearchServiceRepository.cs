namespace CBE.Foundation.Indexing.Repositories
{
    using CBE.Foundation.Indexing.Models;
    using CBE.Foundation.Indexing.Services;

    public class SearchServiceRepository : ISearchServiceRepository
    {
        public virtual SearchService Get(ISearchSettings settings)
        {
            return new SearchService(settings);
        }
    }
}