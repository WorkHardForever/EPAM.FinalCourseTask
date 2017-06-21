using ProjectManagement.BLL.Interface.Entities;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using ProjectManagement.BLL.Interface.Mappers;
using ProjectManagement.DAL.Interface.Interfacies;
using ProjectManagement.DAL.Interface.Interfacies.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserRepository _userRepository;

        private readonly IProfileService _profileService;

        public UserService(IUnitOfWork uow, IUserRepository userManager,
            IProfileService profileService)
        {
            _uow = uow;
            _userRepository = userManager;

            _profileService = profileService;
        }
        
        //public async Task<BllUser> FindByIdAsync(string userId)
        //{
        //    var user = await _userRepository.FindByIdAsync(userId);
        //    return user.ToBllUser();
        //}

        //public async Task<BllUser> FindByEmail(string email)
        //{
        //    var user = await _userRepository.FindByEmail(email);
        //    return user.ToBllUser();
        //}

        public IEnumerable<string> GetEmployeesIdByUser(BllUser user)
        {
            throw new NotImplementedException();
        }

        //public async Task Create(BllUser item)
        //{
        //    await _userRepository.CreateAsync(item.ToDalUser(), item.PasswordHash);
        //    await _userRepository.AddToDefaultRoleAsync(item.Id);
        //    _profileService.Create(item.Profile);
        //    _uow.Commit();
        //}

        //public async Task<BllUser> GetByIdWithProfile(string uniqueId)
        //{
        //    var person = (await _userRepository.FindByIdAsync(uniqueId)).ToBllUser();
        //    person.Profile = _profileService.GetById(uniqueId);
        //    return person;
        //}
    }
}
