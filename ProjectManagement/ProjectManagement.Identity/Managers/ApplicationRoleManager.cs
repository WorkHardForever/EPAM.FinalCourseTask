

using ProjectManagement.ORM.Entities;

namespace ProjectManagement.Identity.Managers
{
    public class ApplicationRoleManager : RoleManager<Role>
    {
        public ApplicationRoleManager(RoleStore<Role> store)
            : base(store)
        {
        }
    }
}
