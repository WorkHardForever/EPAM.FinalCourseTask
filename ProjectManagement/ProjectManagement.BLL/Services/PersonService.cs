using ProjectManagement.BLL.Interfacies.Entities;
using ProjectManagement.BLL.Interfacies.Interfacies.Services;
using ProjectManagement.BLL.Mappers;
using ProjectManagement.DAL.Interfacies.Interfacies;
using ProjectManagement.DAL.Interfacies.Interfacies.IRepositories;
using System.Collections.Generic;
using System;

namespace ProjectManagement.BLL.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _uow;
        private readonly IPersonRepository _personRepository;
        private readonly ITaskService _taskService;

        public PersonService(IUnitOfWork uow, IPersonRepository personRepository, ITaskService taskService)
        {
            _uow = uow;
            _personRepository = personRepository;
            _taskService = taskService;
        }

        public BllTaskPercentState GetStateOfReceivedTasks(BllPerson person)
        {
            if (person == null || person.ReceivedTasks == null)
                return null;

            return _personRepository.GetStateOfReceivedTasks(person.ToDalPerson()).ToBllTaskPercentState();
        }

        public BllContainTasksByState DivideToStateReceivedTasks(BllPerson person)
        {
            if (person == null)
                return null;

            var stateContainer = new BllContainTasksByState();
            foreach (var item in person.ReceivedTasks)
            {
                switch (item.State)
                {
                    case BllTaskState.ToDo:
                        ((List<BllTask>)stateContainer.Todo).Add(item);
                        break;
                    case BllTaskState.InProcess:
                        ((List<BllTask>)stateContainer.InProcess).Add(item);
                        break;
                    case BllTaskState.Done:
                        ((List<BllTask>)stateContainer.Done).Add(item);
                        break;
                    default:
                        break;
                }
            }

            return stateContainer;
        }
    }
}
