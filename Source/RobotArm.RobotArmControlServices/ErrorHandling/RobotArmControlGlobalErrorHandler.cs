using System;
using RobotArm.Common.Logging;
using RobotArm.CommonServices.ErrorHandling;

namespace RobotArm.RobotArmControlServices.ErrorHandling
{
    public class RobotArmControlGlobalErrorHandler : GlobalErrorHandlerBase
    {
        public override bool HandleError(Exception error)
        {
            // TODO: User other logger
            LoggerFactory.GetLogger(ELogger.Common).Error("Uncatched error in service", error);
            return base.HandleError(error);
        }
    }
}