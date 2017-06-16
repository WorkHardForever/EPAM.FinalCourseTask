using Microsoft.AspNet.Identity.Owin;
using ProjectManagement.DAL.Interfacies.DTO;
using ProjectManagement.Identity.Managers;
using System.Threading.Tasks;

namespace ProjectManagement.DAL.Interfacies.Interfacies.IRepositories
{
    public interface IUserSignInRepository
    {
        ApplicationUserSignInManager AppUserSignInManager { get; }

        Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout);

        Task SignInAsync(DalUser user, bool isPersistent, bool rememberBrowser);
    }
}
