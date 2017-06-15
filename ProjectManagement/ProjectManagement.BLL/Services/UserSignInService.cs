using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using ProjectManagement.BLL.Interfacies.Entities;
using ProjectManagement.BLL.Interfacies.Interfacies.Services;
using ProjectManagement.BLL.Mappers;
using ProjectManagement.DAL.Concrete.Identity;
using ProjectManagement.DAL.Interfacies.DTO;
using ProjectManagement.DAL.Interfacies.Interfacies;
using ProjectManagement.DAL.Mappers;
using ProjectManagement.ORM.Entities;
using System.Threading.Tasks;
using System.Web;

namespace ProjectManagement.BLL.Services
{
    public class UserSignInService : IUserSignInService
    {
        private readonly IUnitOfWork _uow;
        private readonly ApplicationUserSignInManager _userSignInManager;

        public UserSignInService(IUnitOfWork uow)
        {
            _uow = uow;
            _userSignInManager = new ApplicationUserSignInManager(new ApplicationUserManager(new UserStore<User>(uow.Context)), HttpContext.Current.GetOwinContext().Authentication);
        }
        
        public Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout)
        {
            return _userSignInManager.PasswordSignInAsync(userName, password, isPersistent, shouldLockout);
        }

        public System.Threading.Tasks.Task SignInAsync(BllUser user, bool isPersistent, bool rememberBrowser)
        {
            return _userSignInManager.SignInAsync(user.ToDalUser().ToDbUser(), isPersistent: false, rememberBrowser: false);
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
