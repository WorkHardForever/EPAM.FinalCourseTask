using ProjectManagement.BLL.Interface.Entities;
using System.Collections.Generic;

namespace ProjectManagement.BLL.Interface.Interfacies.Services
{
    public interface IProfileService
    {
        void Create(BllProfile item);

        BllTaskPercentState GetStateOfReceivedTasks(BllProfile profile);

        BllContainTasksByState DivideToStateReceivedTasks(BllProfile profile);

        IEnumerable<BllProfile> GetEmployees(string managerId);

        BllProfile GetById(string id);
    }
}
