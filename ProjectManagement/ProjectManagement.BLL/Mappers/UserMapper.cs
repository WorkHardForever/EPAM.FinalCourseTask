using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManagement.BLL.Interfacies.Entities;
using ProjectManagement.DAL.Interfacies.DTO;

namespace ProjectManagement.BLL.Mappers
{
    public static class UserMapper
    {
        //public static BllUser ToBllUser(this DalUser dalUser)
        //{
        //    return new BllUser()
        //    {
        //        Id = dalUser.Id,
        //        UserName = dalUser.UserName,
        //        Name = dalUser.Name,
        //        Surname = dalUser.Surname,
        //        BirthDay = dalUser.BirthDay,
        //        Sex = dalUser.Sex != null ? (BllSex?)(int)dalUser.Sex.Value : null,
        //        AboutUser = dalUser.AboutUser,
        //        PasswordHash = dalUser.PasswordHash,
        //        FriendsId = dalUser.FriendsId
        //    };
        //}

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
                WorkAccount = bllUser.WorkAccount?.ToDalPerson()
            };
        }
    }
}
