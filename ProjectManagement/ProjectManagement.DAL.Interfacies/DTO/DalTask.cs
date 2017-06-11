using ProjectManagement.DAL.Interfacies.Interfacies;
using System;

namespace ProjectManagement.DAL.Interfacies.DTO
{
    public class DalTask : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DalPerson Manager { get; set; }

        public DalPerson Employee { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime DeadLine { get; set; }

        public int StateId { get; set; }
    }
}
