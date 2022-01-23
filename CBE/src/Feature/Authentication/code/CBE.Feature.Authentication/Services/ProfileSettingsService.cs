using CBE.Feature.Authentication.Enums;
using CBE.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.SecurityModel;

namespace CBE.Feature.Authentication.Services
{
    public class ProfileSettingsService : IProfileSettingsService
    {
        public virtual Item GetUserDefaultProfile(UserTypes userType)
        {
            using (new SecurityDisabler())
            {
                var item = GetSettingsItem(Sitecore.Context.Item);
                Assert.IsNotNull(item, "Page with profile settings isn't specified");
                var database = Database.GetDatabase(Settings.ProfileItemDatabase);
                Field profileField = null;
                switch (userType)
                {
                    case UserTypes.NotDefined:
                        break;
                    case UserTypes.Individual:
                        profileField = item.Fields[Templates.ProfileSettigs.Fields.UserProfile];
                        break;
                    case UserTypes.Company:
                        profileField = item.Fields[Templates.ProfileSettigs.Fields.CompanyProfile];
                        break;
                    case UserTypes.Institution:
                        break;
                    case UserTypes.Organization:
                        profileField = item.Fields[Templates.ProfileSettigs.Fields.OrganizationProfile];
                        break;
                    case UserTypes.Representative:
                        profileField = item.Fields[Templates.ProfileSettigs.Fields.RepresentativeProfile];
                        break;
                    default:
                        break;
                }
                //var profileField =IsCompany? item.Fields[Templates.ProfileSettigs.Fields.CompanyProfile]: item.Fields[Templates.ProfileSettigs.Fields.UserProfile];
                var targetItem = database.GetItem(profileField.Value);   //database.GetItem("{93BBC441-E1F2-43CB-B550-94BC881050A9}");

                return targetItem;
            }
        }

        private static Item GetSettingsItem(Item contextItem)
        {
            Item item = null;

            if (contextItem != null)
            {
                item = contextItem.GetAncestorOrSelfOfTemplate(Templates.ProfileSettigs.ID);
            }
            item = item ?? Sitecore.Context.Site.GetContextItem(Templates.ProfileSettigs.ID);

            return item;
        }

    }
}