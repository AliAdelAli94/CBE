using CBE.Feature.Accounts.Models;
using Sitecore.Security.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBE.Feature.Accounts.Services
{
    public interface IAccountService
    {
        bool Exists(string userName);

        User Login(string userName, string password);

        void Logout();

        string RestorePassword(string userName);

        void RegisterUser(RegistrationInfo registrationInfo, string profileId);
    }
}
