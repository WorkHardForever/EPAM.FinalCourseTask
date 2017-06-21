using ProjectManagement.DAL.Interface.DTO;

namespace ProjectManagement.DAL.Interface.Interfacies.IRepositories
{
    public interface ITaskRepository : IRepository<DalTask>
    {
        DalProfile GetEmployee(DalTask dalTask);
    }
}
