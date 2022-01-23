﻿using Sitecore.Diagnostics;
using System.Web;

namespace CBE.Foundation.SitecoreExtensions.Extensions
{
    public static class SessionExtensions
    {
        public static object GetAndRemove(this HttpSessionStateBase session, string key)
        {
            Assert.ArgumentNotNull(session, nameof(session));
            Assert.ArgumentNotNullOrEmpty(key, nameof(key));

            var sessionItem = session[key];
            session.Remove(key);

            return sessionItem;
        }

    }
}