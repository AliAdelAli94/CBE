namespace CBE.Feature.Identity.Repositories
{
    using System;
    using Sitecore.Data.Items;
    using CBE.Foundation.SiteExtensions.Extensions;
    using Sitecore;

    public static class IdentityRepository
    {
        public static Item Get(Item contextItem)
        {
            if (contextItem == null)
                throw new ArgumentNullException(nameof(contextItem));

            return contextItem.GetAncestorOrSelfOfTemplate(Templates.Identity.ID) ?? Context.Site.GetContextItem(Templates.Identity.ID);
        }
    }
}