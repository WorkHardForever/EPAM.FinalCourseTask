using System.Collections.Generic;

namespace ProjectManagement.AspNetMvc.PL.Models.DashboardViewModels
{
    public class ReceivedTasksViewModel
    {
        public IEnumerable<TasksViewModel> Todo { get; set; }

        public IEnumerable<TasksViewModel> InProcess { get; set; }

        public IEnumerable<TasksViewModel> Done { get; set; }
    }
}