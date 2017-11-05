using RobotArm.Common.Logging;
using RobotArm.CommonServices;
using RobotArm.CommonServices.ErrorHandling;
using RobotArm.RobotArmControlServices.ErrorHandling;

namespace RobotArm.RobotArmControlServices
{
    public abstract class RobotArmControlServiceBase : ServiceBase
    {
        // TODO: User other logger
        protected RobotArmControlServiceBase()
            : base(ELogger.Common)
        {
            
        }
    }
}