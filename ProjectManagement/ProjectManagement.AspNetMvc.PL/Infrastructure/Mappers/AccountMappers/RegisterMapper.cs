using ProjectManagement.AspNetMvc.PL.Models.AccountViewModels;
using ProjectManagement.BLL.Interface.Entities;
using System.Web.Helpers;

namespace ProjectManagement.AspNetMvc.PL.Infrastructure.Mappers.AccountMappers
{
    public static class RegisterMapper
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