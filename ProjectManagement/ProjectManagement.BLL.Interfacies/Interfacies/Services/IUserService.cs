using ProjectManagement.BLL.Interface.Entities;

namespace ProjectManagement.BLL.Interface.Interfacies.Services
{
    public interface IUserService
    {
        void Create(BllUser user);

        BllUser GetByLogin(string login);

        bool IsUserLoginExist(string login);
    }
}
