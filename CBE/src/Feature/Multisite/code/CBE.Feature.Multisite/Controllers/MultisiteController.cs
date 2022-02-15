namespace CBE.Feature.Multisite.Controllers
{
  using System.Web.Mvc;
  using CBE.Feature.Multisite.Repositories;

  public class MultisiteController : Controller
  {
    private readonly ISiteConfigurationRepository multisiteRepository;

    public MultisiteController(ISiteConfigurationRepository multisiteRepository)
    {
      this.multisiteRepository = multisiteRepository;
    }

    public ActionResult SwitchSite()
    {
      var definitions = this.multisiteRepository.Get();
      return this.View(definitions);
    }
  }
}