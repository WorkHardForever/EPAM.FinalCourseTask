using ProjectManagement.BLL.Interfacies.Entities;
using ProjectManagement.DAL.Interfacies.DTO;

namespace ProjectManagement.BLL.Mappers
{
    public static class PersonMapper
    {
        public static BllPerson ToBllPerson(this DalPerson dalRole)
        {
            return new BllPerson()
            {
                Id = dalRole.Id,
                Name = dalRole.Name,
                Surname = dalRole.Surname,
                GivenTasks = dalRole.GivenTasks?.ToBllTaskEnumerable(),
                ReceivedTasks = dalRole.ReceivedTasks?.ToBllTaskEnumerable()
            };
        }

        public static DalPerson ToDalPerson(this BllPerson bllRole)
        {
            return new DalPerson()
            {
                Id = bllRole.Id,
                Name = bllRole.Name,
                Surname = bllRole.Surname,
                GivenTasks = bllRole.GivenTasks?.ToDalTaskEnumerable(),
                ReceivedTasks = bllRole.ReceivedTasks?.ToDalTaskEnumerable()
            };
        }
    }
}
