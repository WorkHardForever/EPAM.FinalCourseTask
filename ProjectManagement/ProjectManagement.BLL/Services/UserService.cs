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
            _userRepository.Create(user.ToDalUser());
            _uow.Commit();
        }

        public BllUser GetByLogin(string login)
        {
            return _userRepository.GetByLogin(login)?.ToBllUser();
        }

        public bool IsUserLoginExist(string login)
        {
            return _userRepository.IsUserLoginExist(login);
        }

        public void Delete(string loginName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BllUser> GetAll()
        {
            return _userRepository.GetAll().ToBllUserEnumerable();
        }
    }
}