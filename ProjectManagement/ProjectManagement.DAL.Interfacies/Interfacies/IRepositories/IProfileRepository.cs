using ProjectManagement.DAL.Interface.DTO;

namespace ProjectManagement.DAL.Interface.Interfacies.IRepositories
{
    public interface IProfileRepository : IRepository<DalProfile>
    {
        DalProfile GetByEmail(string email);
    }
}
