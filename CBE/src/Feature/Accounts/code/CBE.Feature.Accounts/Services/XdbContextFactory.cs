namespace CBE.Feature.Accounts.Services
{

    using Sitecore.XConnect;
    using Sitecore.XConnect.Client.Configuration;

    public class XdbContextFactory : IXdbContextFactory
    {
        public IXdbContext CreateContext()
        {
            return SitecoreXConnectClientConfiguration.GetClient();
        }
    }
}