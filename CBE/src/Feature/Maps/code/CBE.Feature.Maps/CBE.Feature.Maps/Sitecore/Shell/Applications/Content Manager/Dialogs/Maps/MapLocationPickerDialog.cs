namespace CBE.Feature.Maps.Sitecore.Shell.Applications.Content_Manager.Dialogs.Maps
{
    using global::Sitecore.Web;
    using global::Sitecore.Web.UI.HtmlControls;
    using global::Sitecore.Web.UI.Pages;
    using global::Sitecore.Web.UI.Sheer;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Web;

    [ExcludeFromCodeCoverage]
    public class MapLocationPickerDialog : DialogForm
    {
        #region Control

        public Edit TxtSelectedLocation;

        #endregion

        #region Control Event

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var value = WebUtil.GetQueryString("value");
            if (!string.IsNullOrWhiteSpace(value) && string.IsNullOrWhiteSpace(this.TxtSelectedLocation.Value))
            {
                this.TxtSelectedLocation.Value = value;
            }
        }

        protected override void OnOK(object sender, EventArgs args)
        {
            SheerResponse.SetDialogValue(this.TxtSelectedLocation.Value);
            base.OnOK(sender, args);
        }

        #endregion
    }
}