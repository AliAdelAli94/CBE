using CBE.Feature.Authentication.Enums;
using System;

namespace CBE.Feature.Authentication.Repositories
{
    public interface IAccountRepository
    {
        void RegisterUser(string email, string password, string profileId, UserTypes userType = UserTypes.Company, Guid? organizationId = null);
        bool Exists(string email);
    }
}
