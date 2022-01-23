using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBE.Feature.Authentication.Models
{
    public class UserMainProfile
    {
        public string MobileToken { get; set; }
        public string FavoriteServices { get; set; }
        public string ForgotPasswordCode { get; set; }
        public string AndroidMobileId { get; set; }
        public string IOSMobileId { get; set; }
    }
}