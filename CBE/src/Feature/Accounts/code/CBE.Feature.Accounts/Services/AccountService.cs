using CBE.Feature.Accounts.Models;
using CBE.Feature.Accounts.Repositories;
using CBE.Foundation.Accounts.Pipelines;
using CBE.Foundation.DependencyInjection;
using Sitecore.Security.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBE.Feature.Accounts.Services
{
    [Service(typeof(IAccountService))]
    public class AccountService : IAccountService
    {
        public IAccountRepository AccountRepository { get; }
        public IAccountTrackerService AccountTrackerService { get; }
        private readonly PipelineService pipelineService;
        private readonly IUserProfileService userProfileService;

        public AccountService(PipelineService pipelineService, IAccountTrackerService accountTrackerService, IUserProfileService userProfileService, IAccountRepository accountRepository)
        {
            this.AccountTrackerService = accountTrackerService;
            this.pipelineService = pipelineService;
            this.userProfileService = userProfileService;
            this.AccountRepository = accountRepository;
        }

        public bool Exists(string userName)
        {
            return this.AccountRepository.Exists(userName);
        }

        public User Login(string userName, string password)
        {
            return this.AccountRepository.Login(userName, password);
        }

        public void Logout()
        {
            this.AccountRepository.Logout();
        }

        public string RestorePassword(string userName)
        {
            return this.AccountRepository.RestorePassword(userName);
        }

        public void RegisterUser(RegistrationInfo registrationInfo, string profileId)
        {
            this.RegisterUser(registrationInfo, profileId);
        }
    }
}