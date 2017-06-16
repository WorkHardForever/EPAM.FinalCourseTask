using Microsoft.AspNet.Identity;
using ProjectManagement.BLL.Interfacies.Entities;
using ProjectManagement.BLL.Interfacies.Interfacies.Services;
using ProjectManagement.BLL.Mappers;
using ProjectManagement.DAL.Interfacies.Interfacies;
using ProjectManagement.DAL.Interfacies.Interfacies.IRepositories;
using System.Threading.Tasks;

namespace ProjectManagement.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserRepository _userManager;

        public UserService(IUnitOfWork uow, IUserRepository userManager)
        {
            _uow = uow;
            _userManager = userManager;// new ApplicationUserManager<User>(new UserStore<User>(uow.Context));
        }

        public Task<IdentityResult> CreateAsync(BllUser user, string password)
        {
            return _userManager.CreateAsync(user.ToDalUser(), password);
        }

        //public UserEntity GetUserEntity(int id)
        //{
        //    return userRepository.GetById(id).ToBllUser();
        //}        
        //public IEnumerable<UserEntity> GetAllUserEntities()
        //{
        //    return userRepository.GetAll().Select(user => user.ToBllUser());
        //}
        //public void CreateUser(UserEntity user)
        //{
        //    userRepository.Create(user.ToDalUser());
        //    uow.Commit();
        //}
        //public void DeleteUser(UserEntity user)
        //{
        //    userRepository.Delete(user.ToDalUser());
        //    uow.Commit();
        //}

        //public BllUser GetById(int key)
        //{
        //    throw new NotImplementedException();
        //}

        //public BllUser GetByName(string name)
        //{
        //    throw new NotImplementedException();
        //}

        //public BllUser Create(BllUser e)
        //{
        //    throw new NotImplementedException();
        //}

        //public void AddFriend(int currentUserId, int newFriendId)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RemoveFriend(int currentUserId, int newFriendId)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<BllUser> FindUsers(string name, string surname, DateTime? birthDayMin, DateTime? birthDayMax)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<BllUser> GetAllUsers()
        //{
        //    throw new NotImplementedException();
        //}

        //public bool IsUserExists(string userName)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool IsUserExists(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(BllUser e)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(BllUser e)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool CanUserAddToFriends(int userId, int friendId)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool CanUserWriteMessage(int targetId, int senderId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
