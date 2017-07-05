using ProjectManagement.BLL.Interface.Entities;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using ProjectManagement.BLL.Mappers;
using ProjectManagement.DAL.Interface.Interfacies;
using ProjectManagement.DAL.Interface.Interfacies.IRepositories;
using System;
using System.Collections.Generic;
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
            if (string.IsNullOrEmpty(email))
                return null;

            return _profileRepository.GetByEmail(email).ToBllProfile();
        }

        public IEnumerable<BllProfile> GetEmployeesWithTasks(BllProfile manager)
        {
            if (manager == null)
                return null;

            return SortEmployeesByTasks(manager);
        }

        public BllProfile GetById(int userId)
        {
            if (userId < 1)
                throw new ArgumentOutOfRangeException(nameof(userId));

            return _profileRepository.GetById(userId)?.ToBllProfile();
        }

        public BllContainTasksByState DivideByStateReceivedTasks(BllProfile profile)
        {
            if (profile == null)
                return null;

            return SortByStatesTasks(profile);
        }

        public BllTaskPercentState GetReceivedTaskPercentState(BllProfile profile)
        {
            if (profile == null)
                return null;

            if (profile.ReceivedTasks.Count() == 0)
                return null;

            return CalculatePercentOfStates(profile);
        }



        private IEnumerable<BllProfile> SortEmployeesByTasks(BllProfile manager)
        {
            var employees = new List<BllProfile>();
            foreach (var item in manager.GivenTasks)
            {
                var index = employees.FindIndex(x => x.Email == item.Employee.Email);
                if (index != -1)
                {
                    ((List<BllTask>)employees[index].ReceivedTasks).Add(item);
                }
                else
                {
                    var person = item.Employee;
                    person.ReceivedTasks = new List<BllTask>();
                    ((List<BllTask>)person.ReceivedTasks).Add(item);
                    employees.Add(person);
                }
            }

            return employees;
        }

        private BllContainTasksByState SortByStatesTasks(BllProfile profile)
        {
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

        private BllTaskPercentState CalculatePercentOfStates(BllProfile profile)
        {
            var count = profile.ReceivedTasks.Count();
            var tupleStates = CalculateStates(profile.ReceivedTasks);

            var taskPercentState = new BllTaskPercentState()
            {
                ToDo = GetPercent(tupleStates.Item1, count),
                InProcess = GetPercent(tupleStates.Item2, count),
                Done = GetPercent(tupleStates.Item3, count)
            };

            return taskPercentState;
        }

        private Tuple<int, int, int> CalculateStates(IEnumerable<BllTask> tasks)
        {
            var toDo = 0;
            var InProcess = 0;
            var Done = 0;
            foreach (var item in tasks)
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

            return new Tuple<int, int, int>(toDo, InProcess, Done);
        }

        private float GetPercent(int part, int total)
        {
            return (float)part / total * 100;
        }
    }
}
