using ProjectManagement.DAL.Interfacies.DTO;
using System.Collections.Generic;

namespace ProjectManagement.DAL.Interfacies.Interfacies.IRepositories
{
    public interface IRoleRepository : IRepository<DalRole>
    {
        DalRole GetByName(string roleName);

        IEnumerable<DalRole> GetUserRoles(DalUser user);

        IEnumerable<DalUser> GetRoleUsers(DalRole role);

        void AddUserToRole(DalUser user, DalRole role);

        void RemoveUserFromRole(DalUser user, DalRole role);
    }
}
