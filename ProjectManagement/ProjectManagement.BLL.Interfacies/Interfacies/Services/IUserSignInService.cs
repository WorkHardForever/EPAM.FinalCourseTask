using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using ProjectManagement.BLL.Interface.Entities;

namespace ProjectManagement.BLL.Interface.Interfacies.Services
{
    public interface IUserSignInService
    {
        Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout);

        Task SignInAsync(BllUser user, bool isPersistent, bool rememberBrowser);
    }
}
