using System;
using RobotArm.HostingCommon;
using RobotArm.HostingCommon.Initializing;

namespace RobotArm.WpfHostingCommon.ViewModels
{
    public class DesignTimeStartStopServiceViewModel : StartStopServiceViewModel
    {
        public DesignTimeStartStopServiceViewModel(IServiceHostInitializer serviceHostInitializer, params Type[] services) 
            : base(serviceHostInitializer, services)
        {
        }
    }
}