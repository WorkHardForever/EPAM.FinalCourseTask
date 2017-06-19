using ProjectManagement.BLL.Interfacies.Entities;
using ProjectManagement.BLL.Interfacies.Interfacies.Services;
using ProjectManagement.BLL.Mappers;
using ProjectManagement.DAL.Interfacies.DTO;
using ProjectManagement.DAL.Interfacies.Interfacies;
using ProjectManagement.DAL.Interfacies.Interfacies.IRepositories;

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

        public void CreateTask(BllPerson manager, BllPerson employee, BllTask task)
        {
            _taskRepository.Create(task.ToDalTask());
            AddTaskListAsManager(manager, task);
            AddTaskListAsEmployee(employee, task);
            _uow.Commit();
        }

        public void AddTaskListAsManager(BllPerson person, BllTask task)
        {
            _taskRepository.AddToManagerTasks(person.ToDalPerson(), task.ToDalTask());
        }

        public void AddTaskListAsEmployee(BllPerson person, BllTask task)
        {
            _taskRepository.AddToEmployeeTasks(person.ToDalPerson(), task.ToDalTask());
        }
    }
}
