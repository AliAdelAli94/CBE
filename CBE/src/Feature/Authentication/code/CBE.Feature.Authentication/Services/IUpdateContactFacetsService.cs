using Sitecore.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBE.Feature.Authentication.Services
{
    public interface IUpdateContactFacetsService
    {
        void UpdateContactFacets(UserProfile profile);
    }
}