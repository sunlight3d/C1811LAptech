using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bai01.App_Start
{
    public class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            var options = new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            };
            app.UseCookieAuthentication(options);

        }
    }
}