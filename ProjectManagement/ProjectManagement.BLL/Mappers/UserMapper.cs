using ProjectManagement.BLL.Interface.Entities;
using ProjectManagement.DAL.Interface.DTO;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.BLL.Mappers
{
    public static class UserMapper
    {
        public static BllUser ToBllUser(this DalUser dalUser)
        {
            return new BllUser()
            {
                Id = dalUser.Id,
                Login = dalUser.Login,
                PasswordHash = dalUser.PasswordHash,
                Profile = dalUser.Profile?.ToBllProfile()
            };
        }

        public static DalUser ToDalUser(this BllUser bllUser)
        {
            return new DalUser()
            {
                Id = bllUser.Id,
                Login = bllUser.Login,
                PasswordHash = bllUser.PasswordHash,
                Profile = bllUser.Profile?.ToDalProfile()
            };
        }

        public static IEnumerable<BllUser> ToBllUserEnumerable(this IEnumerable<DalUser> dalUsers)
        {
            return dalUsers?.Select(x => x.ToBllUser());
        }

        public static IEnumerable<DalUser> ToDalUserEnumerable(this IEnumerable<BllUser> bllUsers)
        {
            return bllUsers?.Select(x => x.ToDalUser());
        }
    }
}