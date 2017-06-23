using ProjectManagement.BLL.Interface.Interfacies.Services;
using ProjectManagement.BLL.Services;
using System;
using System.Linq;
using System.Web.Security;

namespace ProjectManagement.AspNetMvc.PL.Providers
{
    public class UserRoleProvider : RoleProvider
    {
        //private IRoleService _roleService;

        //private readonly IUserService _userService = (UserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(UserService));
        //private readonly IRoleService _roleService = (RoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleService));

        // Exist for config initialization
        public UserRoleProvider() { }

        public UserRoleProvider(IRoleService roleService)
        {
            IRoleService _roleService = (RoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleService));
            _roleService = roleService;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            IRoleService _roleService = (RoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleService));
            return _roleService.IsUserInRole(username, roleName);
        }

        public override string[] GetUsersInRole(string roleName)
        {
            IRoleService _roleService = (RoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleService));
            return
            _roleService.GetUsersInRole(roleName).Select(x => x.Login).ToArray();
        }

        public override string[] GetRolesForUser(string username)
        {
            IRoleService _roleService = (RoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleService));
            return
            _roleService.GetUserRoles(username).Select(x => x.Name).ToArray();
        }

        public override string[] GetAllRoles()
        {
            IRoleService _roleService = (RoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleService));
            return
            _roleService.GetAll().Select(x => x.Name).ToArray();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            IRoleService _roleService = (RoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleService));
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
            IRoleService _roleService = (RoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleService));
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
            IRoleService _roleService = (RoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleService));
            
            _roleService.CreateByName(roleName);
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            IRoleService _roleService = (RoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleService));
            _roleService.DeleteByName(roleName);
            return true;
        }

        public override bool RoleExists(string roleName)
        {
            IRoleService _roleService = (RoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleService));
            return
            _roleService.IsExistByName(roleName);
        }

        #region Not Implemented

        public override string ApplicationName { get; set; }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
