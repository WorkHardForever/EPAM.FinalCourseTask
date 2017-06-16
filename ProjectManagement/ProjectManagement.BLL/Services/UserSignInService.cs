using Microsoft.AspNet.Identity.Owin;
using ProjectManagement.BLL.Interfacies.Entities;
using ProjectManagement.BLL.Interfacies.Interfacies.Services;
using ProjectManagement.BLL.Mappers;
using ProjectManagement.DAL.Interfacies.Interfacies;
using ProjectManagement.DAL.Interfacies.Interfacies.IRepositories;
using ProjectManagement.DAL.Mappers;
using System.Threading.Tasks;

namespace ProjectManagement.BLL.Services
{
    public class UserSignInService : IUserSignInService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserSignInRepository _userSignInManager;

        public UserSignInService(IUnitOfWork uow, IUserSignInRepository userSignInManager)
        {
            _uow = uow;
            _userSignInManager = userSignInManager;


            //    new ApplicationUserSignInManager<User>(
            //    new ApplicationUserManager<User>(new UserStore<User>(uow.Context)),
            //    HttpContext.Current.GetOwinContext().Authentication
            //);
        }
        
        public Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout)
        {
            return _userSignInManager.PasswordSignInAsync(userName, password, isPersistent, shouldLockout);
        }

        public System.Threading.Tasks.Task SignInAsync(BllUser user, bool isPersistent, bool rememberBrowser)
        {
            return _userSignInManager.SignInAsync(user.ToDalUser(), isPersistent: false, rememberBrowser: false);
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
