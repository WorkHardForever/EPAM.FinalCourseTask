using ProjectManagement.BLL.Interfacies.Interfacies.Services;
using ProjectManagement.DAL.Concrete.Identity;
using ProjectManagement.DAL.Interfacies.Interfacies;

namespace ProjectManagement.BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _uow;
        private readonly ApplicationRoleManager _roleManager;

        public RoleService(IUnitOfWork uow, ApplicationRoleManager roleManager)
        {
            _uow = uow;
            _roleManager = roleManager; // new userRepository(new UserStore<BllUser>(uow.Context))
        }
    }
}
