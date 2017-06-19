using ProjectManagement.DAL.Interfacies.DTO;

namespace ProjectManagement.DAL.Interfacies.Interfacies.IRepositories
{
    public interface ITaskRepository : IRepository<DalTask>
    {
        void AddToManagerTasks(DalPerson person, DalTask task);

        void AddToEmployeeTasks(DalPerson person, DalTask task);
    }
}
