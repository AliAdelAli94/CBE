using CBE.Feature.Authentication.Enums;
using Sitecore.Data.Items;

namespace CBE.Feature.Authentication.Services
{
    public interface IProfileSettingsService
    {
        Item GetUserDefaultProfile(UserTypes userType);
    }
}