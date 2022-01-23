namespace CBE.Feature.Authentication.Services
{
    using CBE.Foundation.SitecoreExtensions.Extensions;
    using Sitecore.Data;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Diagnostics;
    using Sitecore.Exceptions;
    using System;
    using System.Net.Mail;

    public class AccountsSettingsService : IAccountsSettingsService
    {
        public static readonly string PageNotFoundUrl = "";// SettingsResources.PageNotFound;
        public static AccountsSettingsService Instance => new AccountsSettingsService();

        public virtual string GetPageLink(Item contextItem, ID fieldID)
        {
            var item = this.GetAccountsSettingsItem(contextItem);
            if (item == null)
            {
                throw new Exception("Page with accounts settings isn't specified");
            }

            InternalLinkField link = item.Fields[fieldID];
            if (link.TargetItem == null)
            {
                throw new Exception($"{link.InnerField.Name} link isn't set");
            }

            return link.TargetItem.Url();
        }


        public virtual string GetPageLinkOrDefault(Item contextItem, ID field, Item defaultItem = null)
        {
            try
            {
                return this.GetPageLink(contextItem, field);
            }
            catch (Exception ex)
            {
                //DatabaseLogger.Error(ex);
                Log.Warn(ex.Message, ex, this);
                return defaultItem?.Url() ?? PageNotFoundUrl;
            }
        }

        public virtual Guid? GetRegistrationOutcome(Item contextItem)
        {
            var item = this.GetAccountsSettingsItem(contextItem);

            if (item == null)
            {
                throw new ItemNotFoundException("Page with accounts settings isn't specified");
            }

            ReferenceField field = item.Fields[Templates.AccountsSettings.Fields.RegisterOutcome];
            return field?.TargetID?.ToGuid();
        }

        public MailMessage GetForgotPasswordMailTemplate()
        {
            var settingsItem = this.GetAccountsSettingsItem(null);
            InternalLinkField link = settingsItem.Fields[Templates.AccountsSettings.Fields.ForgotPasswordMailTemplate];
            var mailTemplateItem = link.TargetItem;

            if (mailTemplateItem == null)
            {
                throw new ItemNotFoundException($"Could not find mail template item with {link.TargetID} ID");
            }

            var fromMail = mailTemplateItem.Fields[Templates.MailTemplate.Fields.From];

            if (string.IsNullOrEmpty(fromMail.Value))
            {
                throw new InvalidValueException("'From' field in mail template should be set");
            }

            var body = mailTemplateItem.Fields[Templates.MailTemplate.Fields.Body];
            var subject = mailTemplateItem.Fields[Templates.MailTemplate.Fields.Subject];

            return new MailMessage
            {
                From = new MailAddress(fromMail.Value),
                Body = body.Value,
                Subject = subject.Value
            };
        }
        public ID GetForgotPasswordMailTemplateID()
        {
            var settingsItem = this.GetAccountsSettingsItem(null);
            InternalLinkField link = settingsItem.Fields[Templates.AccountsSettings.Fields.ForgotPasswordMailTemplate];

            return link.TargetID;
        }
        public ID GetSendOTPTemplateMailTemplateID()
        {
            var settingsItem = this.GetAccountsSettingsItem(null);
            InternalLinkField link = settingsItem.Fields[Templates.AccountsSettings.Fields.SendOTPTemplate];

            return link.TargetID;
        }
        public ID GetSendOTPTemplateSMSTemplateID()
        {
            var settingsItem = this.GetAccountsSettingsItem(null);
            InternalLinkField link = settingsItem.Fields[Templates.AccountsSettings.Fields.SendSMSOTPTemplate];

            return link.TargetID;
        }
        public MailMessage GetActiveAccountTemplate()
        {
            var settingsItem = this.GetAccountsSettingsItem(null);
            InternalLinkField link = settingsItem.Fields[Templates.AccountsSettings.Fields.ActiveAccountTemplate];
            var mailTemplateItem = link.TargetItem;

            if (mailTemplateItem == null)
            {
                throw new ItemNotFoundException($"Could not find mail template item with {link.TargetID} ID");
            }

            var fromMail = mailTemplateItem.Fields[Templates.MailTemplate.Fields.From];

            if (string.IsNullOrEmpty(fromMail.Value))
            {
                throw new InvalidValueException("'From' field in mail template should be set");
            }

            var body = mailTemplateItem.Fields[Templates.MailTemplate.Fields.Body];
            var subject = mailTemplateItem.Fields[Templates.MailTemplate.Fields.Subject];

            return new MailMessage
            {
                From = new MailAddress(fromMail.Value),
                Body = body.Value,
                Subject = subject.Value
            };
        }

        public ID GetActiveAccountTemplateID()
        {
            var settingsItem = this.GetAccountsSettingsItem(null);
            InternalLinkField link = settingsItem.Fields[Templates.AccountsSettings.Fields.ActiveAccountTemplate];

            return link.TargetID;

        }
        public ID GetActiveOrganizationAccountTemplateID()
        {
            var settingsItem = this.GetAccountsSettingsItem(null);
            InternalLinkField link = settingsItem.Fields[Templates.AccountsSettings.Fields.ActiveOrganizationAccountTemplate];
            return link.TargetID;
        }
        public ID GetSPInitiatedSSOTemplateID()
        {
            var settingsItem = this.GetAccountsSettingsItem(null);
            InternalLinkField link = settingsItem.Fields[Templates.AccountsSettings.Fields.spinitiatedsso];

            return link.TargetID;

        }
        public ID GetActiveEmailChangingTemplateID()
        {
            var settingsItem = this.GetAccountsSettingsItem(null);
            InternalLinkField link = settingsItem.Fields[Templates.AccountsSettings.Fields.ChangeEmailMailTemplate];

            return link.TargetID;
        }
        public virtual Item GetAccountsSettingsItem(Item contextItem)
        {
            Item item = null;

            if (contextItem != null)
            {
                item = contextItem.GetAncestorOrSelfOfTemplate(Templates.AccountsSettings.ID);
            }
            item = item ?? Sitecore.Context.Site.GetContextItem(Templates.AccountsSettings.ID);

            return item;
        }

        public ID GetDeactivateRepresentativeTemplateID()
        {
            var settingsItem = this.GetAccountsSettingsItem(null);
            InternalLinkField link = settingsItem.Fields[Templates.AccountsSettings.Fields.DeactivateRepresentativeTemplate];
            return link.TargetID;
        }
    }
}