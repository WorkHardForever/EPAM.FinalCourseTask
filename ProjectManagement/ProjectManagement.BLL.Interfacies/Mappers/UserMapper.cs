using ProjectManagement.BLL.Interface.Entities;
using ProjectManagement.DAL.Interface.DTO;

namespace ProjectManagement.BLL.Interface.Mappers
{
    public static class UserMapper
    {
        public static BllUser ToBllUser(this DalUser dalUser)
        {
            return new BllUser()
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
                Profile = dalUser.Profile.ToBllProfile()
            };
        }

        public static DalUser ToDalUser(this BllUser bllUser)
        {
            return new DalUser()
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
                Profile = bllUser.Profile.ToDalProfile()
            };
        }
    }
}
