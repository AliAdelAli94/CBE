using System;
using System.Web.Mvc;
using Sitecore.Mvc.Controllers;
using CBE.Feature.Maps.Repositories;
using Sitecore;
using Sitecore.Data;

namespace CBE.Feature.Maps.Controllers
{
    public class MapsController : SitecoreController
    {
        private readonly IMapPointRepository mapPointRepository;

        public MapsController(IMapPointRepository mapPointRepository)
        {
            this.mapPointRepository = mapPointRepository;
        }

        [HttpPost]
        [Foundation.SiteExtensions.Attributes.SkipAnalyticsTracking]
        public JsonResult GetMapPoints(Guid itemId)
        {
            var item = Context.Database.GetItem(new ID(itemId));
            var points = this.mapPointRepository.GetAll(item);

            return this.Json(points);
        }
    }
}