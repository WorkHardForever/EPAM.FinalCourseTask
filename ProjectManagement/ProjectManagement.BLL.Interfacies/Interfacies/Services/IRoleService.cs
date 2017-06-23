using ProjectManagement.BLL.Interface.Entities;
using System.Collections.Generic;

namespace ProjectManagement.BLL.Interface.Interfacies.Services
{
    public interface IRoleService
    {
        bool IsUserInRole(string username, string roleName);

        IEnumerable<BllRole> GetUserRoles(string username);

        IEnumerable<BllRole> GetAll();

        IEnumerable<BllUser> GetUsersInRole(string roleName);

        void AddUserByName(string username, string roleName);

        void RemoveUserByName(string username, string roleName);

        void CreateByName(string roleName);

        void DeleteByName(string roleName);

        bool IsExistByName(string roleName);
    }
}
