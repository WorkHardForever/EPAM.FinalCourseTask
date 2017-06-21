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
        //private static IAppBuilder _app;

        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            ConfigureBindings(kernel, true);
        }

        //public static void StartupConfig(this IAppBuilder app)
        //{
        //    _app = app;

        //    app.UseCookieAuthentication(new CookieAuthenticationOptions
        //    {
        //        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        //        LoginPath = new PathString("/Account/Login"),
        //        Provider = new CookieAuthenticationProvider
        //        {
        //            OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, User>(
        //                validateInterval: TimeSpan.FromMinutes(30),
        //                regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
        //        }
        //    });
        //}

        private static void ConfigureBindings(IKernel kernel, bool isWeb)
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
            kernel.Bind<ITaskService>().To<TaskService>();
            kernel.Bind<IProfileService>().To<ProfileService>();
            //kernel.Bind<IIdentityMessageService>().To<EmailService>();

            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<ITaskRepository>().To<TaskRepository>();
            kernel.Bind<IProfileRepository>().To<ProfileRepository>();

            //kernel.Bind<ApplicationUserManager>().ToSelf();
            //kernel.Bind<ApplicationRoleManager>().ToSelf();
            //kernel.Bind<ApplicationUserSignInManager>().ToSelf();
            //kernel.Bind<IUserStore<User>>().To<UserStore<User>>().WithConstructorArgument("context", kernel.Get<EntityModel>());
            //kernel.Bind<IAuthenticationManager>().ToMethod(x => HttpContext.Current.GetOwinContext().Authentication);
            //kernel.Bind<IDataProtectionProvider>().ToMethod(x => _app.GetDataProtectionProvider());
        }
    }
}
