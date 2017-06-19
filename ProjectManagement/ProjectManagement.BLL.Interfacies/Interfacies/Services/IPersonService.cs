using ProjectManagement.BLL.Interfacies.Entities;

namespace ProjectManagement.BLL.Interfacies.Interfacies.Services
{
    public interface IPersonService
    {
        BllTaskPercentState GetStateOfReceivedTasks(BllPerson person);

        BllContainTasksByState DivideToStateReceivedTasks(BllPerson person);
    }
}
