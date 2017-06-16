using Microsoft.AspNet.Identity.Owin;
using ProjectManagement.DAL.Interfacies.DTO;
using ProjectManagement.DAL.Interfacies.Interfacies.IRepositories;
using ProjectManagement.DAL.Mappers;
using ProjectManagement.Identity.Managers;
using System.Threading.Tasks;

namespace ProjectManagement.DAL.Concrete.Repositories
{
    public class UserSignInRepository : IUserSignInRepository
    {
        public ApplicationUserSignInManager AppUserSignInManager { get; private set; }

        public UserSignInRepository(ApplicationUserSignInManager appUserSignInManager)
        {
            AppUserSignInManager = appUserSignInManager;
        }

        public Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout)
        {
            return AppUserSignInManager.PasswordSignInAsync(userName, password, isPersistent, shouldLockout);
        }

        public Task SignInAsync(DalUser user, bool isPersistent, bool rememberBrowser)
        {
            return AppUserSignInManager.SignInAsync(user.ToDbUser(), isPersistent: false, rememberBrowser: false);
        }
    }
}
