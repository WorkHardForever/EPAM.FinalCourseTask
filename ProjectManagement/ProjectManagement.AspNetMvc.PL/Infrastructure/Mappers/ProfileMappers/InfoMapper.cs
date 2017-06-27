using ProjectManagement.AspNetMvc.PL.Models.ProfileViewModels;
using ProjectManagement.BLL.Interface.Entities;

namespace ProjectManagement.AspNetMvc.PL.Infrastructure.Mappers.ProfileMappers
{
    public static class InfoMapper
    {
        public static InfoViewModel ToInfoViewModel(this BllProfile bllProfile)
        {
            return new InfoViewModel()
            {
                Name = bllProfile.Name,
                Surname = bllProfile.Surname,
                Email = bllProfile.Email
            };
        }
    }
}