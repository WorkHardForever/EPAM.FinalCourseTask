using ProjectManagement.BLL.Interface.Entities;

namespace ProjectManagement.BLL.Interface.Interfacies.Services
{
    public interface ITaskService
    {
        void CreateTask(BllProfile manager, BllProfile employee, BllTask task);

        void AddTaskListAsManager(BllProfile profile, BllTask task);

        void AddTaskListAsEmployee(BllProfile profile, BllTask task);
    }
}
