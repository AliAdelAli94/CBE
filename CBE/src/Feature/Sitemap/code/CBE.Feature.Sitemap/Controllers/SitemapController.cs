using CBE.Feature.Sitemap.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CBE.Feature.Sitemap.Controllers
{
    public class SitemapController : Controller
    {
        private ISitemapService _SitemapService { get; }
        public SitemapController(ISitemapService sitemapService)
        {
            _SitemapService = sitemapService;
        }

        [HttpGet]
        public ActionResult SiteMapItems()
        {
            var result = _SitemapService.GetSiteMapItems();
            return View(result);
        }

    }
}