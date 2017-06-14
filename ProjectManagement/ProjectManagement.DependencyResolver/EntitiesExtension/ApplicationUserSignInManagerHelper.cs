using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using ProjectManagement.DAL.Concrete.Identity;

namespace ProjectManagement.DependencyResolver.EntitiesExtension
{
    public static class ApplicationUserSignInManagerHelper
    {
        public static ApplicationUserSignInManager Create(IdentityFactoryOptions<ApplicationUserSignInManager> options, IOwinContext context)
        {
            return new ApplicationUserSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
