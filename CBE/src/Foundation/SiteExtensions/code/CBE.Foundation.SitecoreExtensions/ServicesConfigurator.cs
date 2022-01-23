using CBE.Foundation.SitecoreExtensions.Services;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace CBE.Foundation.SitecoreExtensions
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(ITrackerService), typeof(TrackerService));
        }
    }
}