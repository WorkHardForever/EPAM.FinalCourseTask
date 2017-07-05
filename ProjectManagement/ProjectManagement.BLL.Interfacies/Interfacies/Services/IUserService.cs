using ProjectManagement.BLL.Interface.Entities;
using System.Collections.Generic;

namespace ProjectManagement.BLL.Interface.Interfacies.Services
{
    public interface IUserService
    {
        void Create(BllUser user);

        bool IsUserLoginExist(string login);

        void Delete(string loginName);

        IEnumerable<BllUser> GetAll();

        BllUser GetByLogin(string login);
    }
}
