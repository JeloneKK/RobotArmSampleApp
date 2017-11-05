using System.Windows;
using Autofac;
using RobotArm.HostingCommon;
using RobotArm.HostingCommon.Initializing;
using RobotArm.ServicesContracts.RobotArmControl.ServiceContracts;
using RobotArm.ServicesContracts.UserManagement.ServiceContracts;
using RobotArm.WpfHostingCommon.ViewModels;

namespace RobotArm.UserManagementServicesWpfHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IServiceHostInitializer serviceHostInitializer)
        {
            InitializeComponent();

            // TODO: Move hosting RobotArmControl service to other project
            this.StartStopServiceWpfControl.DataContext = new StartStopServiceViewModel(
                serviceHostInitializer,
                typeof(IUserService),
                typeof(IRoleService),
                typeof(IRobotProgramService));
        }
    }
}
