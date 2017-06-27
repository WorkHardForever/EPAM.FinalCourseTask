using ProjectManagement.BLL.Interface.Entities;
using System.Collections.Generic;

namespace ProjectManagement.BLL.Interface.Interfacies.Services
{
    public interface IProfileService
    {
        BllProfile GetByEmail(string email);

        IEnumerable<BllProfile> GetEmployeesWithTasks(BllProfile manager);

        BllProfile GetById(int userId);

        BllContainTasksByState DivideByStateReceivedTasks(BllProfile profile);

        BllTaskPercentState GetReceivedTaskPercentState(BllProfile profile);
    }
}