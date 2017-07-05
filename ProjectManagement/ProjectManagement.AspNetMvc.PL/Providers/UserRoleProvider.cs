using ProjectManagement.BLL.Interface.Entities;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using ProjectManagement.BLL.Services;
using System;
using System.Linq;
using System.Web.Security;

namespace ProjectManagement.AspNetMvc.PL.Providers
{
    public class UserRoleProvider : RoleProvider
    {
        // Exist for config initialization
        public UserRoleProvider()
        {

        }

        public override bool IsUserInRole(string username, string roleName)
        {
            IRoleService _roleService =
                (RoleService) System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleService));
            return _roleService.IsUserInRole(username, roleName);
        }

        public override string[] GetUsersInRole(string roleName)
        {
            IRoleService _roleService =
                (RoleService) System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleService));
            return
                _roleService.GetUsersInRole(roleName).Select(x => x.Login).ToArray();
        }

        public override string[] GetRolesForUser(string username)
        {
            IRoleService _roleService =
                (RoleService) System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleService));
            return
                _roleService.GetUserRoles(username).Select(x => x.Name).ToArray();
        }

        public override string[] GetAllRoles()
        {
            IRoleService _roleService =
                (RoleService) System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleService));
            return
                _roleService.GetAll().Select(x => x.Name).ToArray();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            IRoleService _roleService =
                (RoleService) System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleService));
            foreach (string username in usernames)
            {
                foreach (string roleName in roleNames)
                {
                    _roleService.AddUserByName(username, roleName);
                }
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            IRoleService _roleService =
                (RoleService) System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleService));
            foreach (string username in usernames)
            {
                foreach (string roleName in roleNames)
                {
                    _roleService.RemoveUserByName(username, roleName);
                }
            }
        }

        public override void CreateRole(string roleName)
        {
            IRoleService _roleService =
                (RoleService) System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleService));

            _roleService.Create(new BllRole() { Name = roleName });
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            IRoleService _roleService =
                (RoleService) System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleService));
            _roleService.Delete(new BllRole() { Name = roleName });
            return true;
        }

        #region Not Implemented

        public override string ApplicationName { get; set; }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}