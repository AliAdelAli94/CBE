using Sitecore.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBE.Feature.AccountsIdentityServer
{
    public class Is4Settings
    {
        private readonly BaseSettings _settings;
        private readonly string _prefix = "cbev2.Auth.Is4.";

        public virtual string ClientId => _settings.GetSetting($"{_prefix}ClientId");
        public virtual string Authority => _settings.GetSetting($"{_prefix}Authority");
        public virtual string RedirectUri => _settings.GetSetting($"{_prefix}RedirectUri");
        public virtual string PostLogoutRedirectUri => _settings.GetSetting($"{_prefix}PostLogoutRedirectUri");

        public Is4Settings(BaseSettings baseSettings)
        {
            _settings = baseSettings;
        }
    }
}