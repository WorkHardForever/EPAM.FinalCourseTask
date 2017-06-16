using Microsoft.AspNet.Identity;
using ProjectManagement.DAL.Interfacies.DTO;
using ProjectManagement.Identity.Managers;
using System.Threading.Tasks;

namespace ProjectManagement.DAL.Interfacies.Interfacies.IRepositories
{
    public interface IUserRepository
    {
        ApplicationUserManager AppUserManager { get; }

        Task<IdentityResult> CreateAsync(DalUser user, string password);
    }
}
