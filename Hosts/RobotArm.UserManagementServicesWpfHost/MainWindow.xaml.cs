using System.Windows;
using Autofac;
using RobotArm.HostingCommon;
using RobotArm.HostingCommon.Initializing;
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

            this.StartStopServiceWpfControl.DataContext = new StartStopServiceViewModel(
                serviceHostInitializer,
                typeof(IUserService),
                typeof(IRoleService));
        }
    }
}
