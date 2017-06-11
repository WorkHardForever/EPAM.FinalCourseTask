using ProjectManagement.BLL.Interfacies.Entities;
using ProjectManagement.DAL.Interfacies.DTO;

namespace ProjectManagement.BLL.Mappers
{
    public static class TaskMapper
    {
        public static BllTask ToBllRole(this DalTask dalRole)
        {
            return new BllTask()
            {
                //Id = dalRole.Id,
                //Name = dalRole.Name
            };
        }

        public static DalTask ToDalRole(this BllTask bllRole)
        {
            return new DalTask()
            {
                //Id = bllRole.Id,
                //Name = bllRole.Name
            };
        }
    }
}
