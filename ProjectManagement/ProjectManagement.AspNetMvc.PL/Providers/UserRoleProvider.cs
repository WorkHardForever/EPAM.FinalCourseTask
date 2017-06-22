using ProjectManagement.BLL.Interface.Interfacies.Services;
using System;
using System.Linq;
using System.Web.Security;

namespace ProjectManagement.AspNetMvc.PL.Providers
{
    public class UserRoleProvider : RoleProvider
    {
        //private IRoleService _roleService;

        //public UserRoleProvider(IRoleService _roleService)
        //{
        //    _roleService = _roleService;
        //}

        public override string ApplicationName { get; set; }

        public override bool IsUserInRole(string username, string roleName)
        {
            //if (_roleService.IsUserInRole(username, roleName))
            //    return true;

            //return false;
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            //return _roleService.GetUserRoles(username).Select(x => x.Name).ToArray();
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            //foreach (string username in usernames)
            //{
            //    foreach (string roleName in roleNames)
            //    {
            //        _roleService.AddUserInRole(username, roleName);
            //    }
            //}
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            //foreach (string username in usernames)
            //{
            //    foreach (string roleName in roleNames)
            //    {
            //        _roleService.RemoveUserFromRole(username, roleName);
            //    }
            //}
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            //return _roleService.GetUsersInRole(roleName).Select(x => x.Name).ToArray();
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            //return _roleService.GetAllRoles().Select(x => x.Name).ToArray();
            throw new NotImplementedException();
        }

        #region NotImplemented

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
