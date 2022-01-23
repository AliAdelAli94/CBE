namespace CBE.Feature.Authentication.Services
{
    using Sitecore.Security;

    public interface IAccountTrackerService
    {
        void TrackRegistration();
        void TrackRegistrationOutcome();
        void TrackLoginAndIdentifyContact(string source, string identifier);
        void TrackLogout(string email);
        void TrackRegistrationFailed(string email);
        void TrackLoginFailed(string email);
        void TrackEditProfile(UserProfile userProfile);
    }
}