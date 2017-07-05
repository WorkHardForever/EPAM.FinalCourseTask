using ProjectManagement.DAL.Interface.DTO;
using ProjectManagement.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ProjectManagement.DAL.Mappers
{
    public static class UserMapper
    {
        public static DalUser ToDalUser(this User dbUser)
        {
            return new DalUser()
            {
                Id = dbUser.Id,
                Login = dbUser.Login,
                PasswordHash = dbUser.PasswordHash,
                Profile = dbUser.Profile?.ToDalProfile()
            };
        }

        public static User ToDbUser(this DalUser dalUser)
        {
            return new User()
            {
                Id = dalUser.Id,
                Login = dalUser.Login,
                PasswordHash = dalUser.PasswordHash,
                Profile = dalUser.Profile?.ToDbProfile()
            };
        }

        public static IEnumerable<DalUser> ToDalUserEnumerable(this ICollection<User> dbUsers)
        {
            return dbUsers?.Select(x => x.ToDalUser());
        }

        public static ICollection<User> ToDbProfileCollection(this IEnumerable<DalUser> dalUsers)
        {
            return dalUsers?.Select(x => x.ToDbUser()) as ICollection<User>;
        }

        public static Expression<Func<User, DalUser>> ExpressionToDalUser
        {
            get
            {
                return (User user) => new DalUser()
                {
                    Id = user.Id,
                    Login = user.Login
                };
            }
        }
    }
}
