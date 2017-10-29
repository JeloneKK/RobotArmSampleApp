using Autofac;
using Autofac.Integration.Wcf;
using RobotArm.Common.Patterns.DbContext.DbContextScope;
using RobotArm.Common.Patterns.DbContext.DbContextScope.Interfaces;
using RobotArm.HostingCommon.Initializing;
using RobotArm.UserManagementBusinessLogic.UserBusinessLogics;
using RobotArm.UserManagementRepositories.UserRepositories;
using RobotArm.UserManagementServices.Mappings;
using RobotArm.UserManagementServices.UserServices;

namespace RobotArm.UserManagementServicesWpfHost
{
    public class Bootstrapper
    {
        private IContainer _container;

        public IContainer GetContainer => _container;

        public void Run()
        {
            SetAutofacContainer();
            AutoMapperConfiguration.Configure();
        }

        private void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CustomServiceHostInitializer>().As<IServiceHostInitializer>();

            builder.RegisterType<DbContextScopeFactory>().As<IDbContextScopeFactory>();
            builder.RegisterType<AmbientDbContextLocator>().As<IAmbientDbContextLocator>();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            // BusinessLogic
            builder.RegisterAssemblyTypes(typeof(UserBusinessLogic).Assembly)
                .Where(t => t.Name.EndsWith("BusinessLogic"))
                .AsImplementedInterfaces();

            // Services
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            _container = builder.Build();

            AutofacHostFactory.Container = _container;
        }
    }
}