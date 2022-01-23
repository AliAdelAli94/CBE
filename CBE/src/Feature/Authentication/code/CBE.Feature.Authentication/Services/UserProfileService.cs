using CBE.Feature.Authentication.Enums;
using CBE.Feature.Authentication.Models;
using Sitecore.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBE.Feature.Authentication.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IProfileSettingsService ProfileSettingsService;
        private readonly IUserProfileProvider UserProfileProvider;
        private readonly IUpdateContactFacetsService UpdateContactFacetsService;
        private readonly IAccountTrackerService AccountTrackerService;


        public UserProfileService(IProfileSettingsService profileSettingsService, IUserProfileProvider userProfileProvider, IUpdateContactFacetsService updateContactFacetsService, IAccountTrackerService accountTrackerService)
        {
            this.ProfileSettingsService = profileSettingsService;
            this.UserProfileProvider = userProfileProvider;
            this.UpdateContactFacetsService = updateContactFacetsService;
            this.AccountTrackerService = accountTrackerService;
        }

        public virtual string GetUserDefaultProfileId(UserTypes userType = UserTypes.Company)
        {
            return this.ProfileSettingsService.GetUserDefaultProfile(userType)?.ID?.ToString();
        }

        public virtual void SaveProfile(UserProfile userProfile, EditProfile model)
        {
            var properties = new Dictionary<string, string>
            {
                [CBE.Feature.Authentication.Constants.CompanyProfile.Fields.FullName] = model.FullName,
                [CBE.Feature.Authentication.Constants.CompanyProfile.Fields.Mobile] = model.Mobile,
                [CBE.Feature.Authentication.Constants.CompanyProfile.Fields.Origin] = model.Origin,
                [CBE.Feature.Authentication.Constants.CompanyProfile.Fields.NotificationEmail] = model.NotificationEmail,
                [CBE.Feature.Authentication.Constants.CompanyProfile.Fields.ProCompany] = model.ProCompany,
                [CBE.Feature.Authentication.Constants.CompanyProfile.Fields.ActivationCode] = model.ActivationCode,
                [CBE.Feature.Authentication.Constants.CompanyProfile.Fields.ExpireDateActivationCode] = model.ExpireDateActivationCode,
                [CBE.Feature.Authentication.Constants.CompanyProfile.Fields.ForgotPasswordCode] = model.ForgotPasswordCode,
                [CBE.Feature.Authentication.Constants.CompanyProfile.Fields.ChangeEmailCode] = model.ChangeEmailCode,
                [CBE.Feature.Authentication.Constants.CompanyProfile.Fields.Photo] = model.Photo != null ? model.Photo : "",
                [CBE.Feature.Authentication.Constants.CompanyProfile.Fields.MobileTokenCode] = model.MobileToken != null ? model.MobileToken : "",
                [CBE.Feature.Authentication.Constants.CompanyProfile.Fields.FavoriteServices] = model.FavoriteServices != null ? model.FavoriteServices : "",
                [CBE.Feature.Authentication.Constants.CompanyProfile.Fields.AndroidMobileId] = model.AndroidMobileId != null ? model.AndroidMobileId : "",
                [CBE.Feature.Authentication.Constants.CompanyProfile.Fields.IOSMobileId] = model.IOSMobileId != null ? model.IOSMobileId : "",

                [nameof(userProfile.Name)] = model.FullName,
                [nameof(userProfile.FullName)] = model.FullName
            };

            this.UserProfileProvider.SetCustomProfile(userProfile, properties);
            this.UpdateContactFacetsService.UpdateContactFacets(userProfile);
            AccountTrackerService.TrackEditProfile(userProfile);
        }
    }
}