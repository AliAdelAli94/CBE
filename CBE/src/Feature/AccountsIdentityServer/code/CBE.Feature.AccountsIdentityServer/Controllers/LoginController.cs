using Microsoft.Extensions.DependencyInjection;
using Sitecore.Abstractions;
using Sitecore.DependencyInjection;
using Sitecore.Pipelines.GetSignInUrlInfo;
using System.Web.Mvc;

namespace CBE.Feature.AccountsIdentityServer.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult LoginProviderList()
        {
            var corePipelineManager = ServiceLocator.ServiceProvider.GetService<BaseCorePipelineManager>();
            var args = new GetSignInUrlInfoArgs("website", "/Home");

            GetSignInUrlInfoPipeline.Run(corePipelineManager, args);

            return View("~/Views/AccountsIdentityServer/LoginProviderList.cshtml", args.Result);
        }
    }
}