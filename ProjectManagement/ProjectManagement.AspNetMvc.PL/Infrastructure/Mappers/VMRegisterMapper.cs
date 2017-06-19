using ProjectManagement.AspNetMvc.PL.Models.AccountViewModels;
using ProjectManagement.BLL.Interfacies.Entities;

namespace ProjectManagement.AspNetMvc.PL.Infrastructure.Mappers
{
    public static class VMRegisterMapper
    {
        public static BllUser RegisterToBllUser(this RegisterViewModel userViewModel)
        {
            return new BllUser()
            {                
                UserName = userViewModel.Email,
                Email = userViewModel.Email
            };
        }
    }
}
