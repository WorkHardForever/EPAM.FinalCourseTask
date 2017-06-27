using ProjectManagement.DAL.Interface.DTO;

namespace ProjectManagement.DAL.Interface.Interfacies.IRepositories
{
    public interface ITaskRepository : IRepository<DalTask>
    {
        void ChangeStatus(int taskId);
    }
}