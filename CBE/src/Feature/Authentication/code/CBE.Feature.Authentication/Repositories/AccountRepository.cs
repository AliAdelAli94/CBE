using CBE.Feature.Authentication.Enums;
using Sitecore.Diagnostics;
using Sitecore.Security.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBE.Feature.Authentication.Repositories
{
    // [Service(typeof(IAccountRepository))]
    public class AccountRepository : IAccountRepository
    {
        public void RegisterUser(string email, string password, string profileId, UserTypes userType = UserTypes.Company, Guid? organizationId = null)
        {
            Assert.ArgumentNotNullOrEmpty(email, nameof(email));
            Assert.ArgumentNotNullOrEmpty(password, nameof(password));
            var fullName = Sitecore.Context.Domain.GetFullName(email);
            try
            {
                Assert.IsNotNullOrEmpty(fullName, "Can't retrieve full email");
                var user = User.Create(fullName, password);
                user.Profile.Email = email;

                if (!string.IsNullOrEmpty(profileId))
                {
                    user.Profile.ProfileItemId = profileId;
                }
                user.Profile.Save();
                //AssignUserToRole(email, userType, organizationId);
                //this.pipelineService.RunRegistered(user);
                //switch (userType)
                //{
                //    case UserTypes.NotDefined:
                //        break;
                //    case UserTypes.Individual:
                //        break;
                //    case UserTypes.Company:
                //        break;
                //    case UserTypes.Institution:
                //        break;
                //    case UserTypes.Organization:
                //        Roles.CreateRole("MOFAIC\\" + user.GetId()?.Guid.ToString());
                //        break;
                //    case UserTypes.Representative:
                //        UserRepresentativeModel userRepresentativeModel = this.UserRepresentativeService.GetUserRepresentativeByEmail(email);
                //        if (userRepresentativeModel != null) this.UserRepresentativeService.DeleteRepresentativeProfile(userRepresentativeModel.Id);
                //        userRepresentativeModel = new UserRepresentativeModel();
                //        userRepresentativeModel.Email = email;
                //        userRepresentativeModel.RepresentativeId = user.GetId().Guid;
                //        userRepresentativeModel.OrganizationId = organizationId.Value;
                //        userRepresentativeModel.Id = Guid.NewGuid();
                //        this.UserRepresentativeService.AddRepresentativeProfile(userRepresentativeModel);
                //    break;
                //default:
                //    break;
                //  }

            }
            catch (Exception ex)
            {
                //DatabaseLogger.Error(ex);
                //AccountTrackerService.TrackRegistrationFailed(email);
                throw;
            }

            // this.Login(email, password);
        }

        public bool Exists(string email)
        {
            var fullName = Sitecore.Context.Domain.GetFullName(email);
            //  var user = Membership.GetUser(email);
            return User.Exists(fullName);
        }

    }
}