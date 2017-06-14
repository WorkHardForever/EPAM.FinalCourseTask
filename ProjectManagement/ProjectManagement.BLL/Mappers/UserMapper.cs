using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManagement.BLL.Interfacies.Entities;
using ProjectManagement.DAL.Interfacies.DTO;

namespace ProjectManagement.BLL.Mappers
{
    public static class UserMapper
    {
        public static BllUser ToBllUser(this DalUser dalUser)
        {
            return new BllUser()
            {
                //Id = dalUser.Id,
                //UserName = dalUser.UserName,
                //Name = dalUser.Name,
                //Surname = dalUser.Surname,
                //BirthDay = dalUser.BirthDay,
                //Sex = dalUser.Sex != null ? (BllSex?)(int)dalUser.Sex.Value : null,
                //AboutUser = dalUser.AboutUser,
                //PasswordHash = dalUser.PasswordHash,
                //FriendsId = dalUser.FriendsId
            };
        }

        public static DalUser ToDalUser(this BllUser bllUser)
        {
            var convertObj = (DalUser)(IdentityUser)bllUser;
            return convertObj;
        }

        //public static DalSex? ToDalSex(this BllSex? bllSex)
        //{
        //    return bllSex != null ? (DalSex?)(int)bllSex.Value : null;
        //}
    }
}
