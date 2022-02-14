namespace CBE.Feature.Search.Repositories
{
    using CBE.Feature.Search.Models;

    public interface ISearchContextRepository
    {
        SearchContext Get();
    }
}