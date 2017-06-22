using ProjectManagement.DAL.Interface.DTO;
using ProjectManagement.ORM.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.DAL.Mappers
{
    public static class DbTaskMapper
    {
        public static DalTask ToDalTask(this Task dbTask)
        {
            return new DalTask()
            {
                Id = dbTask.Id,
                Title = dbTask.Title,
                Description = dbTask.Description,
                Employee = dbTask.Employee?.ToDalProfile(),
                Manager = dbTask.Manager?.ToDalProfile(),
                StartTime = dbTask.StartTime,
                DeadLine = dbTask.DeadLine,
                State = (DalTaskState)dbTask.State
            };
        }

        public static Task ToDbTask(this DalTask dalTask)
        {
            return new Task()
            {
                Id = dalTask.Id,
                Title = dalTask.Title,
                Description = dalTask.Description,
                Employee = dalTask.Employee?.ToDbProfile(),
                Manager = dalTask.Manager?.ToDbProfile(),
                StartTime = dalTask.StartTime,
                DeadLine = dalTask.DeadLine,
                State = (TaskState)dalTask.State
            };
        }

        public static IEnumerable<DalTask> ToDalTaskEnumerable(this ICollection<Task> dbTasks)
        {
            return dbTasks?.Select(x => x.ToDalTask());
        }

        public static ICollection<Task> ToDbTaskCollection(this IEnumerable<DalTask> dalTasks)
        {
            return dalTasks?.Select(x => x.ToDbTask()) as ICollection<Task>;
        }
    }
}
