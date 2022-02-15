namespace CBE.Feature.Metadata.Infrastructure.Pipelines.GetPageMetadata
{
    using CBE.Foundation.DependencyInjection;

    [Service]
    public class CombineTitle
    {
        public void Process(GetPageMetadataArgs args)
        {
            args.Metadata.Title = args.Metadata.PageTitle + args.Metadata.SiteTitle;
        }
    }
}