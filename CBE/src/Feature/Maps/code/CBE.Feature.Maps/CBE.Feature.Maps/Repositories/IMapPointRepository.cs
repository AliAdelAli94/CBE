namespace CBE.Feature.Maps.Repositories
{
    using System.Collections.Generic;
    using global::Sitecore.Data.Items;
    using Models;

    public interface IMapPointRepository
    {
        IEnumerable<MapPoint> GetAll(Item contextItem);
    }
}