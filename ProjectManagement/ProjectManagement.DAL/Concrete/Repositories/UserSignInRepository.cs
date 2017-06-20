using Microsoft.AspNet.Identity.Owin;
using ProjectManagement.DAL.Interface.DTO;
using ProjectManagement.DAL.Interface.Interfacies.IRepositories;
using ProjectManagement.DAL.Interface.Mappers;
using ProjectManagement.Identity.Managers;
using System.Threading.Tasks;

namespace ProjectManagement.DAL.Concrete.Repositories
{
    public class UserSignInRepository : IUserSignInRepository
    {
        private readonly ApplicationUserSignInManager _appUserSignInManager;

        public UserSignInRepository(ApplicationUserSignInManager appUserSignInManager)
        {
            _appUserSignInManager = appUserSignInManager;
        }

        public Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout)
        {
            return _appUserSignInManager.PasswordSignInAsync(userName, password, isPersistent, shouldLockout);
        }

        public Task SignInAsync(DalUser user, bool isPersistent, bool rememberBrowser)
        {
            return _appUserSignInManager.SignInAsync(user.ToDbUser(), isPersistent: false, rememberBrowser: false);
        }
    }
}
