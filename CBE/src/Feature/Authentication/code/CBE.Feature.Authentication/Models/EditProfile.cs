using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBE.Feature.Authentication.Models
{
    public class EditProfile : UserMainProfile
    {
        // [Display(Name = nameof(DictionaryResources.LblEditProfileActivationCodeCaption), ResourceType = typeof(DictionaryResources))]
        public string ActivationCode { get; set; }
        public string ExpireDateActivationCode { get; set; }
        public string ChangeEmailCode { get; set; }

        //[Display(Name = nameof(DictionaryResources.LblEditProfileEmailCaption), ResourceType = typeof(DictionaryResources))]
        //[EmailAddress(ErrorMessageResourceName = nameof(DictionaryResources.ValidationsInvalidEmailAddress), ErrorMessageResourceType = typeof(DictionaryResources))]
        public string Email { get; set; }

        //[Display(Name = nameof(DictionaryResources.LblEditProfileFullNameCaption), ResourceType = typeof(DictionaryResources))]
        //[RegularExpression(@"[^>\<\!\*\%\#\(\)\+\=\$\^\~\'\@{\}\[\]\&\?\;\:\|\+\-\.\,]+$", ErrorMessageResourceName = nameof(DictionaryResources.ValidationSpecialCharacters), ErrorMessageResourceType = typeof(DictionaryResources))]
        public string FullName { get; set; }

        //[Display(Name = nameof(DictionaryResources.LblEditProfileOriginCaption), ResourceType = typeof(DictionaryResources))]
        public string Origin { get; set; }

        //[Display(Name = nameof(DictionaryResources.LblEditProfileProCompanyCaption), ResourceType = typeof(DictionaryResources))]
        public string ProCompany { get; set; }

        //[Display(Name = nameof(DictionaryResources.LblEditProfileNotificationEmailCaption), ResourceType = typeof(DictionaryResources))]
        //[EmailAddress(ErrorMessageResourceName = nameof(DictionaryResources.ValidationsInvalidEmailAddress), ErrorMessageResourceType = typeof(DictionaryResources))]
        public string NotificationEmail { get; set; }

        //[Display(Name = nameof(DictionaryResources.LblEditProfileMobileCaption), ResourceType = typeof(DictionaryResources))]
        //[RegularExpression(@"^\+\d{11,21}|00\d{11,21}", ErrorMessageResourceName = nameof(DictionaryResources.ValidationsMobileFormat), ErrorMessageResourceType = typeof(DictionaryResources))]
        //[MaxLength(21, ErrorMessageResourceName = nameof(DictionaryResources.ValidationsMaxLengthExceeded), ErrorMessageResourceType = typeof(DictionaryResources))]
        //[MinLength(11, ErrorMessageResourceName = nameof(DictionaryResources.ValidationsMinLength), ErrorMessageResourceType = typeof(DictionaryResources))]
        public string Mobile { get; set; }
        public string Photo { get; set; }

    }
}