using Sitecore;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Sites;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CBE.Foundation.SitecoreExtensions.Extensions
{
    public static class SiteExtensions
    {
        public static string GetSiteHomeUrl(this SiteContext site)
        {
            var siteHostName = string.Empty;
            try
            {
                if (Context.Site != null)
                {
                    siteHostName = Settings.GetSetting("SiteProtocol") + Context.Site.TargetHostName;
                }
                else
                {
                    siteHostName = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
                        .AppSettings.Settings["SiteHostName"].Value;
                }
            }
            catch (Exception ex)
            {
                //DatabaseLogger.Error(ex);
            }
            return siteHostName;
        }
        public static Item GetContextItem(this SiteContext site, ID derivedFromTemplateID)
        {
            if (site == null)
            {
                throw new ArgumentNullException(nameof(site));
            }

            var startItem = site.GetStartItem();
            return startItem?.GetAncestorOrSelfOfTemplate(derivedFromTemplateID);
        }

        public static Item GetRootItem(this SiteContext site)
        {
            if (site == null)
            {
                throw new ArgumentNullException(nameof(site));
            }

            return site.Database.GetItem(site.RootPath);
        }

        public static Item GetStartItem(this SiteContext site)
        {
            if (site == null)
            {
                throw new ArgumentNullException(nameof(site));
            }

            return site.Database.GetItem(site.StartPath);
        }
    }

}