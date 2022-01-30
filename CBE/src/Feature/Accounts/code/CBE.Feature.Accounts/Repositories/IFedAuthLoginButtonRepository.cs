using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBE.Feature.Accounts.Repositories
{
    using CBE.Feature.Accounts.Models;

    public interface IFedAuthLoginButtonRepository
    {
        IEnumerable<FedAuthLoginButton> GetAll();
    }
}