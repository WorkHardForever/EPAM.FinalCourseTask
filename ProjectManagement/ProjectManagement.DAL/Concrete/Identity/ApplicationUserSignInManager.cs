using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ProjectManagement.DAL.Interfacies.DTO;

namespace ProjectManagement.DAL.Concrete.Identity
{
    public class ApplicationUserSignInManager : SignInManager<DalUser, string>
    {
        public ApplicationUserSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        //public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        //{
        //    return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        //}

        //public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        //{
        //    return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        //}
    }
}
