using ProjectManagement.BLL.Interfacies.Entities;
using ProjectManagement.DAL.Interfacies.DTO;

namespace ProjectManagement.BLL.Mappers
{
    public static class PersonMapper
    {
        public static BllPerson ToBllRole(this DalPerson dalRole)
        {
            return new BllPerson()
            {
                //Id = dalRole.Id,
                //Name = dalRole.Name
            };
        }

        public static DalPerson ToDalRole(this BllPerson bllRole)
        {
            return new DalPerson()
            {
                //Id = bllRole.Id,
                //Name = bllRole.Name
            };
        }
    }
}
