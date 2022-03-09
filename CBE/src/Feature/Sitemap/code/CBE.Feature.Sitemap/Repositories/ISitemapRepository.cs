using CBE.Feature.Sitemap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBE.Feature.Sitemap.Repositories
{
    public interface ISitemapRepository
    {
        Section GetSiteMapItems();
    }
}