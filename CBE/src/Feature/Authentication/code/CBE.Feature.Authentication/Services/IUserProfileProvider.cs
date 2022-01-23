using Sitecore.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBE.Feature.Authentication.Services
{
    public interface IUserProfileProvider
    {
        IDictionary<string, string> GetCustomProperties(UserProfile userProfile);
        void SetCustomProfile(UserProfile userProfile, IDictionary<string, string> properties);
    }
}