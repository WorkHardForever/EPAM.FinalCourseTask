﻿using Microsoft.Owin;
using Owin;
//using ProjectManagement.Identity.Settings.StartConfig;

[assembly: OwinStartup(typeof(ProjectManagement.AspNetMvc.PL.Startup))]
namespace ProjectManagement.AspNetMvc.PL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
