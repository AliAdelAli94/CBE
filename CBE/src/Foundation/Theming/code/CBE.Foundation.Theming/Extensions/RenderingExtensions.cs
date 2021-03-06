namespace CBE.Foundation.Theming.Extensions
{
    using System.Web.Mvc;
    using Sitecore.Data;
    using CBE.Foundation.SiteExtensions.Extensions;
    using CBE.Foundation.Theming.Extensions.Controls;
    using Sitecore.Mvc.Presentation;

    public static class RenderingExtensions
    {
        public static CarouselOptions GetCarouselOptions(this Rendering rendering)
        {
            return new CarouselOptions
            {
                ItemsShown = rendering.GetIntegerParameter(Constants.CarouselLayoutParameters.ItemsShown, 3),
                AutoPlay = rendering.GetIntegerParameter(Constants.CarouselLayoutParameters.Autoplay, 1) == 1,
                ShowNavigation = rendering.GetIntegerParameter(Constants.CarouselLayoutParameters.ShowNavigation) == 1
            };
        }

        public static string GetBackgroundClass(this Rendering rendering)
        {
            var id = Sitecore.MainUtil.GetID(rendering.Parameters[Constants.BackgroundLayoutParameters.Background] ?? "", null);
            if (ID.IsNullOrEmpty(id))
                return "";
            var item = rendering.RenderingItem.Database.GetItem(id);
            return item?[Templates.Style.Fields.Class] ?? "";
        }

        public static bool IsFixedHeight(this Rendering rendering)
        {
            var isFixed = Sitecore.MainUtil.GetBool(rendering.Parameters[Constants.IsFixedHeightLayoutParameters.FixedHeight] ?? "", false);
            return isFixed;
        }

        public static int GetHeight(this Rendering rendering)
        {
            return Sitecore.MainUtil.GetInt(rendering.Parameters[Constants.IsFixedHeightLayoutParameters.Height] ?? "", 0);
        }

        public static string GetContainerClass(this Rendering rendering)
        {
            return rendering.IsContainerFluid() ? "container-fluid" : "container";
        }

        public static bool IsContainerFluid(this Rendering rendering)
        {
            return Sitecore.MainUtil.GetBool(rendering.Parameters[Constants.HasContainerLayoutParameters.IsFluid], false);
        }

        public static BackgroundRendering RenderBackground(this Rendering rendering, HtmlHelper helper)
        {
            return new BackgroundRendering(helper.ViewContext.Writer, rendering.GetBackgroundClass());
        }
    }
}