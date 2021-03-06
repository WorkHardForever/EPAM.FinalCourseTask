﻿using ProjectManagement.DAL.Interface.Interfacies;
using System.Collections.Generic;

namespace ProjectManagement.DAL.Interface.DTO
{
    public class DalProfile : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public IEnumerable<DalTask> GivenTasks { get; set; }

        public IEnumerable<DalTask> ReceivedTasks { get; set; }

        public DalUser User { get; set; }
    }
}
