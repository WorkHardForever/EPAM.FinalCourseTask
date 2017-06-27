using ProjectManagement.AspNetMvc.PL.Models.DashboardViewModels;
using ProjectManagement.BLL.Interface.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.AspNetMvc.PL.Infrastructure.Mappers.DashboardMappers
{
    public static class ReceivedTasksMapper
    {
        public static ReceivedTasksViewModel ToReceivedTasksViewModel(this BllContainTasksByState taskStates)
        {
            return new ReceivedTasksViewModel()
            {
                Todo = taskStates?.Todo?.ToTasksViewModel(),
                InProcess = taskStates?.InProcess?.ToTasksViewModel(),
                Done = taskStates?.Done?.ToTasksViewModel(),
            };
        }

        public static IEnumerable<TasksViewModel> ToTasksViewModel(this IEnumerable<BllTask> tasks)
        {
            return tasks.Select(x => new TasksViewModel()
            {
                Id = x.Id,
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
                },
                State = (int) x.State
            });
        }
    }
}