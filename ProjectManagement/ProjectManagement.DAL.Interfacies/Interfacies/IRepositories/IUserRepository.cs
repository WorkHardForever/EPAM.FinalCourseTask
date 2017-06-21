using ProjectManagement.DAL.Interface.DTO;

namespace ProjectManagement.DAL.Interface.Interfacies.IRepositories
{
    public interface IUserRepository : IRepository<DalUser>
    {
        void AddToRole(string userId, string role);

        //void AddToDefaultRole(string userId);

        //Task<DalUser> GetByIdWithProfile(string uniqueId);
    }
}
