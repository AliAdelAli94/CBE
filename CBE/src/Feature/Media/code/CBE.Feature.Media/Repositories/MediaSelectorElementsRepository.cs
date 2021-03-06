namespace CBE.Feature.Media.Repositories
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Sitecore.Data.Items;
  using CBE.Feature.Media.Models;
  using CBE.Foundation.SiteExtensions.Extensions;
  using Sitecore.Mvc.Extensions;

  public static class MediaSelectorElementsRepository
  {
    public static IEnumerable<MediaSelectorElement> Get(Item item)
    {
      if (item == null)
        throw new ArgumentNullException(nameof(item));

      var items = GetMediaFromMultiList(item).ToArray();
      if (!items.Any())
        items = GetMediaFromChildren(item).ToArray();

      var active = "active";
      foreach (var child in items)
      {
        if (child.DescendsFrom(Templates.HasMediaVideo.ID) && child[Templates.HasMediaVideo.Fields.VideoLink].IsEmptyOrNull() && child[Templates.HasMedia.Fields.Thumbnail].IsEmptyOrNull())
        {
          continue;
        }

        yield return new MediaSelectorElement
        {
          Item = child,
          Active = active
        };
        active = "";
      }
    }

    private static IEnumerable<Item> GetMediaFromChildren(Item item)
    {
      return item.Children.Where(i => i.DescendsFrom(Templates.HasMedia.ID));
    }

    private static IEnumerable<Item> GetMediaFromMultiList(Item item)
    {
      var multiListValues = item.GetMultiListValueItems(Templates.HasMediaSelector.Fields.MediaSelector);
      return multiListValues.Where(i => i.DescendsFrom(Templates.HasMedia.ID));
    }
  }
}