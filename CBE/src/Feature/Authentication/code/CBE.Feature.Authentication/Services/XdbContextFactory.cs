using Sitecore.XConnect;
using Sitecore.XConnect.Client.Configuration;

namespace CBE.Feature.Authentication.Services
{
    public class XdbContextFactory : IXdbContextFactory
    {
        public IXdbContext CreateContext()
        {
            return SitecoreXConnectClientConfiguration.GetClient();
        }
    }
}