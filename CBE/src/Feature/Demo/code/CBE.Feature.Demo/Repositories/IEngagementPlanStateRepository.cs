namespace CBE.Feature.Demo.Repositories
{
    using System.Collections.Generic;
    using CBE.Feature.Demo.Models;

    public interface IEngagementPlanStateRepository
    {
        IEnumerable<EngagementPlanState> GetCurrent();
    }
}