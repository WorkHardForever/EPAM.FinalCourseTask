﻿using ProjectManagement.DAL.Interfacies.DTO;
using ProjectManagement.ORM.Entities;

namespace ProjectManagement.DAL.Mappers
{
    public static class DbUserMapper
    {
        public static DalUser ToDalUser(this User dbUser)
        {
            return new DalUser()
            {
                Id = dbUser.Id,
                UserName = dbUser.UserName,
                PasswordHash = dbUser.PasswordHash,
                Email = dbUser.Email,
                EmailConfirmed = dbUser.EmailConfirmed,
                AccessFailedCount = dbUser.AccessFailedCount,
                LockoutEnabled = dbUser.LockoutEnabled,
                LockoutEndDateUtc = dbUser.LockoutEndDateUtc,
                PhoneNumber = dbUser.PhoneNumber,
                PhoneNumberConfirmed = dbUser.PhoneNumberConfirmed,
                TwoFactorEnabled = dbUser.TwoFactorEnabled,
                SecurityStamp = dbUser.SecurityStamp,
                WorkAccount = dbUser.WorkAccount?.ToDalPerson()
            };
        }

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
