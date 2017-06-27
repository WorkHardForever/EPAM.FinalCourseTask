using System;

namespace ProjectManagement.BLL.Interface.Entities
{
    public class BllTask
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public BllProfile Manager { get; set; }

        public BllProfile Employee { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime DeadLine { get; set; }

        public BllTaskState State { get; set; }
    }
}