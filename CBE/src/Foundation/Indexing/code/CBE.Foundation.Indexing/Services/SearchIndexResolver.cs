namespace CBE.Foundation.Indexing.Services
{
    using Sitecore.ContentSearch;
    using CBE.Foundation.DependencyInjection;

    [Service]
    public class SearchIndexResolver
    {
        public virtual ISearchIndex GetIndex(SitecoreIndexableItem contextItem)
        {
            return ContentSearchManager.GetIndex(contextItem);
        }
    }
}