namespace CBE.Feature.Navigation.Repositories
{
  using Sitecore.Data.Items;
  using CBE.Feature.Navigation.Models;

  public interface INavigationRepository
  {
    Item GetNavigationRoot(Item contextItem);
    NavigationItems GetBreadcrumb();
    NavigationItems GetPrimaryMenu();
    NavigationItem GetSecondaryMenuItem();
    NavigationItems GetLinkMenuItems(Item menuItem);
  }
}