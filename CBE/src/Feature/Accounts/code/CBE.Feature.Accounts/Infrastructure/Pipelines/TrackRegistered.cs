namespace CBE.Feature.Accounts.Infrastructure.Pipelines
{
    using CBE.Feature.Accounts.Services;
    using CBE.Foundation.Accounts.Pipelines;

    public class TrackRegistered
    {
        private readonly IAccountTrackerService accountTrackerService;
        private readonly IUpdateContactFacetsService updateContactFacetsService;

        public TrackRegistered(IAccountTrackerService accountTrackerService, IUpdateContactFacetsService updateContactFacetsService)
        {
            this.accountTrackerService = accountTrackerService;
            this.updateContactFacetsService = updateContactFacetsService;
        }

        public void Process(AccountsPipelineArgs args)
        {
            this.updateContactFacetsService.UpdateContactFacets(args.User.Profile);
            this.accountTrackerService.TrackRegistration();
        }

    }
}