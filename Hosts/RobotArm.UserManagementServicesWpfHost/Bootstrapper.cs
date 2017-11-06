using Autofac;
using Autofac.Integration.Wcf;
using RobotArm.Common.Patterns.DbContext.DbContextScope;
using RobotArm.Common.Patterns.DbContext.DbContextScope.Interfaces;
using RobotArm.Data.SeedData.RobotArmControl;
using RobotArm.HostingCommon.Initializing;
using RobotArm.RobotArmControlBusinessLogic.RobotProgramBusinessLogics;
using RobotArm.RobotArmControlRepositories.RobotProgramRepositories;
using RobotArm.RobotArmControlServices.RobotProgramServices;
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
            System.Data.Entity.Database.SetInitializer(new RobotArmControlSeedData());

            SetAutofacContainer();
            AutoMapperConfiguration.Configure();
            RobotArm.RobotArmControlServices.Mappings.AutoMapperConfiguration.Configure();
        }

        private void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CustomServiceHostInitializer>().As<IServiceHostInitializer>();

            builder.RegisterType<DbContextScopeFactory>().As<IDbContextScopeFactory>();
            builder.RegisterType<AmbientDbContextLocator>().As<IAmbientDbContextLocator>();

            this.SetAutofacContainerForUserManagement(builder);

            // TODO: Move hosting to other project
            this.SetAutofacContainerForRobotArmControl(builder);

            _container = builder.Build();

            AutofacHostFactory.Container = _container;
        }

        private void SetAutofacContainerForUserManagement(ContainerBuilder builder)
        {
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
        }

        private void SetAutofacContainerForRobotArmControl(ContainerBuilder builder)
        {
            // Repositories
            builder.RegisterAssemblyTypes(typeof(RobotProgramRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            // BusinessLogic
            builder.RegisterAssemblyTypes(typeof(RobotProgramBusinessLogic).Assembly)
                .Where(t => t.Name.EndsWith("BusinessLogic"))
                .AsImplementedInterfaces();

            // Services
            builder.RegisterAssemblyTypes(typeof(RobotProgramService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
        }
    }
}