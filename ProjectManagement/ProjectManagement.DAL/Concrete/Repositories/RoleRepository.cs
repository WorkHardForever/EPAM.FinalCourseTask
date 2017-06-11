using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ProjectManagement.DAL.Interfacies.DTO;
using ProjectManagement.DAL.Interfacies.Interfacies.IRepositories;

namespace ProjectManagement.DAL.Concrete.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public void AddUserToRole(DalUser user, DalRole role)
        {
            throw new NotImplementedException();
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

        public DalRole GetById(int uniqueId)
        {
            throw new NotImplementedException();
        }

        public DalRole GetByName(string roleName)
        {
            throw new NotImplementedException();
        }

        public DalRole GetByPredicate(Expression<Func<DalRole, bool>> match)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalUser> GetRoleUsers(DalRole role)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalRole> GetUserRoles(DalUser user)
        {
            throw new NotImplementedException();
        }

        public void RemoveUserFromRole(DalUser user, DalRole role)
        {
            throw new NotImplementedException();
        }

        public void Update(DalRole item)
        {
            throw new NotImplementedException();
        }
    }
}
