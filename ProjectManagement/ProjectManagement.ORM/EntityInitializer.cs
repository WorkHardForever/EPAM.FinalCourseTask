using ProjectManagement.ORM.Entities;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ProjectManagement.ORM
{
    public class EntityInitializer : DropCreateDatabaseIfModelChanges<EntityModel>
    {
        public string[] Roles = new string[]
        {
            "Admin",
            "Default"
        };

        public static readonly User Admin = new User()
        {
            Login = "admin",
            PasswordHash = "qwerty",
            Profile = new Profile()
            {
                Email = "1b97@mail.ru",
                Name = "Edgar",
                Surname = "Mengel"
            }
        };

        //protected override void Seed(EntityModel context)
        //{
        //    var roleManager = new RoleManager<Role>(new RoleStore<Role>(context));
        //    var userManager = new UserManager<User>(new UserStore<User>(context));

        //    SetRolesByEnum(roleManager);
        //    SetInitialAdmin(userManager, Admin, AdminPassword);

        //    base.Seed(context);
        //}

        //public void SetInitialAdmin(UserManager<User> userManager, User admin, string password)
        //{
        //    var result = userManager.Create(admin, password);
        //    if (result.Succeeded)
        //    {
        //        userManager.AddToRole(admin.Id, Roles[0]);
        //        userManager.AddToRole(admin.Id, Roles[1]);
        //    }
        //}

        //public IdentityResult SetInitialRoles(RoleManager<Role> roleManager, string roleName)
        //{
        //    return roleManager.Create(new Role { Name = roleName });
        //}

        //private void SetRolesByEnum(RoleManager<Role> roleManager)
        //{
        //    for (int i = 0; i < Roles.Length; i++)
        //    {
        //        SetInitialRoles(roleManager, Roles[i]);
        //    }
        //}
    }
}
