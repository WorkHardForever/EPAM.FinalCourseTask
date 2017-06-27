namespace ProjectManagement.AspNetMvc.PL.Models.DashboardViewModels
{
    public class AboutTaskViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int ManagerId { get; set; }

        public string ManagerName { get; set; }

        public string ManagerSurname { get; set; }

        public string ManagerEmail { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeSurname { get; set; }

        public string EmployeeEmail { get; set; }

        public string StartTime { get; set; }

        public string DeadLine { get; set; }

        public string State { get; set; }
    }
}