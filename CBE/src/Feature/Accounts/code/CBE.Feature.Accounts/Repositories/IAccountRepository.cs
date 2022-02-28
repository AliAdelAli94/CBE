namespace CBE.Feature.Accounts.Repositories
{
    using CBE.Feature.Accounts.Models;
    using Sitecore.Security.Accounts;

    public interface IAccountRepository
    {
        /// <summary>
        ///   Method method changes thepassword for the user to a random string,
        ///   and returns that string.
        /// </summary>
        /// <param name="userName">Username that should have new password</param>
        /// <returns>New generated password</returns>
        string RestorePassword(string userName);
        void RegisterUser(RegistrationInfo registrationInfo, string profileId);
        bool Exists(string userName);
        void Logout();
        User Login(string userName, string password);
    }
}