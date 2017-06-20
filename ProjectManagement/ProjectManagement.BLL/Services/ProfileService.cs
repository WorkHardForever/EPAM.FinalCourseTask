using ProjectManagement.BLL.Interface.Entities;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using ProjectManagement.DAL.Interface.Interfacies;
using ProjectManagement.DAL.Interface.Interfacies.IRepositories;
using System.Collections.Generic;
using System;
using ProjectManagement.BLL.Interface.Mappers;

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

        public BllTaskPercentState GetStateOfReceivedTasks(BllProfile profile)
        {
            if (profile == null || profile.ReceivedTasks == null)
                return null;

            return null;// _profileRepository.GetStateOfReceivedTasks(profile.ToDalProfile()).ToBllTaskPercentState();
        }

        public BllContainTasksByState DivideToStateReceivedTasks(BllProfile profile)
        {
            if (profile == null)
                return null;

            var stateContainer = new BllContainTasksByState();
            foreach (var item in profile.ReceivedTasks)
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

        public void Create(BllProfile item)
        {
            _profileRepository.Create(item.ToDalProfile());
        }
    }
}
