using ProjectManagement.BLL.Interface.Entities;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using ProjectManagement.BLL.Mappers;
using ProjectManagement.DAL.Interface.Interfacies;
using ProjectManagement.DAL.Interface.Interfacies.IRepositories;
using System;
using System.Collections.Generic;

namespace ProjectManagement.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserRepository _userRepository;
        private readonly IProfileService _profileService;

        public UserService(IUnitOfWork uow, IUserRepository userManager, IProfileService profileService)
        {
            _uow = uow;
            _userRepository = userManager;
            _profileService = profileService;
        }

        public void Create(BllUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _userRepository.Create(user.ToDalUser());
            _uow.Commit();
        }

        public BllUser GetByLogin(string login)
        {
            if (string.IsNullOrEmpty(login))
                throw new ArgumentException($"Argument {nameof(login)} is null or empty");

            return _userRepository.GetByLogin(login)?.ToBllUser();
        }

        public bool IsUserLoginExist(string login)
        {
            if (string.IsNullOrEmpty(login))
                throw new ArgumentException($"Argument {nameof(login)} is null or empty");

            return _userRepository.IsUserLoginExist(login);
        }

        public void Delete(string loginName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BllUser> GetAll()
        {
            return _userRepository.GetAll()?.ToBllUserEnumerable();
        }
    }
}
