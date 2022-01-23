namespace CBE.Feature.Authentication.Services
{
    using System;
    using System.Net.Mail;
    using Sitecore.Data;
    using Sitecore.Data.Items;

    public interface IAccountsSettingsService
    {
        string GetPageLink(Item contextItem, ID fieldID);
        MailMessage GetForgotPasswordMailTemplate();
        MailMessage GetActiveAccountTemplate();
        string GetPageLinkOrDefault(Item contextItem, ID field, Item defaultItem = null);
        Guid? GetRegistrationOutcome(Item contextItem);
        ID GetActiveAccountTemplateID();
        ID GetActiveOrganizationAccountTemplateID();
        ID GetForgotPasswordMailTemplateID();
        ID GetActiveEmailChangingTemplateID();
        ID GetSPInitiatedSSOTemplateID();
        ID GetSendOTPTemplateMailTemplateID();
        ID GetSendOTPTemplateSMSTemplateID();
        ID GetDeactivateRepresentativeTemplateID();

    }
}