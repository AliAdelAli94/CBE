namespace CBE.Foundation.Accounts.Providers
{
    using Sitecore.Analytics.Tracking;
    using Sitecore.XConnect.Collection.Model;

    public interface IContactFacetsProvider
    {
        Contact Contact { get; }
        Sitecore.XConnect.Collection.Model.KeyBehaviorCache KeyBehaviorCache { get; }
        PersonalInformation PersonalInfo { get; }
        AddressList Addresses { get; }
        EmailAddressList Emails { get; }
        ConsentInformation CommunicationProfile { get; }
        PhoneNumberList PhoneNumbers { get; }
        Avatar Picture { get; }
        bool IsKnown { get; }
    }
}