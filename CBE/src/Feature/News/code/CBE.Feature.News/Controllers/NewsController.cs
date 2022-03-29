namespace CBE.Feature.News.Controllers
{
    using System.Web.Mvc;
    using CBE.Feature.News.Models;
    using CBE.Feature.News.Repositories;
    using CBE.Foundation.SiteExtensions.Extensions;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;
    using Sitecore.SecurityModel;

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

        [HttpPost]
        public void CreateItem(Article article)
        {
            using (new SecurityDisabler())
            {
                Database masterDb =
                Sitecore.Configuration.Factory.GetDatabase("master");
                Item parentItem = masterDb.Items["/sitecore/content/CBE/home"];
                TemplateItem template = masterDb.GetTemplate(Templates.Article.ID);
                Item newItem = parentItem.Add("NewItemNamemplate", template);
                try
                {
                    if (newItem != null)
                    {
                        newItem.Editing.BeginEdit();
                        newItem[Templates.Article.Fields.Title] = article.Title;
                        newItem[Templates.Article.Fields.Body] = article.Body;
                        newItem[Templates.Article.Fields.Summary] = article.Summary;
                        newItem.Editing.EndEdit();

                        var x = HttpContext.Request.Files;
                    }
                }
                catch
                {
                    newItem.Editing.CancelEdit();
                }
            }
        }
    }
}