using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Ninject;
using Ninject.Web.Common;
using Owin;
using ProjectManagement.BLL.Interfacies.Interfacies.Services;
using ProjectManagement.BLL.Services;
using ProjectManagement.DAL.Concrete;
using ProjectManagement.DAL.Concrete.Repositories;
using ProjectManagement.DAL.Interfacies.Interfacies;
using ProjectManagement.DAL.Interfacies.Interfacies.IRepositories;
using ProjectManagement.Identity.Managers;
using ProjectManagement.Identity.Settings.StartConfig;
using ProjectManagement.ORM;
using ProjectManagement.ORM.Entities;
using System;
using System.Web;

namespace ProjectManagement.DependencyResolver.Resolver
{
    public static class ResolverModule
    {
        private static IAppBuilder _app;

        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            ConfigureBindings(kernel, true);
        }

        public static void StartupConfig(this IAppBuilder app)
        {
            _app = app;

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, User>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
        }

        private static void ConfigureBindings(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<IdentityDbContext<User>>().To<EntityModel>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<IdentityDbContext<User>>().To<EntityModel>().InSingletonScope();
            }

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUserSignInService>().To<UserSignInService>();
            kernel.Bind<ITaskService>().To<TaskService>();
            kernel.Bind<IPersonService>().To<PersonService>();
            kernel.Bind<IIdentityMessageService>().To<EmailService>();

            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IUserSignInRepository>().To<UserSignInRepository>();
            kernel.Bind<ITaskRepository>().To<TaskRepository>();
            kernel.Bind<IPersonRepository>().To<PersonRepository>();

            kernel.Bind<ApplicationUserManager>().ToSelf();
            kernel.Bind<ApplicationRoleManager>().ToSelf();
            kernel.Bind<ApplicationUserSignInManager>().ToSelf();
            kernel.Bind<IUserStore<User>>().To<UserStore<User>>().WithConstructorArgument("context", kernel.Get<EntityModel>());
            kernel.Bind<IAuthenticationManager>().ToMethod(x => HttpContext.Current.GetOwinContext().Authentication);
            kernel.Bind<IDataProtectionProvider>().ToMethod(x => _app.GetDataProtectionProvider());
        }
    }
}
