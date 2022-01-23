using Sitecore.Mvc.Controllers;
using System.Web;

namespace CBE.Feature.Authentication.Controllers
{
    public class BaseController : SitecoreController
    {
        private HttpSessionStateBase _session;
        protected HttpSessionStateBase CrossControllerSession
        {
            get
            {
                if (_session == null) _session = Session;
                return _session;
            }
            set
            {
                _session = Session;
            }
        }
        public bool IsMobile()
        {
            if (Sitecore.Context.ClientData.GetValue("IsMobile") != null && Sitecore.Context.ClientData.GetValue("IsMobile").ToString() == "true") return true;
            return false;
        }
    }
}