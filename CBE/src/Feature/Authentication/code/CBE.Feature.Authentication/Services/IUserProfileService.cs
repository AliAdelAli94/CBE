using CBE.Feature.Authentication.Enums;
using CBE.Feature.Authentication.Models;
using Sitecore.Security;

namespace CBE.Feature.Authentication.Services
{
    public interface IUserProfileService
    {
        string GetUserDefaultProfileId(UserTypes userType = UserTypes.Company);
        void SaveProfile(UserProfile userProfile, EditProfile model);

    }
}