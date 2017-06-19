using ProjectManagement.BLL.Interfacies.Entities;

namespace ProjectManagement.BLL.Interfacies.Interfacies.Services
{
    public interface ITaskService
    {
        void CreateTask(BllPerson manager, BllPerson employee, BllTask task);

        void AddTaskListAsManager(BllPerson person, BllTask task);

        void AddTaskListAsEmployee(BllPerson person, BllTask task);
    }
}
