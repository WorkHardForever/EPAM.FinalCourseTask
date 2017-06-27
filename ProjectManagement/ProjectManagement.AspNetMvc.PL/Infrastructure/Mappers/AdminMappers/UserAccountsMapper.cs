using ProjectManagement.AspNetMvc.PL.Models.AdminViewModels;
using ProjectManagement.BLL.Interface.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.AspNetMvc.PL.Infrastructure.Mappers.AdminMappers
{
    public static class UserAccountsMapper
    {
        public static IEnumerable<UserAccountViewModel> ToUserAccountsViewModel(this IEnumerable<BllUser> bllUsers)
        {
            return bllUsers?.Select(x => x.ToUserAccountViewModel());
        }

        public static UserAccountViewModel ToUserAccountViewModel(this BllUser bllUser)
        {
            return new UserAccountViewModel()
            {
                Id = bllUser.Id,
                Login = bllUser.Login,
            };
        }
    }
}