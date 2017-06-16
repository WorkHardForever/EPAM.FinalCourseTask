using ProjectManagement.DAL.Interfacies.DTO;
using ProjectManagement.ORM.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.DAL.Mappers
{
    public static class DbTaskMapper
    {
        public static Task ToDbTask(this DalTask dalTask)
        {
            return new Task()
            {
                Id = dalTask.Id,
                Title = dalTask.Title,
                Description = dalTask.Description,
                EmployeePerson = dalTask.Employee?.ToDbPerson(),
                ManagerPerson = dalTask.Manager?.ToDbPerson(),
                StartTime = dalTask.StartTime,
                DeadLine = dalTask.DeadLine,
                State = (TaskState)dalTask.StateId
            };
        }

        public static ICollection<Task> ToDbTaskCollection(this IEnumerable<DalTask> dalTasks)
        {
            return dalTasks.Select(x => x.ToDbTask()) as ICollection<Task>;
        }
    }
}
