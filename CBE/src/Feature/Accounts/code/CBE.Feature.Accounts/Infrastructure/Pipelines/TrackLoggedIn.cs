namespace CBE.Feature.Accounts.Infrastructure.Pipelines
{
    using Sitecore.Analytics;
    using CBE.Feature.Accounts.Services;
    using CBE.Foundation.Accounts.Pipelines;

    public class TrackLoggedIn
    {
        private readonly IAccountTrackerService accountTrackerService;

        public TrackLoggedIn(IAccountTrackerService accountTrackerService)
        {
            this.accountTrackerService = accountTrackerService;
        }

        public void Process(LoggedInPipelineArgs args)
        {
            var contactId = args.ContactId;
            this.accountTrackerService.TrackLoginAndIdentifyContact(args.Source, args.UserName);
            args.ContactId = Tracker.Current?.Contact?.ContactId;
            args.PreviousContactId = contactId;
        }
    }
}