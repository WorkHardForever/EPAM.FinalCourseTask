using ProjectManagement.AspNetMvc.PL.Models.AccountViewModels;
using ProjectManagement.BLL.Interface.Entities;
using System.Collections.Generic;
using System.Web.Helpers;

namespace ProjectManagement.AspNetMvc.PL.Infrastructure.Mappers
{
    public static class VMRegisterMapper
    {
        public static BllUser RegisterToBllUser(this RegisterViewModel registerViewModel)
        {
            return new BllUser()
            {
                Login = registerViewModel.Login,
                PasswordHash = Crypto.HashPassword(registerViewModel.Password),
                Profile = new BllProfile()
                {
                    Name = registerViewModel.Name,
                    Surname = registerViewModel.Surname,
                    Email = registerViewModel.Email
                }
            };
        }
    }
}
