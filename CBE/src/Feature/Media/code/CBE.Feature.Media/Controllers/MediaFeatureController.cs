namespace CBE.Feature.Media.Controllers
{
  using System.Web.Mvc;
  using CBE.Feature.Media.Models;
  using CBE.Foundation.SiteExtensions.Repositories;
  using Sitecore.Mvc.Presentation;

    //Should be MediaController but this clashes with Sitecore.Controllers.MediaController
  public class MediaFeatureController : Controller
  {
    public ActionResult SectionMedia()
    {
      var renderingPropertiesRepository = new RenderingPropertiesRepository();
      var mediamBackgroundModel = renderingPropertiesRepository.Get<MediaBackgroundRenderingModel>(RenderingContext.Current.Rendering);

      return this.View(mediamBackgroundModel);
    }

    public ActionResult PageHeaderMedia()
    {
      var renderingPropertiesRepository = new RenderingPropertiesRepository();
      var mediamBackgroundModel = renderingPropertiesRepository.Get<MediaBackgroundRenderingModel>(RenderingContext.Current.Rendering);

      return this.View(mediamBackgroundModel);
    }
  }
}