namespace CBE.Feature.Accounts.Services
{
    using Sitecore.XConnect;

    public interface IXdbContextFactory
    {
        IXdbContext CreateContext();
    }
}
