using ProjectManagement.BLL.Interface.Entities;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using ProjectManagement.BLL.Interface.Mappers;
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
            _taskRepository.Create(task.ToDalTask());
            AddTaskListAsManager(manager, task);
            AddTaskListAsEmployee(employee, task);
            _uow.Commit();
        }

        public void AddTaskListAsManager(BllProfile profile, BllTask task)
        {
            _taskRepository.AddToManagerTasks(profile.ToDalProfile(), task.ToDalTask());
        }

        public void AddTaskListAsEmployee(BllProfile profile, BllTask task)
        {
            _taskRepository.AddToEmployeeTasks(profile.ToDalProfile(), task.ToDalTask());
        }
    }
}
