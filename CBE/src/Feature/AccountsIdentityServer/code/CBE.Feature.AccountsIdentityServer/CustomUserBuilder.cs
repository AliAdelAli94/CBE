using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.Diagnostics;
using Sitecore.Owin.Authentication.Identity;
using Sitecore.Owin.Authentication.Services;
using Sitecore.SecurityModel.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBE.Feature.AccountsIdentityServer
{
    public class CustomUserBuilder : DefaultExternalUserBuilder
    {
        public CustomUserBuilder(bool isPersistentUser) :
            base(ServiceLocator.ServiceProvider.GetService<ApplicationUserFactory>(),
                 ServiceLocator.ServiceProvider.GetService<IHashEncryption>())
        {
            IsPersistentUser = isPersistentUser;
        }

        public CustomUserBuilder(string isPersistentUser) :
            this(bool.Parse(isPersistentUser))
        { }

        protected override string CreateUniqueUserName(UserManager<ApplicationUser> userManager, ExternalLoginInfo externalLoginInfo)
        {
            Assert.ArgumentNotNull(userManager, "userManager");
            Assert.ArgumentNotNull(externalLoginInfo, "externalLoginInfo");

            var identityProvider =
                FederatedAuthenticationConfiguration.GetIdentityProvider(externalLoginInfo.ExternalIdentity);

            if (identityProvider == null)
            {
                throw new InvalidOperationException("Unable to retrieve identity provider");
            }

            return $"{identityProvider.Domain}\\{externalLoginInfo.Email}";
        }
    }
}