﻿namespace CBE.Foundation.Multisite.Commands
{
    using Sitecore.Configuration;
    using Sitecore.Shell.Applications.WebEdit.Commands;
    using Sitecore.Sites;
    using Sitecore.Web;
    using Sitecore.Web.UI.Sheer;

    /// <summary>
    /// Overrides default Shell.Applications.WebEdit.Commands.OpenExperienceEditor
    /// Uses domain to resolve site for editing
    /// </summary>
    public class OpenExperienceEditorChild : OpenExperienceEditor
    {
        private const string DefaultSiteSetting = "Preview.DefaultSite";

        public new void Run(ClientPipelineArgs args)
        {
            var hostName = WebUtil.GetHostName();
            var site = SiteContextFactory.GetSiteContext(hostName, "/");
            var siteName = site?.Name ?? Settings.Preview.DefaultSite;

            using (new SettingsSwitcher(DefaultSiteSetting, siteName))
            {
                base.Run(args);
            }
        }
    }
}