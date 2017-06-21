using ProjectManagement.BLL.Interface.Entities;
using ProjectManagement.DAL.Interface.DTO;

namespace ProjectManagement.BLL.Interface.Mappers
{
    public static class RoleMapper
    {
        public static BllRole ToBllRole(this DalRole dalRole)
        {
            return new BllRole()
            {
                Id = dalRole.Id,
                Name = dalRole.Name,
                RoleUsers = dalRole.RoleUsers.ToBllUserEnumerable()
            };
        }
        
        public static DalRole ToDalRole(this BllRole bllRole)
        {
            return new DalRole()
            {
                Id = bllRole.Id,
                Name = bllRole.Name,
                RoleUsers = bllRole.RoleUsers.ToDalUserEnumerable()
            };
        }
    }
}
