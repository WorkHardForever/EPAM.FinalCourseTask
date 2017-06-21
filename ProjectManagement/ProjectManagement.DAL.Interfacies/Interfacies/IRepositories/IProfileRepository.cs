using ProjectManagement.DAL.Interface.DTO;
using System.Collections.Generic;

namespace ProjectManagement.DAL.Interface.Interfacies.IRepositories
{
    public interface IProfileRepository : IRepository<DalProfile>
    {
        //DalTaskPercentState GetStateOfReceivedTasks(DalProfile profile);

        DalProfile GetGivenTasks(string managerId);
    }
}
