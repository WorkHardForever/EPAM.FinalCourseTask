using ProjectManagement.DAL.Interface.DTO;
using System.Collections.Generic;

namespace ProjectManagement.DAL.Interface.Interfacies.IRepositories
{
    public interface IRoleRepository : IRepository<DalRole>
    {
        bool IsUserInRole(DalUser user, string roleName);

        IEnumerable<DalRole> GetUserRoles(DalUser user);

        DalRole GetByName(string roleName);

        void AddUser(DalUser user, DalRole role);
    }
}
