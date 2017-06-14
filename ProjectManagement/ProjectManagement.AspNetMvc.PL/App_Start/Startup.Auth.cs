using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using ProjectManagement.DependencyResolver.Resolver;

namespace ProjectManagement.AspNetMvc.PL
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.StartupConfig();
        }
    }
}
