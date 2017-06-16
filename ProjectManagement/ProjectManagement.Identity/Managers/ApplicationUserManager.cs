using Microsoft.AspNet.Identity;
using ProjectManagement.ORM.Entities;

namespace ProjectManagement.Identity.Managers
{
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> store)
            : base(store)
        {
        }
    }
}
