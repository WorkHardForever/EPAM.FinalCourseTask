using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ProjectManagement.DAL.Interface.DTO;
using ProjectManagement.DAL.Interface.Interfacies.IRepositories;
using ProjectManagement.Identity.Managers;

namespace ProjectManagement.DAL.Concrete.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationRoleManager _appRoleManager;

        public RoleRepository(ApplicationRoleManager appRoleManager)
        {
            _appRoleManager = appRoleManager;
        }

        public void Create(DalRole item)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalRole item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalRole> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalRole GetById(string uniqueId)
        {
            throw new NotImplementedException();
        }

        public DalRole GetByPredicate(Expression<Func<DalRole, bool>> match)
        {
            throw new NotImplementedException();
        }

        public void Update(DalRole item)
        {
            throw new NotImplementedException();
        }
    }
}
