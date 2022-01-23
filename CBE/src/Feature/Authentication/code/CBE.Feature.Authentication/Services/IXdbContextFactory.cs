using Sitecore.XConnect;

namespace CBE.Feature.Authentication.Services
{
    public interface IXdbContextFactory
    {
        IXdbContext CreateContext();
    }
}
