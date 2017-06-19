using ProjectManagement.DAL.Interfacies.DTO;

namespace ProjectManagement.DAL.Interfacies.Interfacies.IRepositories
{
    public interface IPersonRepository : IRepository<DalPerson>
    {
        DalTaskPercentState GetStateOfReceivedTasks(DalPerson person);
    }
}
