namespace CBE.Foundation.Indexing.Repositories
{
    using CBE.Foundation.Indexing.Models;
    using CBE.Foundation.Indexing.Services;

    public interface ISearchServiceRepository
    {
        SearchService Get(ISearchSettings searchSettings);
    }
}