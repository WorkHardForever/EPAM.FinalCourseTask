using Microsoft.AspNet.Identity;
using ProjectManagement.DAL.Interface.DTO;
using ProjectManagement.DAL.Interface.Interfacies.IRepositories;
using ProjectManagement.DAL.Interface.Mappers;
using ProjectManagement.Identity.Managers;
using System.Data.Entity;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectManagement.DAL.Concrete.Repositories
{
    public class UserRepository : IUserRepository
    {
        public static readonly string DefaultRole = "Default";

        private readonly DbContext _context;

        private readonly ApplicationUserManager _appUserManager;

        public UserRepository(DbContext context, ApplicationUserManager appUserManager)
        {
            _appUserManager = appUserManager;
            _context = context;
        }

        public Task<IdentityResult> CreateAsync(DalUser user, string password)
        {
            return _appUserManager.CreateAsync(user.ToDbUser(), password);
        }

        public Task<IdentityResult> AddToDefaultRoleAsync(string userId)
        {
            return AddToRoleAsync(userId, DefaultRole);
        }

        public Task<IdentityResult> AddToRoleAsync(string userId, string role)
        {
            return _appUserManager.AddToRoleAsync(userId, role);
        }

        public async Task<DalUser> FindByIdAsync(string userId)
        {
            var user = await _appUserManager.FindByIdAsync(userId);
            return user.ToDalUser();
        }

        public async Task<DalUser> FindByEmail(string email)
        {
            var user = await _appUserManager.FindByEmailAsync(email);
            return user.ToDalUser();
        }

        public IEnumerable<DalUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalUser GetById(string uniqueId)
        {
            throw new NotImplementedException();
        }

        public DalUser GetByPredicate(Expression<Func<DalUser, bool>> match)
        {
            throw new NotImplementedException();
        }

        public void Create(DalUser item)
        {
            _appUserManager.Create(item.ToDbUser(), item.PasswordHash);
        }

        public void Delete(DalUser item)
        {
            throw new NotImplementedException();
        }

        public void Update(DalUser item)
        {
            throw new NotImplementedException();
        }
    }
}
