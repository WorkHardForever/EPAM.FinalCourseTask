using Microsoft.AspNet.Identity;
using ProjectManagement.BLL.Interfacies.Entities;
using System.Threading.Tasks;

namespace ProjectManagement.BLL.Interfacies.Interfacies.Services
{
    public interface IUserService
    {
        Task<IdentityResult> CreateAsync(BllUser user, string password);

        Task<IdentityResult> AddToDefaultRoleAsync(string userId);

        //BllUser GetById(int key);

        //BllUser GetByName(string name);

        //BllUser Create(BllUser e);

        //void AddFriend(int currentUserId, int newFriendId);

        //void RemoveFriend(int currentUserId, int newFriendId);

        //IEnumerable<BllUser> FindUsers(string name, string surname, DateTime? birthDayMin, DateTime? birthDayMax);

        //IEnumerable<BllUser> GetAllUsers();

        //IMappedPagedList<BllUser> GetAllUsersPage(int pageSize, int pageNumber);

        //bool IsUserExists(String userName);

        //bool IsUserExists(int id);

        //void Delete(BllUser e);

        //void Update(BllUser e);

        //bool CanUserAddToFriends(int userId, int friendId);

        //bool CanUserWriteMessage(int targetId, int senderId);
    }
}
