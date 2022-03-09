using CBE.Feature.Sitemap.Models;
using CBE.Feature.Sitemap.Repositories;
using CBE.Foundation.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBE.Feature.Sitemap.Services
{
    [Service(typeof(ISitemapService))]
    public class SitemapService : ISitemapService
    {
        private ISitemapRepository _SitemapRepository { get; }
        public SitemapService(ISitemapRepository sitemapRepository)
        {
            this._SitemapRepository = sitemapRepository;
        }

        public Section GetSiteMapItems()
        {
            return this._SitemapRepository.GetSiteMapItems();
        }

    }
}