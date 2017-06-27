using ProjectManagement.AspNetMvc.PL.Models.DashboardViewModels;
using ProjectManagement.BLL.Interface.Entities;
using System;
using System.Globalization;

namespace ProjectManagement.AspNetMvc.PL.Infrastructure.Mappers.DashboardMappers
{
    public static class CreateTaskMapper
    {
        public static BllTask NewTaskToBllTask(this NewTaskViewModel task)
        {
            return new BllTask()
            {
                Title = task.Title,
                Description = task.Description,
                StartTime = DateTime.ParseExact(task.StartTime, "MM/dd/yyyy h:mm tt", CultureInfo.InvariantCulture),
                DeadLine = DateTime.ParseExact(task.DeadLine, "MM/dd/yyyy h:mm tt", CultureInfo.InvariantCulture),
            };
        }
    }
}