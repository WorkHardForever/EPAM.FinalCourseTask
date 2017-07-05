using ProjectManagement.BLL.Interface.Entities;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using ProjectManagement.BLL.Mappers;
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
                throw new ArgumentException(string.Format("User name={0} not found", username));

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

        public void Create(BllRole role)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            _roleRepository.Create(role.ToDalRole());
            _uow.Commit();
        }

        public void Delete(BllRole role)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            _roleRepository.Delete(role.ToDalRole());
            _uow.Commit();
        }
    }
}
