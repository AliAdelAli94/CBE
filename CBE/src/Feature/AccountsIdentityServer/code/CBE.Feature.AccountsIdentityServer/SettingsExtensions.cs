using Sitecore.Abstractions;
using Sitecore.Diagnostics;

namespace CBE.Feature.AccountsIdentityServer
{
    public static class SettingsExtensions
    {
        public static Is4Settings GetIs4Settings(this BaseSettings settings)
        {
            Assert.ArgumentNotNull(settings, "settings");
            return new Is4Settings(settings);
        }
    }
}