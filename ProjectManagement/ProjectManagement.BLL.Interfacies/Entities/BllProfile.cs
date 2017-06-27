using System.Collections.Generic;

namespace ProjectManagement.BLL.Interface.Entities
{
    public class BllProfile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public IEnumerable<BllTask> GivenTasks { get; set; }

        public IEnumerable<BllTask> ReceivedTasks { get; set; }

        public BllUser User { get; set; }
    }
}