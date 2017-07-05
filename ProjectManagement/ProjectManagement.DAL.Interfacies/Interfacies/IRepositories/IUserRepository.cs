using ProjectManagement.DAL.Interface.DTO;

namespace ProjectManagement.DAL.Interface.Interfacies.IRepositories
{
    public interface IUserRepository : IRepository<DalUser>
    {
        DalUser GetByLogin(string login);

        bool IsUserLoginExist(string login);
    }
}
