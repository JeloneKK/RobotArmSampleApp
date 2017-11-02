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
using RobotArm.ServicesContracts.UserManagement.ServiceContracts;
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

            builder.Register(c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context: new UserManagementDbContext())))
                .As<UserManager<ApplicationUser>>().InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}