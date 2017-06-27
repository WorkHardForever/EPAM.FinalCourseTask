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

            var user = _context.Set<User>().SingleOrDefault(u => u.Id == item.Id);
            if (user == null)
                throw new ArgumentException("Such id not found");

            _context.Set<User>().Remove(user);
        }

        public DalUser GetById(int uniqueId)
        {
            var user = _context.Set<User>().SingleOrDefault(u => u.Id == uniqueId);
            if (user == null)
                throw new ArgumentNullException(nameof(uniqueId));

            return user.ToDalUser();
        }

        public IEnumerable<DalUser> GetAll()
        {
            return _context.Set<User>().Select(ToDalUserConvertion);
        }

        public static Expression<Func<User, DalUser>> ToDalUserConvertion
        {
            get
            {
                return (User user) => new DalUser()
                {
                    Id = user.Id,
                    Login = user.Login
                };
            }
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
            var user = _context.Set<User>().SingleOrDefault(u => u.Login == login);
            if (user == null)
                throw new ArgumentNullException(nameof(login));

            return user.ToDalUser();
        }

        public bool IsUserLoginExist(string login)
        {
            var user = _context.Set<User>().FirstOrDefault(u => u.Login == login);
            return user != null;
        }
    }
}