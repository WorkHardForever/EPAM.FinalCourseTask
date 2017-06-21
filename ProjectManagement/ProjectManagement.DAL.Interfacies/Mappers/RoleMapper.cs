using ProjectManagement.DAL.Interface.DTO;
using ProjectManagement.ORM.Entities;

namespace ProjectManagement.DAL.Interface.Mappers
{
    public static class RoleMapper
    {
        public static DalRole ToDalRole(this Role dbRole)
        {
            return new DalRole()
            {
                Id = dbRole.Id,
                Name = dbRole.Name,
                RoleUsers = dbRole.RoleUsers.ToDalUserEnumerable()
            };
        }

        public static Role ToDbRole(this DalRole dalRole)
        {
            return new Role()
            {
                Id = dalRole.Id,
                Name = dalRole.Name,
                RoleUsers = dalRole.RoleUsers.ToDbProfileCollection()
            };
        }
    }
}
