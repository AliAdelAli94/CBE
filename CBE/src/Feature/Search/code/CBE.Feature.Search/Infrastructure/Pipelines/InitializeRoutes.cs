namespace CBE.Feature.Search.Infrastructure.Pipelines
{
    using System.Web.Routing;
    using CBE.Feature.Search;
    using CBE.Foundation.DependencyInjection;
    using Sitecore;
    using Sitecore.Pipelines;

    [Service]
    public class InitializeRoutes
    {
        public void Process(PipelineArgs args)
        {
            if (!Context.IsUnitTesting)
            {
                RouteConfig.RegisterRoutes(RouteTable.Routes);
            }
        }
    }
}