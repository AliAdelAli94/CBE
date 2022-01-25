using CBE.Feature.Authentication.Enums;
using CBE.Feature.Authentication.Models;
using CBE.Feature.Authentication.Repositories;
using CBE.Feature.Authentication.Services;
using System.Web.Mvc;
using System.Web.Security;

namespace CBE.Feature.Authentication.Controllers
{

    public class AccountsController : BaseController
    {
        private IAccountRepository AccountRepository { get; }
        private IUserProfileService UserProfileService { get; }

        public AccountsController(IAccountRepository accountRepository, IUserProfileService userProfileService)
        {
            this.AccountRepository = accountRepository;
            this.UserProfileService = userProfileService;
        }

        //    [RedirectAuthenticated]
        public ActionResult Register()
        {
            // setCountriesViewData();
            if (Request.QueryString["Email"] != null)
            {
                RegistrationInfo registrationInfo = new RegistrationInfo();
                registrationInfo.Email = Request.QueryString["Email"];
                this.ModelState.AddModelError(nameof(registrationInfo.Email), "user with this mail doesn`t exits");
                return this.View(registrationInfo);
            }
            return this.View();
        }

        [HttpPost]
        //[RedirectAuthenticated]
        //   [ValidateRenderingId]
        public ActionResult Register(RegistrationInfo registrationInfo)
        {
            // setCountriesViewData();
            var reCaptcha = Request.Form["g-recaptcha-response"];
            if (/*RecapchaValidator.ValidateCaptcha(reCaptcha)*/ true)
            {
                if (!ModelState.IsValid)
                {
                    return View(registrationInfo);
                }

                if (this.AccountRepository.Exists(registrationInfo.Email))
                {
                    //  this.ModelState.AddModelError(nameof(registrationInfo.Email), DictionaryResources.ErrorUserAlreadyExists);
                    return this.View(registrationInfo);
                }

                try
                {
                    this.AccountRepository.RegisterUser(registrationInfo.Email, registrationInfo.Password, this.UserProfileService.GetUserDefaultProfileId(), UserTypes.Individual);

                    // EditProfile profile = AccountRepository.SetEditProfile(registrationInfo);
                    //Sitecore.Security.Accounts.User scUser = Sitecore.Security.Accounts.User.FromName("extranet\\" + registrationInfo.Email, true);
                    //this.UserProfileService.SaveProfile(scUser.Profile, profile);
                    ////    this.NotificationService.ActivateMail(registrationInfo.Email, profile.ActivationCode);
                    return View("RegisterSuccess");
                }
                catch (MembershipCreateUserException ex)
                {
                    //DatabaseLogger.Error(ex);
                    //Log.Error($"Can't create user with {registrationInfo.Email}", ex, this);
                    //if (ex.StatusCode.ToString() == "InvalidPassword")
                    //{
                    //    this.ModelState.AddModelError(nameof(registrationInfo.Password), DictionaryResources.ValidationsPasswordComplexity);
                    //    return this.View(registrationInfo);
                    //}
                    //this.ModelState.AddModelError(nameof(registrationInfo.Email), ex.Message);
                    return this.View(registrationInfo);
                }
            }
            // this.ModelState.AddModelError("txtcaptcha", DictionaryResources.ValidationsRequiredRecaptcha);
            //return this.View(registrationInfo);
        }

    }
}