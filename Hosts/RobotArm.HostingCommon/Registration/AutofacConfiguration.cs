using System.Reflection;
using Autofac;
using RobotArm.UserManagementBusinessLogic.UserBusinessLogics;
using RobotArm.UserManagementRepositories.UserRepositories;
using RobotArm.UserManagementServices.UserServices;

namespace RobotArm.HostingCommon.Registration
{
    public class AutofacConfiguration
    {
        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // BusinessLogic
            builder.RegisterAssemblyTypes(typeof(UserBusinessLogic).Assembly)
                .Where(t => t.Name.EndsWith("BusinessLogic"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            IContainer container = builder.Build();
        }
    }
}