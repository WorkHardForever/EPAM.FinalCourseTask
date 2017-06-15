using ProjectManagement.DAL.Concrete.Identity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using ProjectManagement.BLL.Interfacies.Entities;
using ProjectManagement.ORM.Entities;

namespace ProjectManagement.BLL.Interfacies.Interfacies.Services
{
    public interface IUserSignInService
    {
        Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout);

        System.Threading.Tasks.Task SignInAsync(BllUser user, bool isPersistent, bool rememberBrowser);
    }
}
