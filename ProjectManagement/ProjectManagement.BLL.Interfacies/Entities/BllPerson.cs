using System.Collections.Generic;

namespace ProjectManagement.BLL.Interfacies.Entities
{
    public class BllPerson
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public IEnumerable<BllTask> GivenTasks { get; set; }

        public IEnumerable<BllTask> ReceivedTasks { get; set; }
    }
}
