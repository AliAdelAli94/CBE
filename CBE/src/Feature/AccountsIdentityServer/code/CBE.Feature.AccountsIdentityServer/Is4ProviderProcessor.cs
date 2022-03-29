using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using Sitecore.Abstractions;
using Sitecore.Diagnostics;
using Sitecore.Owin.Authentication.Configuration;
using Sitecore.Owin.Authentication.Extensions;
using Sitecore.Owin.Authentication.Pipelines.IdentityProviders;
using Sitecore.Owin.Authentication.Services;
using System;
using System.Collections.ObjectModel;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CBE.Feature.AccountsIdentityServer
{
    public class Is4ProviderProcessor : IdentityProvidersProcessor
    {
        protected override string IdentityProviderName => "IS4";

        //List of scopes requested from IdentityServer4
        public Collection<string> Scopes { get; } = new Collection<string>();

        public Is4ProviderProcessor(
                FederatedAuthenticationConfiguration federatedAuthenticationConfiguration,
                ICookieManager cookieManager,
                BaseSettings baseSettings) :
            base(federatedAuthenticationConfiguration, cookieManager, baseSettings)
        { }

        protected override void ProcessCore(IdentityProvidersArgs args)
        {

            Assert.ArgumentNotNull(args, "args");

            var identityProvider = GetIdentityProvider();

            //Using our extension to read our custom settings
            var is4Settings = Settings.GetIs4Settings();

            var openIdConnectAuthOptions = new OpenIdConnectAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Passive,
                AuthenticationType = identityProvider.Name,
                Authority = is4Settings.Authority, //Value from settings
                Caption = identityProvider.Caption,
                ClientId = is4Settings.ClientId, //Value from settings
                CookieManager = CookieManager,
                PostLogoutRedirectUri = is4Settings.PostLogoutRedirectUri, //Value from settings
                RedirectUri = is4Settings.RedirectUri, //Value from settings
                ResponseType = "id_token", //We are using Implicit grant in IdentityServer4, so this must be "id_token"
                Scope = string.Join(" ", Scopes),
                RequireHttpsMetadata = false,
                UseTokenLifetime = false,
                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    SecurityTokenValidated = message =>
                    {
                        var identity = message.AuthenticationTicket.Identity;

                        //This is based from a solution by Sean Sartell to allow Sitecore to correctly log out
                        identity.AddClaim(new Claim("id_token", message.ProtocolMessage.IdToken));

                        //Apply claim transformations
                        message.AuthenticationTicket.Identity.ApplyClaimsTransformations(
                            new TransformationContext(FederatedAuthenticationConfiguration, identityProvider)
                        );

                        message.AuthenticationTicket = new AuthenticationTicket(identity, message.AuthenticationTicket.Properties);

                        return Task.CompletedTask;
                    },
                    RedirectToIdentityProvider = message =>
                    {
                        //The following code is based from Sean Sartell solution for correct Sitecore logout redirection
                        var revokeProperties = message.OwinContext.Authentication.AuthenticationResponseRevoke?.Properties?.Dictionary;

                        if (revokeProperties != null && revokeProperties.ContainsKey("nonce") && revokeProperties.ContainsKey("id_token"))
                        {
                            var uri = new Uri(message.ProtocolMessage.PostLogoutRedirectUri);
                            var host = uri.GetComponents(UriComponents.SchemeAndServer, UriFormat.Unescaped);
                            var path = $"/{uri.GetComponents(UriComponents.Path, UriFormat.Unescaped)}";
                            var nonce = revokeProperties["nonce"];

                            message.ProtocolMessage.PostLogoutRedirectUri = $"{host}/identity/postexternallogout?ReturnUrl={path}&nonce={nonce}";

                            //This is not in Sean Sartell's solution, but it is needed for IdentityServer4 to
                            //redirect from the identity provider back to the Sitecore postexternallogout handler
                            message.ProtocolMessage.IdTokenHint = revokeProperties["id_token"];
                        }

                        return Task.CompletedTask;
                    }
                }
            };

            args.App.UseOpenIdConnectAuthentication(openIdConnectAuthOptions);
        }
    }
}