namespace CBE.Feature.Accounts.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using CBE.Feature.Accounts.Attributes;
    using CBE.Foundation.Dictionary.Repositories;

    public class RegistrationInfo
    {
        [Display(Name = nameof(EmailCaption), ResourceType = typeof(RegistrationInfo))]
        [Required(ErrorMessageResourceName = nameof(Required), ErrorMessageResourceType = typeof(RegistrationInfo))]
        [EmailAddress(ErrorMessageResourceName = nameof(InvalidEmailAddress), ErrorMessageResourceType = typeof(RegistrationInfo))]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = nameof(PasswordCaption), ResourceType = typeof(RegistrationInfo))]
        [Required(ErrorMessageResourceName = nameof(Required), ErrorMessageResourceType = typeof(RegistrationInfo))]
        [PasswordMinLength(ErrorMessageResourceName = nameof(MinimumPasswordLength), ErrorMessageResourceType = typeof(RegistrationInfo))]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = nameof(ConfirmPasswordCaption), ResourceType = typeof(RegistrationInfo))]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessageResourceName = nameof(ConfirmPasswordMismatch), ErrorMessageResourceType = typeof(RegistrationInfo))]
        public string ConfirmPassword { get; set; }


        // New Fields
        [Display(Name = nameof(FirstNameCaption), ResourceType = typeof(EditProfile))]
        [Required(ErrorMessageResourceName = nameof(Required), ErrorMessageResourceType = typeof(RegistrationInfo))]
        public string FirstName { get; set; }

        [Display(Name = nameof(LastNameCaption), ResourceType = typeof(EditProfile))]
        [Required(ErrorMessageResourceName = nameof(Required), ErrorMessageResourceType = typeof(RegistrationInfo))]
        public string LastName { get; set; }

        [Display(Name = nameof(PhoneNumberCaption), ResourceType = typeof(EditProfile))]
        [Required(ErrorMessageResourceName = nameof(Required), ErrorMessageResourceType = typeof(RegistrationInfo))]
        [RegularExpression(@"^\+?\d*(\(\d+\)-?)?\d+(-?\d+)+$", ErrorMessageResourceName = nameof(PhoneNumberFormat), ErrorMessageResourceType = typeof(EditProfile))]
        [MaxLength(20, ErrorMessageResourceName = nameof(MaxLengthExceeded), ErrorMessageResourceType = typeof(EditProfile))]
        public string PhoneNumber { get; set; }

        [Display(Name = nameof(InterestsCaption), ResourceType = typeof(EditProfile))]
        [Required(ErrorMessageResourceName = nameof(Required), ErrorMessageResourceType = typeof(RegistrationInfo))]
        public string Interest { get; set; }

        public IEnumerable<string> InterestTypes { get; set; }

        public static string ConfirmPasswordCaption => DictionaryPhraseRepository.Current.Get("/Accounts/Register/Confirm Password", "Confirm password");
        public static string EmailCaption => DictionaryPhraseRepository.Current.Get("/Accounts/Register/Email", "E-mail");
        public static string PasswordCaption => DictionaryPhraseRepository.Current.Get("/Accounts/Register/Password", "Password");
        public static string ConfirmPasswordMismatch => DictionaryPhraseRepository.Current.Get("/Accounts/Register/Confirm Password Mismatch", "Your password confirmation does not match. Please enter a new password.");
        public static string MinimumPasswordLength => DictionaryPhraseRepository.Current.Get("/Accounts/Register/Minimum Password Length", "Please enter a password with at lease {1} characters");
        public static string Required => DictionaryPhraseRepository.Current.Get("/Accounts/Register/Required", "Please enter a value for {0}");
        public static string InvalidEmailAddress => DictionaryPhraseRepository.Current.Get("/Accounts/Register/Invalid Email Address", "Please enter a valid email address");


        // New Fields
        public static string FirstNameCaption => DictionaryPhraseRepository.Current.Get("/Accounts/Edit Profile/First Name", "First name");
        public static string LastNameCaption => DictionaryPhraseRepository.Current.Get("/Accounts/Edit Profile/Last Name", "Last name");
        public static string PhoneNumberCaption => DictionaryPhraseRepository.Current.Get("/Accounts/Edit Profile/Phone Number", "Phone number");
        public static string InterestsCaption => DictionaryPhraseRepository.Current.Get("/Accounts/Edit Profile/Interests", "Interests");
        public static string MaxLengthExceeded => DictionaryPhraseRepository.Current.Get("/Accounts/Edit Profile/Max Length", "{0} length should be less than {1}");
        public static string PhoneNumberFormat => DictionaryPhraseRepository.Current.Get("/Accounts/Edit Profile/Phone Number Format", "Phone number should contain only +, ( ) and digits");

    }
}