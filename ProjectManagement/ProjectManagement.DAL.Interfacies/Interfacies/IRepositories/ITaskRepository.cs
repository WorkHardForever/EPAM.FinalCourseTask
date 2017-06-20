using ProjectManagement.DAL.Interface.DTO;

namespace ProjectManagement.DAL.Interface.Interfacies.IRepositories
{
    public interface ITaskRepository : IRepository<DalTask>
    {
        void AddToManagerTasks(DalProfile profile, DalTask task);

        void AddToEmployeeTasks(DalProfile profile, DalTask task);
    }
}
