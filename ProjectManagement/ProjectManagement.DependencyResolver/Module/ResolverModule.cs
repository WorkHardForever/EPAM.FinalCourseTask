using Ninject;
using Ninject.Web.Common;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using ProjectManagement.BLL.Services;
using ProjectManagement.DAL.Concrete;
using ProjectManagement.DAL.Concrete.Repositories;
using ProjectManagement.DAL.Interface.Interfacies;
using ProjectManagement.DAL.Interface.Interfacies.IRepositories;
using ProjectManagement.ORM;
using System.Data.Entity;

namespace ProjectManagement.DependencyResolver.Resolver
{
    public static class ResolverModule
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<DbContext>().To<EntityModel>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<EntityModel>().InSingletonScope();
            }

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<ITaskService>().To<TaskService>();
            kernel.Bind<IProfileService>().To<ProfileService>();
            kernel.Bind<IMessageService>().To<EmailService>();

            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<ITaskRepository>().To<TaskRepository>();
            kernel.Bind<IProfileRepository>().To<ProfileRepository>();
        }
    }
}