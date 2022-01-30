using CBE.Foundation.Dictionary.Models;
using Sitecore.Sites;

namespace CBE.Foundation.Dictionary.Repositories
{
  public interface IDictionaryRepository
  {
    Models.Dictionary Get(SiteContext site);
  }
}