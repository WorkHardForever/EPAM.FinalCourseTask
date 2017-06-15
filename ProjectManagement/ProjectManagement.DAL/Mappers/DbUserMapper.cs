using ProjectManagement.DAL.Interfacies.DTO;
using ProjectManagement.ORM.Entities;

namespace ProjectManagement.DAL.Mappers
{
    public static class DbUserMapper
    {
        public static User ToDbUser(this DalUser bllUser)
        {
            return new User()
            {
                Id = bllUser.Id,
                UserName = bllUser.UserName,
                PasswordHash = bllUser.PasswordHash,
                Email = bllUser.Email,
                EmailConfirmed = bllUser.EmailConfirmed,
                AccessFailedCount = bllUser.AccessFailedCount,
                LockoutEnabled = bllUser.LockoutEnabled,
                LockoutEndDateUtc = bllUser.LockoutEndDateUtc,
                PhoneNumber = bllUser.PhoneNumber,
                PhoneNumberConfirmed = bllUser.PhoneNumberConfirmed,
                TwoFactorEnabled = bllUser.TwoFactorEnabled,
                SecurityStamp = bllUser.SecurityStamp,
                WorkAccount = null// bllUser.WorkAccount?.ToDbPerson()
            };
        }
    }
}
