using Microsoft.AspNet.Identity;
using ProjectManagement.BLL.Interface.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.BLL.Interface.Interfacies.Services
{
    public interface IUserService
    {
        Task<BllUser> FindByEmail(string email);

        Task<BllUser> FindByIdAsync(string userId);

        Task<IdentityResult> AddToDefaultRoleAsync(string userId);

        IEnumerable<string> GetEmployeesIdByUser(BllUser user);

        Task Create(BllUser item);

        Task<BllUser> GetByIdWithProfile(string uniqueId);
    }
}
