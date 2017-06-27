using System.Collections.Generic;

namespace ProjectManagement.AspNetMvc.PL.Models.DashboardViewModels
{
    public class GivenTaskEmployeeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public IEnumerable<GivenTaskViewModel> Tasks { get; set; }

        //public byte[] Avatar { get; set; }
    }

    public class GivenTaskViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}