
using ProjectManagement.ORM.Entities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManagement.Identity.Settings.StartConfig
{
    public static class UserHelper
    {
        public static async Task<ClaimsIdentity> GenerateUserIdentityAsync(this User user, UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
