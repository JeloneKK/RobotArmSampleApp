using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using RobotArm.Common.Patterns.DbContext;
using RobotArm.Common.Patterns.DbContext.UnitOfWork;
using RobotArm.Data.DbContexts.UserManagement;
using RobotArm.Data.Entities.UserManagement;
using RobotArm.RepositoriesInterfaces.UserManagement;
using RobotArm.UserManagementRepositories.UserRepositories;
using RobotArm.UserManagementServices.UserServices;
using RobotArm.WebApp.Mappings;

namespace RobotArm.WebApp
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            AutoMapperConfiguration.Configure();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<DbContextFactory>().As<IDbContextFactory>().InstancePerRequest();

            builder.RegisterType<UnitOfWork<UserManagementDbContext>>().As<IUnitOfWork>().InstancePerRequest();
            //builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            //builder.RegisterType<>().As<IUnitOfWork>().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.Register(c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context: new UserManagementDbContext())))
                .As<UserManager<ApplicationUser>>().InstancePerRequest();

            //builder.Register(c => new SignInManager<ApplicationUser, string>(new UserStore<ApplicationUser>(context: new UserManagementDbContext())))
            //    .As<SignInManager<ApplicationUser, string>>().InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}