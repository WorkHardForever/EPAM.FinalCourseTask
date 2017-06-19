using ProjectManagement.AspNetMvc.PL.Models.DashboardViewModels;
using ProjectManagement.BLL.Interfacies.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.AspNetMvc.PL.Infrastructure.Mappers
{
    public static class VMReceivedTasksMapper
    {
        public static IEnumerable<TasksViewModel> BllTasksToViewModel(this IEnumerable<BllTask> tasks)
        {
            return tasks.Select(x => new TasksViewModel()
            {
                Title = x.Title,
                Description = x.Description,
                StartTime = new TimeViewModel()
                {
                    Hours = x.StartTime.ToString("HH:mm"),
                    Day = x.StartTime.Day.ToString(),
                    Month = x.StartTime.ToString("MMMM")
                },
                DeadLine = new TimeViewModel()
                {
                    Hours = x.DeadLine.ToString("HH:mm"),
                    Day = x.DeadLine.Day.ToString(),
                    Month = x.DeadLine.ToString("MMMM")
                }
            });
        }
    }
}
