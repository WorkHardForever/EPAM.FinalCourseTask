using ProjectManagement.BLL.Interfacies.Entities;
using ProjectManagement.DAL.Interfacies.DTO;

namespace ProjectManagement.BLL.Mappers
{
    public static class RoleMapper
    {
        public static BllRole ToBllRole(this DalRole dalRole)
        {
            return new BllRole()
            {
                Id = dalRole.Id,
                Name = dalRole.Name
            };
        }
        
        public static DalRole ToDalRole(this BllRole bllRole)
        {
            return new DalRole()
            {
                Id = bllRole.Id,
                Name = bllRole.Name
            };
        }
    }
}
