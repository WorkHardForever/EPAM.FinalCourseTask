using Microsoft.AspNet.Identity;
using ProjectManagement.BLL.Interfacies.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.BLL.Interfacies.Interfacies.Services
{
    public interface IUserService
    {
        Task<BllUser> FindByEmail(string email);

        Task<BllUser> FindByIdAsync(string userId);

        Task<IdentityResult> CreateAsync(BllUser user, string password);

        Task<IdentityResult> AddToDefaultRoleAsync(string userId);

        IEnumerable<string> GetEmployeesIdByUser(BllUser user);
    }
}
