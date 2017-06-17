using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManagement.ORM.Entities;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ProjectManagement.ORM
{
    public class EntityInitializer : IDatabaseInitializer<EntityModel>
    {
        public string[] Roles = new string[]
        {
            "Admin",
            "Default"
        };

        public static readonly User Admin = new User()
        {
            UserName = "meneleanat@yandex.ru",
            Email = "meneleanat@yandex.ru",
            PhoneNumber = "+375293337740",
        };

        public static readonly string AdminPassword = "admin";

        //protected override void Seed(EntityModel context)
        //{
        //    var roleManager = new RoleManager<Role>(new RoleStore<Role>(context));
        //    var userManager = new UserManager<User>(new UserStore<User>(context));

        //    SetRolesByEnum(roleManager, typeof(Roles));
        //    SetInitialAdmin(userManager, Admin, AdminPassword);

        //    base.Seed(context);
        //}

        public void SetInitialAdmin(UserManager<User> userManager, User admin, string password)
        {
            var result = userManager.Create(admin, password);
            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, Roles[0]);
                //userManager.AddToRoleAsync(admin.Id, Roles[0]);
            }
        }

        public IdentityResult SetInitialRoles(RoleManager<Role> roleManager, string roleName)
        {
            return roleManager.Create(new Role { Name = roleName });
        }

        private void SetRolesByEnum(RoleManager<Role> roleManager)
        {
            for (int i = 0; i < Roles.Length; i++)
            {
                SetInitialRoles(roleManager, Roles[i]);
            }
        }

        public void InitializeDatabase(EntityModel context)
        {
            var roleManager = new RoleManager<Role>(new RoleStore<Role>(context));
            var userManager = new UserManager<User>(new UserStore<User>(context));

            SetRolesByEnum(roleManager);
            SetInitialAdmin(userManager, Admin, AdminPassword);
            context.SaveChanges();
        }
    }
}
