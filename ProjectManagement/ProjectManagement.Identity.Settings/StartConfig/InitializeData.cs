using Ninject;
using ProjectManagement.Identity.Managers;
using ProjectManagement.ORM.Entities;
using System;

namespace ProjectManagement.Identity.Settings.StartConfig
{
    public enum Roles
    {
        Admin,
        Default
    }

    public class InitializeData
    {
        public static readonly User Admin = new User()
        {
            UserName = "admin",
            Email = "meneleanat@yandex.ru",
            PhoneNumber = "+375293337740",
        };

        public static readonly string AdminPassword = "admin";

        public ApplicationUserManager AppUserManager;
        public ApplicationRoleManager AppRoleManager;
        
        public InitializeData(ApplicationUserManager appUserManager, ApplicationRoleManager appRoleManager)
        {
            AppUserManager = appUserManager;
            AppRoleManager = appRoleManager;
        }

        public void SetInitialData()
        {
            SetInitialAdmin(Admin, AdminPassword);
            SetDefaultRoles();
        }

        public async void SetInitialAdmin(User admin, string password)
        {
            await AppUserManager.CreateAsync(admin, password);
            await AppUserManager.AddToRoleAsync(admin.Id, nameof(Roles.Admin));
        }

        public async void SetInitialRoles(string roleName)
        {
            await AppRoleManager.CreateAsync(new Role { Name = roleName });
        }

        private void SetDefaultRoles()
        {
            foreach (Roles role in Enum.GetValues(typeof(Roles)))
            {
                SetInitialRoles(nameof(role));
            }
        }
    }
}
