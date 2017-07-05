using ProjectManagement.DAL.Interface.DTO;
using ProjectManagement.DAL.Interface.Interfacies.IRepositories;
using ProjectManagement.DAL.Mappers;
using ProjectManagement.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

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
            _context.Set<User>().Add(item.ToDbUser());
        }

        public void Update(DalUser item)
        {
            _context.Set<User>().AddOrUpdate(item.ToDbUser());
        }

        public void Delete(DalUser item)
        {
            var user = _context.Set<User>().SingleOrDefault(u => u.Id == item.Id);
            if (user == null)
                throw new ArgumentException("Such user id was not found");

            _context.Set<User>().Remove(user);
        }

        public DalUser GetById(int uniqueId)
        {
            var user = _context.Set<User>().SingleOrDefault(u => u.Id == uniqueId);
            if (user == null)
                return null;

            return user.ToDalUser();
        }

        public IEnumerable<DalUser> GetAll()
        {
            return _context.Set<User>().Select(UserMapper.ExpressionToDalUser);
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
