namespace CBE.Foundation.Dictionary.Extensions
{
  using System.Web;
  using CBE.Foundation.Dictionary.Repositories;
  using CBE.Foundation.SiteExtensions.Extensions;
  using Sitecore.Mvc.Helpers;

  public static class SitecoreExtensions
  {
    public static string Dictionary(this SitecoreHelper helper, string relativePath, string defaultValue = "")
    {
      return DictionaryPhraseRepository.Current.Get(relativePath, defaultValue);
    }

    public static HtmlString DictionaryField(this SitecoreHelper helper, string relativePath, string defaultValue = "")
    {
      var item = DictionaryPhraseRepository.Current.GetItem(relativePath, defaultValue);
      if (item == null)
        return new HtmlString(defaultValue);
      return helper.Field(Templates.DictionaryEntry.Fields.Phrase, item);
    }
  }
}