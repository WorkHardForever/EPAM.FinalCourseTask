using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Ninject;
using Ninject.Web.Common;
using Owin;
using ProjectManagement.BLL.Interfacies.Interfacies.Services;
using ProjectManagement.BLL.Services;
using ProjectManagement.DAL.Concrete;
using ProjectManagement.DAL.Concrete.Identity;
using ProjectManagement.DAL.Concrete.Repositories;
using ProjectManagement.DAL.Interfacies.DTO;
using ProjectManagement.DAL.Interfacies.Interfacies;
using ProjectManagement.DAL.Interfacies.Interfacies.IRepositories;
using ProjectManagement.DependencyResolver.EntitiesExtension;
using ProjectManagement.ORM;
using ProjectManagement.ORM.Entities;
using System;
using System.Web;

namespace ProjectManagement.DependencyResolver.Resolver
{
    public static class ResolverModule
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            ConfigureBindings(kernel, true);
        }

        public static void StartupConfig(this IAppBuilder app)
        {
            app.CreatePerOwinContext(EntityModelHelper.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManagerHelper.Create);
            app.CreatePerOwinContext<ApplicationUserSignInManager>(ApplicationUserSignInManagerHelper.Create);
            //app.CreatePerOwinContext<RoleManager<AppRole>>((options, context) =>
            //    new RoleManager<AppRole>(
            //        new RoleStore<AppRole>(context.Get<MyDbContext>())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
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

            kernel.Bind<IPersonRepository>().To<PersonRepository>();
            kernel.Bind<ITaskRepository>().To<TaskRepository>();
            
            //kernel.Bind<ApplicationUserManager>().To<ApplicationUserManager>().WithConstructorArgument(new UserStore<DalUser>(new EntityModel()));
            //kernel.Bind<ApplicationUserSignInManager>().To<ApplicationUserSignInManager>().WithConstructorArgument(new UserStore<DalUser>(new EntityModel()));
            //kernel.Bind<SignInManager<DalUser, string>>().To<ApplicationUserSignInManager>();
        }
    }
}
