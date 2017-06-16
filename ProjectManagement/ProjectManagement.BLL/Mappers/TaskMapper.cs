using ProjectManagement.BLL.Interfacies.Entities;
using ProjectManagement.DAL.Interfacies.DTO;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.BLL.Mappers
{
    public static class TaskMapper
    {
        //public static BllTask ToBllTask(this DalTask dalTask)
        //{
        //    return new BllTask()
        //    {
        //        //Id = dalRole.Id,
        //        //Name = dalRole.Name
        //    };
        //}

        public static DalTask ToDalTask(this BllTask bllTask)
        {
            return new DalTask()
            {
                Id = bllTask.Id,
                Title = bllTask.Title,
                Description = bllTask.Description,
                Employee = bllTask.Employee?.ToDalPerson(),
                Manager = bllTask.Manager?.ToDalPerson(),
                StartTime = bllTask.StartTime,
                DeadLine = bllTask.DeadLine,
                StateId = bllTask.StateId
            };
        }

        public static IEnumerable<DalTask> ToDalTaskEnumerable(this IEnumerable<BllTask> bllTasks)
        {
            return bllTasks.Select(x => x.ToDalTask());
        }
    }
}
