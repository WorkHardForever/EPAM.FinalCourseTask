using ProjectManagement.DAL.Interface.DTO;
using ProjectManagement.DAL.Interface.Interfacies.IRepositories;
using ProjectManagement.DAL.Mappers;
using ProjectManagement.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace ProjectManagement.DAL.Concrete.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext _context;

        public RoleRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(DalRole item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var role = _context.Set<Role>().SingleOrDefault(u => u.Name == item.Name);
            if (role != null)
                throw new ArgumentException("Such role exist yet.");

            _context.Set<Role>().Add(item.ToDbRole());
        }

        public void Update(DalRole item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _context.Set<Role>().AddOrUpdate(item.ToDbRole());
        }

        public void Delete(DalRole item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var role = _context.Set<Role>().SingleOrDefault(u => u.Name == item.Name);
            if (role == null)
                throw new ArgumentException("Such name was not found.");

            _context.Set<Role>().Remove(role);
        }

        public DalRole GetById(int uniqueId)
        {
            var role = _context.Set<Role>().SingleOrDefault(u => u.Id == uniqueId);
            if (role == null)
                throw new ArgumentNullException(nameof(uniqueId));

            return role.ToDalRole();
        }

        public IEnumerable<DalRole> GetAll()
        {
            return _context.Set<Role>().Select(role => role.ToDalRole());
        }

        public DalRole GetByPredicate(Expression<Func<DalRole, bool>> match)
        {
            throw new NotImplementedException();
        }

        public bool IsUserInRole(DalUser user, string roleName)
        {
            return user.Roles.FirstOrDefault(x => x.Name == roleName) != null;
        }

        public IEnumerable<DalRole> GetUserRoles(DalUser user)
        {
            return _context.Set<User>().SingleOrDefault(x => x.Id == user.Id).Roles.ToDalRoleEnumerable();
        }

        public DalRole GetByName(string roleName)
        {
            var role = _context.Set<Role>().SingleOrDefault(u => u.Name == roleName);
            if (role == null)
                throw new ArgumentNullException(nameof(roleName));

            return role.ToDalRole();
        }

        public void AddUser(DalUser user, DalRole role)
        {
            var dbUser = _context.Set<User>().FirstOrDefault(x => x.Login == user.Login);
            if (dbUser == null)
                throw new ArgumentException($"User '{user.Login}' not found.");

            var dbRole = _context.Set<Role>().FirstOrDefault(x => x.Name == role.Name);
            if (dbRole == null)
                throw new ArgumentException($"Role '{role.Name}' not found.");

            dbRole.Users.Add(dbUser);
        }
    }
}