using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ProjectManagement.DAL.Interfacies.DTO;
using ProjectManagement.DAL.Interfacies.Interfacies.IRepositories;
using System.Data.Entity;

namespace ProjectManagement.DAL.Concrete.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DbContext _context;

        public PersonRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(DalPerson item)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalPerson item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalPerson> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalPerson GetById(int uniqueId)
        {
            throw new NotImplementedException();
        }

        public DalPerson GetByPredicate(Expression<Func<DalPerson, bool>> match)
        {
            throw new NotImplementedException();
        }

        public void Update(DalPerson item)
        {
            throw new NotImplementedException();
        }
    }
}
