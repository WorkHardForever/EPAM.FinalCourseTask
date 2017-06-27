using ProjectManagement.AspNetMvc.PL.Models.DashboardViewModels;
using ProjectManagement.BLL.Interface.Entities;
using System;

namespace ProjectManagement.AspNetMvc.PL.Infrastructure.Mappers.DashboardMappers
{
    public static class AboutTaskMapper
    {
        public static AboutTaskViewModel ToAboutTaskViewModel(this BllTask task)
        {
            return new AboutTaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                StartTime = task.StartTime.ToString("MM/dd/yyyy h:mm tt"),
                DeadLine = task.DeadLine.ToString("MM/dd/yyyy h:mm tt"),
                State = task.State.ToString(),
                ManagerId = task.Manager.Id,
                ManagerName = task.Manager.Name,
                ManagerSurname = task.Manager.Surname,
                ManagerEmail = task.Manager.Email,
                EmployeeId = task.Employee.Id,
                EmployeeName = task.Employee.Name,
                EmployeeSurname = task.Employee.Surname,
                EmployeeEmail = task.Employee.Email,
            };
        }
    }
}