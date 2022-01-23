using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBE.Feature.Authentication
{
    public struct Constants
    {
        public struct UserProfile
        {
            public struct Fields
            {
                public static readonly string uuid = "uuid";
                public static readonly string UAEuuid = "UAEuuid";
                public static readonly string userType = "userType";
                public static readonly string idn = "idn";
                public static readonly string fullnameEN = "fullnameEN";
                public static readonly string fullnameAR = "fullnameAR";
                public static readonly string firstnameEN = "firstnameEN";
                public static readonly string firstnameAR = "firstnameAR";
                public static readonly string lastnameEN = "lastnameEN";
                public static readonly string lastnameAR = "lastnameAR";
                public static readonly string gender = "gender";
                public static readonly string nationalityEN = "nationalityEN";
                public static readonly string nationalityAR = "nationalityAR";
                public static readonly string dob = "dob";
                public static readonly string mobile = "mobile";
                public static readonly string mobileNotVerified = "mobileNotVerified";
                public static readonly string email = "email";
                public static readonly string emailNotVerified = "emailNotVerified";
                public static readonly string photo = "photo";
                public static readonly string passportNumber = "passportNumber";
                public static readonly string passportIssueDate = "passportIssueDate";
                public static readonly string passportExpiryDate = "passportExpiryDate";
                public static readonly string passportTypeCode = "passportTypeCode";
                public static readonly string passportCountryDescriptionEN = "passportCountryDescriptionEN";
                public static readonly string idType = "idType";
                public static readonly string titleEN = "titleEN";
                public static readonly string titleAR = "titleAR";
                public static readonly string MobileToken = "MobileToken";
                public static readonly string FavoriteServices = "FavoriteServices";
                public static readonly string ForgotPasswordCode = "ForgotPasswordCode";
                public static readonly string AndroidMobileId = "AndroidMobileId";
                public static readonly string IOSMobileId = "IOSMobileId";
                public static readonly string CRMContactId = "CRMContactId";

            }
        }

        public struct CompanyProfile
        {
            public struct Fields
            {
                public static readonly string FullName = "FullName";
                public static readonly string NotificationEmail = "NotificationEmail";
                public static readonly string ProCompany = "ProCompany";
                public static readonly string Mobile = "Mobile";
                public static readonly string Link = "Link";
                public static readonly string Origin = "Origin";
                public static readonly string Language = "Language";
                public static readonly string Timezone = "Timezone";
                public static readonly string PictureUrl = "PictureUrl";
                public static readonly string PictureMimeType = "PictureMimeType";
                public static readonly string ActiveProfile = "false";
                public static readonly string ActivationCode = "ActivationCode";
                public static readonly string ExpireDateActivationCode = "ExpireDateActivationCode";
                public static readonly string ForgotPasswordCode = "ForgotPasswordCode";
                public static readonly string ChangeEmailCode = "ChangeEmailCode";
                public static readonly string Photo = "Photo";
                public static readonly string MobileTokenCode = "MobileToken";
                public static readonly string FavoriteServices = "FavoriteServices";
                public static readonly string AndroidMobileId = "AndroidMobileId";
                public static readonly string IOSMobileId = "IOSMobileId";
            }
        }

    }
}