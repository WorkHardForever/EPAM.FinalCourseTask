using ProjectManagement.DAL.Interfacies.DTO;
using ProjectManagement.DAL.Interfacies.Interfacies.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;

namespace ProjectManagement.DAL.Concrete.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context;

        public UserRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(DalUser item)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalUser item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalUser GetById(int uniqueId)
        {
            throw new NotImplementedException();
        }

        public DalUser GetByPredicate(Expression<Func<DalUser, bool>> match)
        {
            throw new NotImplementedException();
        }

        public void Update(DalUser item)
        {
            throw new NotImplementedException();
        }
    }
}
