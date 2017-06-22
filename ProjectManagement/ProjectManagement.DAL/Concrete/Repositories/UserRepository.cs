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
    public class UserRepository : IUserRepository
    {
        public static readonly string DefaultRole = "Default";
        private readonly DbContext _context;

        public UserRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(DalUser item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _context.Set<User>().Add(item.ToDbUser());
        }

        public void Update(DalUser item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _context.Set<User>().AddOrUpdate(item.ToDbUser());
        }

        public void Delete(DalUser item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var task = _context.Set<User>().SingleOrDefault(u => u.Id == item.Id);
            if (task == null)
                throw new ArgumentException("Such id not found");

            _context.Set<User>().Remove(task);
        }

        public DalUser GetById(int uniqueId)
        {
            var task = _context.Set<User>().SingleOrDefault(u => u.Id == uniqueId);
            if (task == null)
                throw new ArgumentNullException(nameof(uniqueId));

            return task.ToDalUser();
        }

        public IEnumerable<DalUser> GetAll()
        {
            return _context.Set<User>().Select(task => task.ToDalUser());
        }

        public DalUser GetByPredicate(Expression<Func<DalUser, bool>> match)
        {
            throw new NotImplementedException();
        }

        public void AddToRole(string userId, string role)
        {
            throw new NotImplementedException();
        }

        public DalUser GetByLogin(string login)
        {
            return _context.Set<User>().SingleOrDefault(x => x.Login == login)?.ToDalUser();
        }
    }
}
