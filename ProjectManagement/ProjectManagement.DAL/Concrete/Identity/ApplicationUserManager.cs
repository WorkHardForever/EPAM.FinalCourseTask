using Microsoft.AspNet.Identity;
using ProjectManagement.DAL.Interfacies.DTO;

namespace ProjectManagement.DAL.Concrete.Identity
{
    public class ApplicationUserManager : UserManager<DalUser>
    {
        public ApplicationUserManager(IUserStore<DalUser> store)
            : base(store)
        {
        }
    }
}
