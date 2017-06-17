using ProjectManagement.DAL.Interfacies.Interfacies.IRepositories;
using ProjectManagement.Identity.Managers;
using System;
using Microsoft.AspNet.Identity;
using ProjectManagement.DAL.Interfacies.DTO;
using System.Threading.Tasks;
using ProjectManagement.DAL.Mappers;

namespace ProjectManagement.DAL.Concrete.Repositories
{
    public class UserRepository : IUserRepository
    {
        public static readonly string DefaultRole = "Default";

        public ApplicationUserManager AppUserManager { get; private set; }

        public UserRepository(ApplicationUserManager appUserManager)
        {
            AppUserManager = appUserManager;
        }

        public Task<IdentityResult> CreateAsync(DalUser user, string password)
        {
            return AppUserManager.CreateAsync(user.ToDbUser(), password);
        }

        public Task<IdentityResult> AddToDefaultRoleAsync(string userId)
        {
            return AddToRoleAsync(userId, DefaultRole);
        }

        public Task<IdentityResult> AddToRoleAsync(string userId, string role)
        {
            return AppUserManager.AddToRoleAsync(userId, role);
        }
    }
}
