using ProjectManagement.BLL.Interface.Entities;

namespace ProjectManagement.BLL.Interface.Interfacies.Services
{
    public interface ITaskService
    {
        void Create(BllTask task);

        void ChangeStatus(int taskId);

        BllTask GetById(int taskId);
    }
}
