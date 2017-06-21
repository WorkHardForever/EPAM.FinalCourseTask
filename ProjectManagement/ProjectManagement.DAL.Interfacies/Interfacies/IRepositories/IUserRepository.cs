using Microsoft.AspNet.Identity;
using ProjectManagement.DAL.Interface.DTO;
using System.Threading.Tasks;

namespace ProjectManagement.DAL.Interface.Interfacies.IRepositories
{
    public interface IUserRepository : IRepository<DalUser>
    {
        Task<IdentityResult> CreateAsync(DalUser user, string password);

        Task<IdentityResult> AddToRoleAsync(string userId, string role);

        Task<IdentityResult> AddToDefaultRoleAsync(string userId);

        Task<DalUser> FindByIdAsync(string userId);

        Task<DalUser> FindByEmail(string email);

        Task<DalUser> GetByIdWithProfile(string uniqueId);
    }
}
