using ProjectManagement.DAL.Interface.DTO;
using ProjectManagement.ORM.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.DAL.Mappers
{
    public static class RoleMapper
    {
        public static DalRole ToDalRole(this Role dbRole)
        {
            return new DalRole()
            {
                Id = dbRole.Id,
                Name = dbRole.Name,
                Users = dbRole.Users.ToDalUserEnumerable()
            };
        }

        public static Role ToDbRole(this DalRole dalRole)
        {
            return new Role()
            {
                Id = dalRole.Id,
                Name = dalRole.Name,
                Users = dalRole.Users.ToDbProfileCollection()
            };
        }

        public static IEnumerable<DalRole> ToDalRoleEnumerable(this ICollection<Role> dbRoles)
        {
            return dbRoles?.Select(x => x.ToDalRole());
        }

        public static ICollection<Role> ToDbRoleCollection(this IEnumerable<DalRole> dalRoles)
        {
            return dalRoles?.Select(x => x.ToDbRole()) as ICollection<Role>;
        }
    }
}