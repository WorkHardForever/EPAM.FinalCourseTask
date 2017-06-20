using Microsoft.AspNet.Identity.Owin;
using ProjectManagement.BLL.Interface.Entities;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using ProjectManagement.BLL.Interface.Mappers;
using ProjectManagement.DAL.Interface.Interfacies;
using ProjectManagement.DAL.Interface.Interfacies.IRepositories;
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
