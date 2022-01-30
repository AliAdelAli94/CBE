namespace CBE.Feature.Accounts.Attributes
{
    using System.Web.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Sitecore.DependencyInjection;
    using CBE.Feature.Accounts.Services;
    using Sitecore;

    public class RedirectAuthenticatedAttribute : ActionFilterAttribute
    {
        private readonly IGetRedirectUrlService getRedirectUrlService;

        public RedirectAuthenticatedAttribute() : this(ServiceLocator.ServiceProvider.GetService<IGetRedirectUrlService>())
        {
        }

        public RedirectAuthenticatedAttribute(IGetRedirectUrlService getRedirectUrlService)
        {
            this.getRedirectUrlService = getRedirectUrlService;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!Context.PageMode.IsNormal)
                return;
            if (!Context.User.IsAuthenticated)
                return;
            var link = this.getRedirectUrlService.GetRedirectUrl(AuthenticationStatus.Authenticated);
            filterContext.Result = new RedirectResult(link);
        }
    }
}