namespace CBE.Feature.Teasers.Controller
{
  using System.Web.Mvc;
  using CBE.Feature.Teasers.Models;
  using CBE.Foundation.Alerts;
  using CBE.Foundation.Alerts.Extensions;
  using CBE.Foundation.Alerts.Models;
  using CBE.Foundation.SiteExtensions.Extensions;
    using Sitecore;
    using Sitecore.Mvc.Presentation;

  public class TeasersController : Controller
  {
    public ActionResult GetDynamicContent(string viewName)
    {
      var dataSourceItem = RenderingContext.Current.Rendering.Item;
      if (!dataSourceItem?.DescendsFrom(Templates.DynamicTeaser.ID) ?? true)
      {
        return Context.PageMode.IsExperienceEditor ? this.InfoMessage(new InfoMessage(AlertTexts.InvalidDataSourceTemplateFriendlyMessage, InfoMessage.MessageType.Error)) : null;
      }

      var model = new DynamicTeaserModel(dataSourceItem);
      return this.View(viewName, model);
    }

    public ActionResult Accordion() => this.GetDynamicContent("Accordion");

    public ActionResult Tabs() => this.GetDynamicContent("Tabs");

    public ActionResult TeaserCarousel() => this.GetDynamicContent("TeaserCarousel");

    public ActionResult JumbotronCarousel() => this.GetDynamicContent("JumbotronCarousel");
  }
}