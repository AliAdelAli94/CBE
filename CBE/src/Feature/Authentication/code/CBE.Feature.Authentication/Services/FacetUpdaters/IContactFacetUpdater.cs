using Sitecore.Security;
using Sitecore.XConnect;
using System.Collections.Generic;

namespace CBE.Feature.Authentication.Services.FacetUpdaters
{
    public interface IContactFacetUpdater
    {
        IList<string> FacetsToUpdate { get; }
        bool SetFacets(UserProfile profile, Contact contact, IXdbContext client);
    }
}
