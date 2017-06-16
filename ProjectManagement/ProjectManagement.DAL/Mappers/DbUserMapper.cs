using ProjectManagement.DAL.Interfacies.DTO;
using ProjectManagement.ORM.Entities;

namespace ProjectManagement.DAL.Mappers
{
    public static class DbUserMapper
    {
        public static User ToDbUser(this DalUser dalUser)
        {
            return new User()
            {
                Id = dalUser.Id,
                UserName = dalUser.UserName,
                PasswordHash = dalUser.PasswordHash,
                Email = dalUser.Email,
                EmailConfirmed = dalUser.EmailConfirmed,
                AccessFailedCount = dalUser.AccessFailedCount,
                LockoutEnabled = dalUser.LockoutEnabled,
                LockoutEndDateUtc = dalUser.LockoutEndDateUtc,
                PhoneNumber = dalUser.PhoneNumber,
                PhoneNumberConfirmed = dalUser.PhoneNumberConfirmed,
                TwoFactorEnabled = dalUser.TwoFactorEnabled,
                SecurityStamp = dalUser.SecurityStamp,
                WorkAccount = dalUser.WorkAccount?.ToDbPerson()
            };
        }
    }
}
