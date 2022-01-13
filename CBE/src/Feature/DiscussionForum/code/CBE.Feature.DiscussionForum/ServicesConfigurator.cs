using CBE.Feature.DiscussionForum.BLL;
using CBE.Feature.DiscussionForum.Controllers;
using CBE.Feature.DiscussionForum.DAL.UnitOfWork;
using CBE.Feature.DiscussionForum.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace CBE.Feature.DiscussionForum
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(TopicsController));
            serviceCollection.AddScoped(typeof(IDiscussionForumUnitOfWork), typeof(DiscussionForumUnitOfWork));
            serviceCollection.AddScoped(typeof(ITopicsService), typeof(TopicsService));
        }
    }
}