namespace ProjectManagement.AspNetMvc.PL.Models.DashboardViewModels
{
    public class TasksViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public TimeViewModel StartTime { get; set; }

        public TimeViewModel DeadLine { get; set; }
    }
}