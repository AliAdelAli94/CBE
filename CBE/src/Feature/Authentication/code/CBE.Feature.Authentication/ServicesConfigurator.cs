using CBE.Feature.Authentication.Controllers;
using CBE.Feature.Authentication.Repositories;
using CBE.Feature.Authentication.Services;
using CBE.Feature.Authentication.Services.FacetUpdaters;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using System.Collections.Generic;

namespace CBE.Feature.Authentication
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IList<IContactFacetUpdater>>(provider => new List<IContactFacetUpdater>()
            {
              //  new PersonalInformationFacetUpdater(),
                new PhoneFacetUpdater(),
                new EmailFacetUpdater(),
              //  new AvatarFacetUpdater(new WebClient())
            });
            serviceCollection.AddTransient(typeof(AccountsController));
            serviceCollection.AddScoped(typeof(IAccountRepository), typeof(AccountRepository));
            serviceCollection.AddScoped(typeof(IXdbContextFactory), typeof(XdbContextFactory));
            serviceCollection.AddScoped(typeof(IUserProfileService), typeof(UserProfileService));
            serviceCollection.AddScoped(typeof(IUserProfileProvider), typeof(UserProfileProvider));
            serviceCollection.AddScoped(typeof(IUpdateContactFacetsService), typeof(UpdateContactFacetsService));
            serviceCollection.AddScoped(typeof(IProfileSettingsService), typeof(ProfileSettingsService));
            serviceCollection.AddScoped(typeof(IContactManagerService), typeof(ContactManagerService));
            serviceCollection.AddScoped(typeof(IAccountTrackerService), typeof(AccountTrackerService));
            serviceCollection.AddScoped(typeof(IAccountsSettingsService), typeof(AccountsSettingsService));
        }
    }
}