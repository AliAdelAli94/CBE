namespace CBE.Feature.Authentication.Services.FacetUpdaters
{
    using System.Collections.Generic;
    using Sitecore.Security;
    using Sitecore.XConnect;
    using Sitecore.XConnect.Collection.Model;

    public class PhoneFacetUpdater : IContactFacetUpdater
    {
        public IList<string> FacetsToUpdate => new[] { PhoneNumberList.DefaultFacetKey };

        public bool SetFacets(UserProfile profile, Contact contact, IXdbContext client)
        {
            var phoneNumber = profile[Authentication.Constants.UserProfile.Fields.mobile];
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return false;
            }
            var phoneNumbers = contact.GetFacet<PhoneNumberList>(PhoneNumberList.DefaultFacetKey);
            if (phoneNumbers == null)
            {
                phoneNumbers = new PhoneNumberList(new PhoneNumber(null, phoneNumber), null);
            }
            else
            {
                if (phoneNumbers.PreferredPhoneNumber?.Number == phoneNumber)
                {
                    return false;
                }
                phoneNumbers.PreferredPhoneNumber = new PhoneNumber(null, phoneNumber);
            }
            client.SetFacet(contact, PhoneNumberList.DefaultFacetKey, phoneNumbers);
            return true;
        }
    }
}