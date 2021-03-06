﻿using ProjectManagement.BLL.Interface.Entities;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using ProjectManagement.BLL.Mappers;
using ProjectManagement.DAL.Interface.Interfacies;
using ProjectManagement.DAL.Interface.Interfacies.IRepositories;
using System;

namespace ProjectManagement.BLL.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _uow;
        private readonly ITaskRepository _taskRepository;

        public TaskService(IUnitOfWork uow, ITaskRepository taskManager)
        {
            _uow = uow;
            _taskRepository = taskManager;
        }

        public void Create(BllTask task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            _taskRepository.Create(task.ToDalTask());
            _uow.Commit();
        }

        public void ChangeStatus(int taskId)
        {
            if (taskId < 1)
                throw new ArgumentOutOfRangeException(nameof(taskId));

            _taskRepository.ChangeStatus(taskId);
            _uow.Commit();
        }

        public BllTask GetById(int taskId)
        {
            if (taskId < 1)
                throw new ArgumentOutOfRangeException(nameof(taskId));

            return _taskRepository.GetById(taskId)?.ToBllTask();
        }
    }
}
