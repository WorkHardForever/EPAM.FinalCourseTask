using ProjectManagement.DAL.Interface.DTO;
using System.Collections.Generic;

namespace ProjectManagement.DAL.Interface.Interfacies.IRepositories
{
    public interface IProfileRepository : IRepository<DalProfile>
    {
        DalProfile GetByEmail(string email);

        IEnumerable<DalTask> GetAllGivenTasks(DalProfile dalProfile);

        IEnumerable<DalTask> GetAllReceivedTasks(DalProfile dalProfile);
    }
}
