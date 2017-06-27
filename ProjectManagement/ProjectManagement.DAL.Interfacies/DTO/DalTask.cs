using ProjectManagement.DAL.Interface.Interfacies;
using System;

namespace ProjectManagement.DAL.Interface.DTO
{
    public class DalTask : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DalProfile Manager { get; set; }

        public DalProfile Employee { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime DeadLine { get; set; }

        public DalTaskState State { get; set; }
    }
}