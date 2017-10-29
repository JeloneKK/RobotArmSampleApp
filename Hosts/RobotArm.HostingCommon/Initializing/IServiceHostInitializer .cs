using System;
using System.ServiceModel;

namespace RobotArm.HostingCommon.Initializing
{
    public interface IServiceHostInitializer : IDisposable
    {
        ServiceHost Initialize<TContract>();
    }
}