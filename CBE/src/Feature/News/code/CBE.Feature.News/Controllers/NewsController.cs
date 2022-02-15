namespace CBE.Feature.News.Controllers
{
    using System.Web.Mvc;
    using CBE.Feature.News.Repositories;
    using CBE.Foundation.SiteExtensions.Extensions;
    using Sitecore.Mvc.Presentation;

    public class NewsController : Controller
    {
        public NewsController(INewsRepository newsRepository)
        {
            this.Repository = newsRepository;
        }

        private INewsRepository Repository { get; }

        public ActionResult NewsList()
        {
            var items = this.Repository.Get(RenderingContext.Current.Rendering.Item);
            return this.View("NewsList", items);
        }

        public ActionResult LatestNews()
        {
            //TODO: change to parameter template
            var count = RenderingContext.Current.Rendering.GetIntegerParameter("count", 5);
            var items = this.Repository.GetLatest(RenderingContext.Current.Rendering.Item, count);
            return this.View("LatestNews", items);
        }
    }
}