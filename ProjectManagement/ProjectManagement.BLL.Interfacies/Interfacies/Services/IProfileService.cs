using ProjectManagement.BLL.Interface.Entities;

namespace ProjectManagement.BLL.Interface.Interfacies.Services
{
    public interface IProfileService
    {
        void Create(BllProfile item);

        BllTaskPercentState GetStateOfReceivedTasks(BllProfile profile);

        BllContainTasksByState DivideToStateReceivedTasks(BllProfile profile);
    }
}
