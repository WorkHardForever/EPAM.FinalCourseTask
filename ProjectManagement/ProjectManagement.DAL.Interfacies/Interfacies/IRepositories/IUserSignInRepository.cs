using Microsoft.AspNet.Identity.Owin;
using ProjectManagement.DAL.Interface.DTO;
using System.Threading.Tasks;

namespace ProjectManagement.DAL.Interface.Interfacies.IRepositories
{
    public interface IUserSignInRepository
    {
        Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout);

        Task SignInAsync(DalUser user, bool isPersistent, bool rememberBrowser);
    }
}
