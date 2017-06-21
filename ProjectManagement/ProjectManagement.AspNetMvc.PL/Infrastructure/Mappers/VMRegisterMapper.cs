using ProjectManagement.AspNetMvc.PL.Models.AccountViewModels;
using ProjectManagement.BLL.Interface.Entities;

namespace ProjectManagement.AspNetMvc.PL.Infrastructure.Mappers
{
    public static class VMRegisterMapper
    {
        public static BllUser RegisterToBllUser(this RegisterViewModel registerViewModel)
        {
            return new BllUser()
            {
                PasswordHash = registerViewModel.Password,
                Profile = new BllProfile()
                {
                    Name = registerViewModel.Name,
                    Surname = registerViewModel.Surname
                }
            };
        }
    }
}
