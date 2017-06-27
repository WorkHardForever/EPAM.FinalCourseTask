using ProjectManagement.BLL.Interface.Entities;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using ProjectManagement.BLL.Mappers;
using ProjectManagement.DAL.Interface.DTO;
using ProjectManagement.DAL.Interface.Interfacies;
using ProjectManagement.DAL.Interface.Interfacies.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;

        public static readonly string DefaultRole = "default";

        public RoleService(IUnitOfWork uow, IRoleRepository roleRepository, IUserRepository userRepository)
        {
            _uow = uow;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        public bool IsUserInRole(string username, string roleName)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(nameof(username));

            if (string.IsNullOrEmpty(roleName))
                throw new ArgumentNullException(nameof(roleName));

            var user = _userRepository.GetByLogin(username);
            if (user == null)
                throw new ArgumentException($"User with name '{username}' was not found");

            return _roleRepository.IsUserInRole(user, roleName);
        }

        public IEnumerable<BllRole> GetUserRoles(string username)
        {
            if (username == null)
                throw new ArgumentNullException(nameof(username));

            var user = _userRepository.GetByLogin(username);
            if (user == null)
                throw new ArgumentException(String.Format("User name={0} not found", username));

            return _roleRepository.GetUserRoles(user).ToList().Select(x => x.ToBllRole());
        }

        public IEnumerable<BllRole> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BllUser> GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public void AddUserByName(string username, string roleName)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(nameof(username));

            if (string.IsNullOrEmpty(roleName))
                throw new ArgumentNullException(nameof(roleName));

            var role = _roleRepository.GetByName(roleName);
            var user = _userRepository.GetByLogin(username);

            _roleRepository.AddUser(user, role);
            _uow.Commit();
        }

        public void RemoveUserByName(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public void CreateByName(string roleName)
        {
            _roleRepository.Create(new DalRole() {Name = roleName});
            _uow.Commit();
        }

        public void DeleteByName(string roleName)
        {
            _roleRepository.Delete(new DalRole() {Name = roleName});
            _uow.Commit();
        }

        public bool IsExistByName(string roleName)
        {
            throw new NotImplementedException();
        }


        //#region Public Methods

        ///// <summary>
        ///// Return true if user with username is in role with roleName.
        ///// </summary>
        ///// <param name="username">username of user.</param>
        ///// <param name="roleName">name of role.</param>
        ///// <returns>true if user with username is in role with roleName.</returns>
        //public bool IsUserInRole(string username, string roleName)
        //{
        //    if (username == null) throw new ArgumentNullException("username");
        //    if (roleName == null) throw new ArgumentNullException("roleName");

        //    DalUser user = userRepository.GetByName(username);
        //    if (user == null)
        //        throw new ArgumentException(String.Format("User name={0} not found", username));

        //    return roleRepository.GetUserRoles(user).Count(x => x.Name == roleName) != 0;
        //}

        ///// <summary>
        ///// Get all roles for user.
        ///// </summary>
        ///// <param name="username">username for user.</param>
        ///// <returns>IEnumerable of all user's roles.</returns>
        //public IEnumerable<BllRole> GetUserRoles(string username)
        //{
        //    if (username == null) throw new ArgumentNullException("username");
        //    logger.Log(LogLevel.Trace, "RoleService.GetUserRoles invoked username = {0}", username);

        //    DalUser user = userRepository.GetByName(username);
        //    if (user == null)
        //        throw new ArgumentException(String.Format("User name={0} not found", username));

        //    return roleRepository.GetUserRoles(user).ToList().Select(x => x.ToBllRole());
        //}

        ///// <summary>
        ///// Add role to user's roles.
        ///// </summary>
        ///// <param name="username">username of user.</param>
        ///// <param name="roleName">role name.</param>
        //public void AddUserInRole(string username, string roleName)
        //{
        //    if (username == null) throw new ArgumentNullException("username");
        //    if (roleName == null) throw new ArgumentNullException("roleName");
        //    logger.Log(LogLevel.Trace, "RoleService.AddUserInRole invoked username = {0}, roleName = {1}",
        //        username, roleName);

        //    DalRole role = roleRepository.GetByName(roleName);
        //    if (role == null)
        //        throw new ArgumentException(String.Format("Role name={0} not found", roleName));
        //    DalUser user = userRepository.GetByName(username);
        //    if (user == null)
        //        throw new ArgumentException(String.Format("User name={0} not found", username));

        //    roleRepository.AddUserToRole(user, role);
        //    uow.Commit();
        //}

        ///// <summary>
        ///// Remove role from user's roles list.
        ///// </summary>
        ///// <param name="username">username of user.</param>
        ///// <param name="roleName">role name.</param>
        //public void RemoveUserFromRole(string username, string roleName)
        //{
        //    logger.Log(LogLevel.Trace, "RoleService.RemoveUserFromRole invoked username = {0}, roleName = {1}",
        //        username, roleName);

        //    DalRole role = roleRepository.GetByName(roleName);
        //    if (role == null)
        //        throw new ArgumentException(String.Format("Role name={0} not found", roleName));
        //    DalUser user = userRepository.GetByName(username);
        //    if (user == null)
        //        throw new ArgumentException(String.Format("User name={0} not found", username));

        //    roleRepository.RemoveUserFromRole(user, role);
        //    uow.Commit();
        //}

        ///// <summary>
        ///// Set for user new list of roles.
        ///// </summary>
        ///// <param name="username">username of user.</param>
        ///// <param name="rolesIds">collection of new user's roles.</param>
        //public void UpdateUserRoles(string username, IEnumerable<int> rolesIds)
        //{
        //    if (username == null) throw new ArgumentNullException("username");
        //    if (rolesIds == null) throw new ArgumentNullException("rolesIds");
        //    logger.Log(LogLevel.Trace, "RoleService.UpdateUserRoles invoked username = {0}", username);

        //    DalUser user = userRepository.GetByName(username);
        //    if (user == null)
        //        throw new ArgumentException(String.Format("User name={0} not found", username));

        //    RemoveUserFromRoles(user, rolesIds);
        //    user = userRepository.GetByName(username);
        //    AddUserInewRoles(user, rolesIds);
        //}

        ///// <summary>
        ///// Get all users in role.
        ///// </summary>
        ///// <param name="roleName">role name</param>
        ///// <returns>IEnumerable of all users in role.</returns>
        //public IEnumerable<BllUser> GetUsersInRole(string roleName)
        //{
        //    if (roleName == null) throw new ArgumentNullException("roleName");
        //    logger.Log(LogLevel.Trace, "RoleService.GetUsersInRole invoked roleName = {0}", roleName);

        //    DalRole role = roleRepository.GetByName(roleName);
        //    if (role == null)
        //        throw new ArgumentException(String.Format("Role name={0} not found", roleName));

        //    return roleRepository.GetRoleUsers(role).ToList().Select(x => x.ToBllUser());
        //}

        ///// <summary>
        ///// Get all roles from storage.
        ///// </summary>
        ///// <returns>IEnumerable of all roles.</returns>
        //public IEnumerable<BllRole> GetAllRoles()
        //{
        //    logger.Log(LogLevel.Trace, "RoleService.GetAllRoles invoked");

        //    return roleRepository.GetAll().ToList().Select(x => x.ToBllRole());
        //}

        //#endregion

        //#region Private Methods

        //private void RemoveUserFromRoles(DalUser user, IEnumerable<int> newRoles)
        //{
        //    List<DalRole> rolesForRemove =
        //        roleRepository.GetUserRoles(user).Where(x => !newRoles.Contains(x.Id)).ToList();
        //    foreach (DalRole oldRole in rolesForRemove)
        //    {
        //        RemoveUserFromRole(user.UserName, oldRole.Name);
        //    }
        //}

        //private void AddUserInewRoles(DalUser user, IEnumerable<int> newRoles)
        //{
        //    List<DalRole> oldRoles = roleRepository.GetUserRoles(user).ToList();
        //    foreach (int newRoleId in newRoles)
        //    {
        //        if (oldRoles.Count(x => x.Id == newRoleId) == 0)
        //        {
        //            DalRole role = roleRepository.GetById(newRoleId);
        //            if (role != null)
        //                AddUserInRole(user.UserName, role.Name);
        //        }
        //    }
        //}

        //#endregion
    }
}