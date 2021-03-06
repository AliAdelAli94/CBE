using Sitecore.Data.Items;

namespace CBE.Foundation.Dictionary.Repositories
{
  public interface IDictionaryPhraseRepository
  {
    string Get(string relativePath, string defaultValue = "");
    Item GetItem(string relativePath, string defaultValue = "");
  }
}