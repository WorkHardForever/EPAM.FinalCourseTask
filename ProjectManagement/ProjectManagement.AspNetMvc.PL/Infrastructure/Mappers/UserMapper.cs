using ProjectManagement.AspNetMvc.PL.Models.AccountViewModels;
using ProjectManagement.BLL.Interfacies.Entities;

namespace ProjectManagement.AspNetMvc.PL.Infrastructure.Mappers
{
    public static class UserMapper
    {
        //public static RegisterViewModel BllToRegisterUser(this BllUser userEntity)
        //{
        //    return new RegisterViewModel()
        //    {
        //        Id = userEntity.Id,
        //        UserName = userEntity.UserName,
        //        Role = (Role)userEntity.RoleId
        //    };
        //}

        public static BllUser RegisterToBllUser(this RegisterViewModel userViewModel)
        {
            return new BllUser()
            {                
                UserName = userViewModel.Email,// <--- Not correct
                Email = userViewModel.Email
            };
        }
    }
}