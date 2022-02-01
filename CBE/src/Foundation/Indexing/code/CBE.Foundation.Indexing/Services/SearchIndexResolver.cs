namespace CBE.Foundation.Indexing.Services
{
    using Sitecore.ContentSearch;

    public class SearchIndexResolver
    {
        public virtual ISearchIndex GetIndex(SitecoreIndexableItem contextItem)
        {
            return ContentSearchManager.GetIndex(contextItem);
        }
    }
}