using ProjectManagement.BLL.Interfacies.Entities;
using ProjectManagement.DAL.Interfacies.DTO;

namespace ProjectManagement.BLL.Mappers
{
    public static class TaskPercentStateMapper
    {
        public static BllTaskPercentState ToBllTaskPercentState(this DalTaskPercentState dalTaskPercentState)
        {
            return new BllTaskPercentState()
            {
                ToDo = dalTaskPercentState.ToDo,
                InProcess = dalTaskPercentState.InProcess,
                Done = dalTaskPercentState.Done
            };
        }

        public static DalTaskPercentState ToDalTaskPercentState(this BllTaskPercentState bllTaskPercentState)
        {
            return new DalTaskPercentState()
            {
                ToDo = bllTaskPercentState.ToDo,
                InProcess = bllTaskPercentState.InProcess,
                Done = bllTaskPercentState.Done
            };
        }
    }
}
