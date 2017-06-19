using Microsoft.AspNet.Identity;
using ProjectManagement.BLL.Interfacies.Entities;
using ProjectManagement.BLL.Interfacies.Interfacies.Services;
using ProjectManagement.BLL.Mappers;
using ProjectManagement.DAL.Interfacies.Interfacies;
using ProjectManagement.DAL.Interfacies.Interfacies.IRepositories;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace ProjectManagement.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserRepository _userManager;

        public UserService(IUnitOfWork uow, IUserRepository userManager)
        {
            _uow = uow;
            _userManager = userManager;
        }

        public Task<IdentityResult> CreateAsync(BllUser user, string password)
        {
            return _userManager.CreateAsync(user.ToDalUser(), password);
        }

        public Task<IdentityResult> AddToDefaultRoleAsync(string userId)
        {
            return _userManager.AddToDefaultRoleAsync(userId);
        }

        public async Task<BllUser> FindByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user.ToBllUser();
        }

        public async Task<BllUser> FindByEmail(string email)
        {
            var user = await _userManager.FindByEmail(email);
            return user.ToBllUser();
        }

        public IEnumerable<string> GetEmployeesIdByUser(BllUser user)
        {
            throw new NotImplementedException();
        }
    }
}
