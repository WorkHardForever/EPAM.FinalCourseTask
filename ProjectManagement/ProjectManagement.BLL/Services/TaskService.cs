using System;
using ProjectManagement.BLL.Interface.Entities;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using ProjectManagement.BLL.Mappers;
using ProjectManagement.DAL.Interface.Interfacies;
using ProjectManagement.DAL.Interface.Interfacies.IRepositories;

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

        public void CreateTask(BllProfile manager, BllProfile employee, BllTask task)
        {
            task.Manager = manager;
            task.Employee = employee;

            _taskRepository.Create(task.ToDalTask());
            _uow.Commit();
        }

        //public BllProfile GetEmployee(BllTask item)
        //{
        //    return _taskRepository.GetEmployee(item.ToDalTask()).ToBllProfile();
        //}
    }
}
