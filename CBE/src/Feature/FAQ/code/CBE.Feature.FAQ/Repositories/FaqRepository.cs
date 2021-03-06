namespace CBE.Feature.FAQ.Repositories
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Sitecore.Data.Items;
  using CBE.Foundation.SiteExtensions.Extensions;

  public static class FaqRepository
  {
    public static IEnumerable<Item> Get(Item item)
    {
      if (item == null)
        throw new ArgumentNullException(nameof(item));

      return item.GetMultiListValueItems(Templates.FaqGroup.Fields.GroupMember).Where(i => i.DescendsFrom(Templates.Faq.ID));
    }
  }
}