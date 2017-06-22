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

        public ProfileService(IUnitOfWork uow, IProfileRepository profileRepository,
            ITaskService taskService)
        {
            _uow = uow;
            _profileRepository = profileRepository;
            _taskService = taskService;
        }

        public void Create(BllProfile profile)
        {
            _profileRepository.Create(profile.ToDalProfile());
        }

        //public BllTaskPercentState GetStateOfReceivedTasks(BllProfile profile)
        //{
        //    if (profile == null || profile.ReceivedTasks == null)
        //        return null;

        //    return GetReceivedTaskPercentState(profile);
        //}

        //public void Create(BllProfile item)
        //{
        //    _profileRepository.Create(item.ToDalProfile());
        //}

        //public BllProfile GetById(string id)
        //{
        //    return _profileRepository.GetById(id).ToBllProfile();
        //}

        //public IEnumerable<BllProfile> GetEmployees(string managerId)
        //{
        //    if (string.IsNullOrEmpty(managerId))
        //        throw new ArgumentException(nameof(managerId) + "Null or empty");

        //    var manager = _profileRepository.GetGivenTasks(managerId).ToBllProfile();
        //    if (manager.GivenTasks == null)
        //        return null;

        //    var employees = new List<BllProfile>();
        //    foreach (var item in manager.GivenTasks)
        //    {
        //        employees.Add(_taskService.GetEmployee(item));
        //    }

        //    return employees;
        //}

        //public BllContainTasksByState DivideToStateReceivedTasks(BllProfile profile)
        //{
        //    if (profile == null)
        //        return null;

        //    var stateContainer = new BllContainTasksByState();
        //    foreach (var item in profile.ReceivedTasks)
        //    {
        //        switch (item.State)
        //        {
        //            case BllTaskState.ToDo:
        //                stateContainer.Todo.Add(item);
        //                break;
        //            case BllTaskState.InProcess:
        //                stateContainer.InProcess.Add(item);
        //                break;
        //            case BllTaskState.Done:
        //                stateContainer.Done.Add(item);
        //                break;
        //            default:
        //                break;
        //        }
        //    }

        //    return stateContainer;
        //}





        //private BllTaskPercentState GetReceivedTaskPercentState(BllProfile profile)
        //{
        //    if (profile == null)
        //        return null;

        //    var toDo = 0;
        //    var InProcess = 0;
        //    var Done = 0;
        //    foreach (var item in profile.ReceivedTasks)
        //    {
        //        switch (item.State)
        //        {
        //            case BllTaskState.ToDo:
        //                toDo++;
        //                break;
        //            case BllTaskState.InProcess:
        //                InProcess++;
        //                break;
        //            case BllTaskState.Done:
        //                Done++;
        //                break;
        //            default:
        //                break;
        //        }
        //    }

        //    var count = profile.ReceivedTasks.Count();
        //    var taskPercentState = new BllTaskPercentState()
        //    {
        //        ToDo = GetPercent(toDo, count),
        //        InProcess = GetPercent(InProcess, count),
        //        Done = GetPercent(Done, count)
        //    };

        //    return taskPercentState;
        //}

        //private int GetPercent(int part, int total)
        //{
        //    if (part > total && total <= 0)
        //        throw new ArgumentException("Check arguments that part < total and total > 0");

        //    return part / total * 100;
        //}
    }
}
