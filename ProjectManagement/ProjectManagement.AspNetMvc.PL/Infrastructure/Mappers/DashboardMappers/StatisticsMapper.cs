using ProjectManagement.AspNetMvc.PL.Models.DashboardViewModels;
using ProjectManagement.BLL.Interface.Entities;

namespace ProjectManagement.AspNetMvc.PL.Infrastructure.Mappers.DashboardMappers
{
    public static class StatisticsMapper
    {
        public static StatisticViewModel ToStatisticViewModel(this BllTaskPercentState percentOfWork)
        {
            StatisticViewModel statisticViewModel;
            if (percentOfWork == null)
            {
                statisticViewModel = new StatisticViewModel()
                {
                    Todo = 0,
                    InProcess = 0,
                    Done = 100
                };
            }
            else
            {
                statisticViewModel = new StatisticViewModel()
                {
                    Todo = percentOfWork.ToDo,
                    InProcess = percentOfWork.InProcess,
                    Done = percentOfWork.Done
                };
            }

            return statisticViewModel;
        }
    }
}