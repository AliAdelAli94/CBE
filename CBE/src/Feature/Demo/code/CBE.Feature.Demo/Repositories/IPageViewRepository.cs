namespace CBE.Feature.Demo.Repositories
{
    using Sitecore.Analytics.Tracking;
    using CBE.Feature.Demo.Models;

    public interface IPageViewRepository
    {
        PageView Get(ICurrentPageContext pageContext);
    }
}