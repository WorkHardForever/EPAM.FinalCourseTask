using System;

namespace ProjectManagement.BLL.Interfacies.Entities
{
    public class BllTask
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public BllPerson Manager { get; set; }

        public BllPerson Employee { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime DeadLine { get; set; }

        public int StateId { get; set; }
    }
}
