using ProjectManagement.DAL.Interface.DTO;
using ProjectManagement.ORM.Entities;

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
    }
}
