using CBE.Feature.Sitemap.Models;
using CBE.Foundation.DependencyInjection;
using Newtonsoft.Json;
using Resources;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Web;

namespace CBE.Feature.Sitemap.Repositories
{
    [Service(typeof(ISitemapRepository))]
    public class SitemapRepository : ISitemapRepository
    {
        public Section GetSiteMapItems()
        {
            Sitecore.Data.Database web = Sitecore.Configuration.Factory.GetDatabase("web");

            var home = web.GetItem("/sitecore/content/CBE/home");

            Section homeSection = GetChildren(home);
            return homeSection;
        }

        private Section GetChildren(Item node)
        {
            Section result = new Section();
            if (!node.HasChildren) return result;

            if (node.Name.ToLower() != "_local")
            {
                result.DisplayName = node.DisplayName;
                result.Name = node.Name;
            }
            var childList = node.GetChildren();

            foreach (Item item in childList)
            {
                if (DoesSitecoreItemHavePresentation(item) && !CheckIsBannedPage(item.Name))
                {
                    result.ChildrenPages.Add(new Page()
                    {
                        Name = item.Name,
                        DisplayName = item.DisplayName,
                        URL = Sitecore.Links.LinkManager.GetItemUrl(item)
                    }); ;
                }

                var childrenSections = GetChildren(item);
                if (childrenSections.Name != null)
                {
                    result.ChildrenSections.Add(childrenSections);
                }
            }

            return result;
        }

        private bool DoesSitecoreItemHavePresentation(Item item)
        {
            return item.Fields[Sitecore.FieldIDs.LayoutField] != null
            && item.Fields[Sitecore.FieldIDs.LayoutField].Value != String.Empty;
        }
        private bool CheckIsBannedPage(string pageName)
        {
            ResourceManager resourceManager = new ResourceManager(typeof(BannedPages).ToString(), Assembly.Load("App_GlobalResources"));
            string value = resourceManager.GetString(pageName);
            return value == null ? false : true;

        }
    }
}