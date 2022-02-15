using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBE.Feature.Metadata.Infrastructure.Pipelines.GetPageMetadata
{
    using Sitecore.Data.Items;
    using CBE.Feature.Metadata.Models;

    public class GetPageMetadataArgs : Sitecore.Pipelines.PipelineArgs
    {
        public GetPageMetadataArgs(IMetadata metadata, Item item)
        {
            this.Metadata = metadata;
            this.Item = item;
        }

        public IMetadata Metadata { get; }
        public Item Item { get; }
    }
}