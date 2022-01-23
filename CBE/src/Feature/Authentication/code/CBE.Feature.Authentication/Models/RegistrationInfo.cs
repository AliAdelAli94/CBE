using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CBE.Feature.Authentication.Models
{
    public class RegistrationInfo
    {
        public enum ActiveProfile { InActive = 0, Active = 1 };
        public ActiveProfile Active { get; set; } = ActiveProfile.InActive;

        //[Display(Name = nameof(DictionaryResources.LblRegisterFullNameCaption), ResourceType = typeof(DictionaryResources))]
        //[Required(ErrorMessageResourceName = nameof(DictionaryResources.ValidationsRequired), ErrorMessageResourceType = typeof(DictionaryResources))]
        //[RegularExpression(@"[^>\<\!\*\%\#\(\)\+\=\$\^\~\'\@{\}\[\]\&\?\;\:\|\+\-\.\,]+$", ErrorMessageResourceName = nameof(DictionaryResources.ValidationSpecialCharacters), ErrorMessageResourceType = typeof(DictionaryResources))]
        public string FullName { get; set; }

        //[Display(Name = nameof(DictionaryResources.LblRegisterEmailCaption), ResourceType = typeof(DictionaryResources))]
        //[Required(ErrorMessageResourceName = nameof(DictionaryResources.ValidationsRequired), ErrorMessageResourceType = typeof(DictionaryResources))]
        //[EmailAddress(ErrorMessageResourceName = nameof(DictionaryResources.ValidationsInvalidEmailAddress), ErrorMessageResourceType = typeof(DictionaryResources))]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //[Display(Name = nameof(DictionaryResources.LblRegisterOriginCaption), ResourceType = typeof(DictionaryResources))]
        //[Required(ErrorMessageResourceName = nameof(DictionaryResources.ValidationsRequired), ErrorMessageResourceType = typeof(DictionaryResources))]
        public string Origin { get; set; }

        //[Display(Name = nameof(DictionaryResources.LblRegisterMobileCaption), ResourceType = typeof(DictionaryResources))]
        //[Required(ErrorMessageResourceName = nameof(DictionaryResources.ValidationsRequired), ErrorMessageResourceType = typeof(DictionaryResources))]
        //[RegularExpression(@"^\+\d{11,21}|00\d{11,21}", ErrorMessageResourceName = nameof(DictionaryResources.ValidationsMobileFormat), ErrorMessageResourceType = typeof(DictionaryResources))]
        //[MaxLength(21, ErrorMessageResourceName = nameof(DictionaryResources.ValidationsMaxLengthExceeded), ErrorMessageResourceType = typeof(DictionaryResources))]
        //[MinLength(11, ErrorMessageResourceName = nameof(DictionaryResources.ValidationsMinLength), ErrorMessageResourceType = typeof(DictionaryResources))]
        public string Mobile { get; set; }

        //[Display(Name = nameof(DictionaryResources.LblRegisterProCompanyCaption), ResourceType = typeof(DictionaryResources))]
        //  [Required(ErrorMessageResourceName = nameof(DictionaryResources.ValidationsRequired), ErrorMessageResourceType = typeof(DictionaryResources))]
        public string ProCompany { get; set; }

        //[Display(Name = nameof(DictionaryResources.LblRegisterNotificationEmailCaption), ResourceType = typeof(DictionaryResources))]
        //[Required(ErrorMessageResourceName = nameof(DictionaryResources.ValidationsRequired), ErrorMessageResourceType = typeof(DictionaryResources))]
        //[EmailAddress(ErrorMessageResourceName = nameof(DictionaryResources.ValidationsInvalidEmailAddress), ErrorMessageResourceType = typeof(DictionaryResources))]
        public string NotificationEmail { get; set; }

        //[Display(Name = nameof(DictionaryResources.LblRegisterPasswordCaption), ResourceType = typeof(DictionaryResources))]
        //[Required(ErrorMessageResourceName = nameof(DictionaryResources.ValidationsRequired), ErrorMessageResourceType = typeof(DictionaryResources))]
        //[PasswordContainUserName("Email", "FullName", ErrorMessageResourceType = typeof(RegistrationInfo))]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = nameof(DictionaryResources.LblRegisterConfirmPasswordCaption), ResourceType = typeof(DictionaryResources))]
        //[Compare("Password", ErrorMessageResourceName = nameof(DictionaryResources.ValidationsConfirmPasswordMismatch), ErrorMessageResourceType = typeof(DictionaryResources))]
        public string ConfirmPassword { get; set; }


        //[Display(Name = nameof(DictionaryResources.LblRegisterPhotoCaption), ResourceType = typeof(DictionaryResources))]
        ////[RegularExpression(@"^.+(.jpeg|.JPEG|.gif|.GIF|.jpg|.JPG|.png|.PNG)$", ErrorMessageResourceName = nameof(InvalidPhotoExtension), ErrorMessageResourceType = typeof(RegistrationInfo))]
        // [FileType("jpeg,JPEG,gif,GIF,jpg,JPG,png,PNG")]
        public HttpPostedFileBase Photo { get; set; }
        public byte[] Image { get; set; }
        public string MobileAccessToken { get; set; }
    }

}