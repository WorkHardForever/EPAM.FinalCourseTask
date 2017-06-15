using ProjectManagement.DAL.Interfacies.Interfacies;
using System.Collections.Generic;

namespace ProjectManagement.DAL.Interfacies.DTO
{
    public class DalPerson : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public IEnumerable<DalTask> GivenTasks { get; set; }

        public IEnumerable<DalTask> ReceivedTasks { get; set; }
    }
}
