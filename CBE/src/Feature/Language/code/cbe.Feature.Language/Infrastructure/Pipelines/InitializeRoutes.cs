﻿namespace CBE.Feature.Language.Infrastructure.Pipelines
{
    using System.Web.Routing;
    using Sitecore;
    using Sitecore.Pipelines;

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