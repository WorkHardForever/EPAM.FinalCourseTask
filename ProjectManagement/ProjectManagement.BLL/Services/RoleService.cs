using ProjectManagement.BLL.Interface.Interfacies.Services;
using ProjectManagement.DAL.Interface.Interfacies;
using ProjectManagement.DAL.Interface.Interfacies.IRepositories;
using System.Threading.Tasks;

namespace ProjectManagement.BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRoleRepository _roleManager;

        //public static readonly string DefaultRole = "DefaultUser";

        public RoleService(IUnitOfWork uow, IRoleRepository roleManager)
        {
            _uow = uow;
            _roleManager = roleManager; // new userRepository(new UserStore<BllUser>(uow.Context))
        }
    }
}
