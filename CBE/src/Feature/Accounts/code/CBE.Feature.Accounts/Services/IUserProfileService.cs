namespace CBE.Feature.Accounts.Services
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using CBE.Feature.Accounts.Models;
    using Sitecore.Security;
    using Sitecore.Security.Accounts;

    public interface IUserProfileService
    {
        string GetUserDefaultProfileId();
        EditProfile GetEmptyProfile();
        EditProfile GetProfile(User user);
        void SaveProfile(UserProfile userProfile, EditProfile model);
        IEnumerable<string> GetInterests();
        RegistrationInfo GetEmptyRegistrationProfile();
        void SaveProfile(UserProfile userProfile, RegistrationInfo model, string activationCode);


    }
}