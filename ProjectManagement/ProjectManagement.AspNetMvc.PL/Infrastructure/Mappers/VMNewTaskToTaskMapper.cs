using ProjectManagement.AspNetMvc.PL.Models.DashboardViewModels;
using ProjectManagement.BLL.Interface.Entities;

namespace ProjectManagement.AspNetMvc.PL.Infrastructure.Mappers
{
    public static class VMNewTaskToTaskMapper
    {
        public static BllTask NewTaskToBllTask(this NewTaskViewModel task)
        {
            return new BllTask()
            {
                Title = task.Title,
                Description = task.Description,
                StartTime = task.StartTime,
                DeadLine = task.DeadLine
            };
        }
    }
}
