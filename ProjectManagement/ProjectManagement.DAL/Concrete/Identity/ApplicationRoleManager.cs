using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManagement.DAL.Interfacies.DTO;

namespace ProjectManagement.DAL.Concrete.Identity
{
    public class ApplicationRoleManager : RoleManager<DalRole>
    {
        public ApplicationRoleManager(RoleStore<DalRole> store)
            : base(store)
        {
        }
    }
}
