using ProjectManagement.BLL.Interface.Entities;
using ProjectManagement.DAL.Interface.DTO;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.BLL.Mappers
{
    public static class TaskMapper
    {
        public static BllTask ToBllTask(this DalTask dalTask)
        {
            return new BllTask()
            {
                Id = dalTask.Id,
                Title = dalTask.Title,
                Description = dalTask.Description,
                Employee = dalTask.Employee?.ToBllProfile(),
                Manager = dalTask.Manager?.ToBllProfile(),
                StartTime = dalTask.StartTime,
                DeadLine = dalTask.DeadLine,
                State = (BllTaskState) dalTask.State
            };
        }

        public static DalTask ToDalTask(this BllTask bllTask)
        {
            return new DalTask()
            {
                Id = bllTask.Id,
                Title = bllTask.Title,
                Description = bllTask.Description,
                Employee = bllTask.Employee?.ToDalProfile(),
                Manager = bllTask.Manager?.ToDalProfile(),
                StartTime = bllTask.StartTime,
                DeadLine = bllTask.DeadLine,
                State = (DalTaskState) bllTask.State
            };
        }

        public static IEnumerable<BllTask> ToBllTaskEnumerable(this IEnumerable<DalTask> dalTasks)
        {
            return dalTasks?.Select(x => x.ToBllTask());
        }

        public static IEnumerable<DalTask> ToDalTaskEnumerable(this IEnumerable<BllTask> bllTasks)
        {
            return bllTasks?.Select(x => x.ToDalTask());
        }
    }
}
