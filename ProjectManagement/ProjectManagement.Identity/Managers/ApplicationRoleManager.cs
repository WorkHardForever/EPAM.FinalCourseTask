using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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

    //public class ApplicationRoleManager<TRole> : RoleManager<TRole>
    //    where TRole : IdentityRole
    //{
    //    public ApplicationRoleManager(RoleStore<TRole> store)
    //        : base(store)
    //    {
    //    }
    //}
}
