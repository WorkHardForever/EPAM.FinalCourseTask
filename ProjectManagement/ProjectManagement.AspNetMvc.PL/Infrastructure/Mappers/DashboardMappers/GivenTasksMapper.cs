using ProjectManagement.AspNetMvc.PL.Models.DashboardViewModels;
using ProjectManagement.BLL.Interface.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.AspNetMvc.PL.Infrastructure.Mappers.DashboardMappers
{
    public static class GivenTasksMapper
    {
        public static IEnumerable<GivenTaskEmployeeViewModel> ToEmployeesViewModel(
            this IEnumerable<BllProfile> bllProfiles)
        {
            return bllProfiles?.Select(x => x.ToGivenTaskEmployeeViewModel());
        }

        public static GivenTaskEmployeeViewModel ToGivenTaskEmployeeViewModel(this BllProfile bllProfile)
        {
            return new GivenTaskEmployeeViewModel()
            {
                Id = bllProfile.Id,
                Name = bllProfile.Name,
                Surname = bllProfile.Surname,
                Email = bllProfile.Email,
                Tasks = bllProfile.ReceivedTasks.ToReceivedTasksViewModel()
            };
        }

        public static IEnumerable<GivenTaskViewModel> ToReceivedTasksViewModel(this IEnumerable<BllTask> bllTasks)
        {
            return bllTasks?.Select(x => x.ToReceivedTaskViewModel());
        }

        public static GivenTaskViewModel ToReceivedTaskViewModel(this BllTask bllProfile)
        {
            return new GivenTaskViewModel()
            {
                Id = bllProfile.Id,
                Title = bllProfile.Title,
                Description = bllProfile.Description
            };
        }
    }
}