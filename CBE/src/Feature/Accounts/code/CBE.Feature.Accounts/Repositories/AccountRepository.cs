namespace CBE.Feature.Accounts.Repositories
{
    using System;
    using System.Web.Security;
    using Sitecore.Diagnostics;
    using CBE.Feature.Accounts.Services;
    using CBE.Foundation.Accounts.Pipelines;
    using CBE.Foundation.DependencyInjection;
    using Sitecore.Pipelines;
    using Sitecore.Security.Accounts;
    using Sitecore.Security.Authentication;
    using Sitecore;
    using CBE.Feature.Accounts.Models;

    [Service(typeof(IAccountRepository))]
    public class AccountRepository : IAccountRepository
    {
        public IAccountTrackerService AccountTrackerService { get; }
        private readonly PipelineService pipelineService;
        private readonly IUserProfileService userProfileService;

        public AccountRepository(PipelineService pipelineService, IAccountTrackerService accountTrackerService, IUserProfileService userProfileService)
        {
            this.AccountTrackerService = accountTrackerService;
            this.userProfileService = userProfileService;
            this.pipelineService = pipelineService;
        }

        public bool Exists(string userName)
        {
            var fullName = Context.Domain.GetFullName(userName);

            return User.Exists(fullName);
        }

        public User Login(string userName, string password)
        {
            var accountName = string.Empty;
            var domain = Context.Domain;
            if (domain != null)
            {
                accountName = domain.GetFullName(userName);
            }

            var result = AuthenticationManager.Login(accountName, password);
            if (!result)
            {
                AccountTrackerService.TrackLoginFailed(accountName);
                return null;
            }

            var user = AuthenticationManager.GetActiveUser();
            this.pipelineService.RunLoggedIn(user);
            return user;
        }

        public void Logout()
        {
            var user = AuthenticationManager.GetActiveUser();
            AuthenticationManager.Logout();
            if (user != null)
                this.pipelineService.RunLoggedOut(user);
        }

        public string RestorePassword(string userName)
        {
            var domainName = Context.Domain.GetFullName(userName);
            var user = Membership.GetUser(domainName);
            if (user == null)
                throw new ArgumentException($"Could not reset password for user '{userName}'", nameof(userName));
            return user.ResetPassword();
        }

        public void RegisterUser(RegistrationInfo registrationInfo, string profileId)
        {
            try
            {
                Assert.ArgumentNotNullOrEmpty(registrationInfo.Email, nameof(registrationInfo.Email));
                Assert.ArgumentNotNullOrEmpty(registrationInfo.Password, nameof(registrationInfo.Password));

                var fullName = Context.Domain.GetFullName(registrationInfo.Email);
                Assert.IsNotNullOrEmpty(fullName, "Can't retrieve full userName");

                var user = User.Create(fullName, registrationInfo.Password);
                user.Profile.Email = registrationInfo.Email;
                if (!string.IsNullOrEmpty(profileId))
                {
                    user.Profile.ProfileItemId = profileId;
                }
                this.userProfileService.SaveProfile(user.Profile, registrationInfo);
                this.pipelineService.RunRegistered(user);
            }
            catch
            {
                AccountTrackerService.TrackRegistrationFailed(registrationInfo.Email);
                throw;
            }

            this.Login(registrationInfo.Email, registrationInfo.Password);
        }
    }
}