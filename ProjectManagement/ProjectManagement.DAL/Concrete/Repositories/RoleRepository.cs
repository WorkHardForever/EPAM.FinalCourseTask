using ProjectManagement.DAL.Interfacies.Interfacies.IRepositories;
using ProjectManagement.Identity.Managers;

namespace ProjectManagement.DAL.Concrete.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public ApplicationRoleManager AppRoleManager { get; private set; }

        public RoleRepository(ApplicationRoleManager appRoleManager)
        {
            AppRoleManager = appRoleManager;
        }
    }
}
