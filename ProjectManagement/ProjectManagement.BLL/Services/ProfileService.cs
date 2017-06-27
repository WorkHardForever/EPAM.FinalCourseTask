using ProjectManagement.BLL.Interface.Entities;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using ProjectManagement.DAL.Interface.Interfacies;
using ProjectManagement.DAL.Interface.Interfacies.IRepositories;
using System.Collections.Generic;
using System;
using ProjectManagement.BLL.Mappers;
using System.Linq;

namespace ProjectManagement.BLL.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _uow;
        private readonly IProfileRepository _profileRepository;
        private readonly ITaskService _taskService;

        public ProfileService(IUnitOfWork uow, IProfileRepository profileRepository, ITaskService taskService)
        {
            _uow = uow;
            _profileRepository = profileRepository;
            _taskService = taskService;
        }

        public BllProfile GetByEmail(string email)
        {
            return _profileRepository.GetByEmail(email).ToBllProfile();
        }

        public IEnumerable<BllProfile> GetEmployeesWithTasks(BllProfile manager)
        {
            var employees = new List<BllProfile>();
            foreach (var item in manager.GivenTasks)
            {
                var index = employees.FindIndex(x => x.Email == item.Employee.Email);
                if (index != -1)
                {
                    ((List<BllTask>) employees[index].ReceivedTasks).Add(item);
                }
                else
                {
                    var person = item.Employee;
                    person.ReceivedTasks = new List<BllTask>();
                    ((List<BllTask>) person.ReceivedTasks).Add(item);
                    employees.Add(person);
                }
            }

            return employees;
        }

        public BllProfile GetById(int userId)
        {
            return _profileRepository.GetById(userId)?.ToBllProfile();
        }

        public BllContainTasksByState DivideByStateReceivedTasks(BllProfile profile)
        {
            if (profile == null)
                return null;

            var stateContainer = new BllContainTasksByState()
            {
                Todo = new List<BllTask>(),
                InProcess = new List<BllTask>(),
                Done = new List<BllTask>()
            };
            foreach (var item in profile.ReceivedTasks)
            {
                switch (item.State)
                {
                    case BllTaskState.ToDo:
                        stateContainer.Todo.Add(item);
                        break;
                    case BllTaskState.InProcess:
                        stateContainer.InProcess.Add(item);
                        break;
                    case BllTaskState.Done:
                        stateContainer.Done.Add(item);
                        break;
                    default:
                        break;
                }
            }

            return stateContainer;
        }

        public BllTaskPercentState GetReceivedTaskPercentState(BllProfile profile)
        {
            if (profile == null)
                return null;

            var count = profile.ReceivedTasks.Count();
            if (count == 0)
                return null;

            var toDo = 0;
            var InProcess = 0;
            var Done = 0;
            foreach (var item in profile.ReceivedTasks)
            {
                switch (item.State)
                {
                    case BllTaskState.ToDo:
                        toDo++;
                        break;
                    case BllTaskState.InProcess:
                        InProcess++;
                        break;
                    case BllTaskState.Done:
                        Done++;
                        break;
                    default:
                        break;
                }
            }

            var taskPercentState = new BllTaskPercentState()
            {
                ToDo = GetPercent(toDo, count),
                InProcess = GetPercent(InProcess, count),
                Done = GetPercent(Done, count)
            };

            return taskPercentState;
        }

        private float GetPercent(int part, int total)
        {
            if (part > total && total <= 0)
                throw new ArgumentException("Check arguments that part < total and total > 0");

            return (float) part / total * 100;
        }
    }
}