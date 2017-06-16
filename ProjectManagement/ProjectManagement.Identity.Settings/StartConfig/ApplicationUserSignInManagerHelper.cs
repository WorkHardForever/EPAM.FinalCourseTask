using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using ProjectManagement.Identity.Managers;

namespace ProjectManagement.Identity.Settings.StartConfig
{
    public static class ApplicationUserSignInManagerHelper
    {
        public static ApplicationUserSignInManager Create(IdentityFactoryOptions<ApplicationUserSignInManager> options, IOwinContext context)
        {
            return new ApplicationUserSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
