using System;
using RobotArm.Common.Logging;
using RobotArm.CommonServices.ErrorHandling;

namespace RobotArm.UserManagementServices.ErrorHandling
{
    public class UserManagementGlobalErrorHandler : GlobalErrorHandlerBase
    {
        public override bool HandleError(Exception error)
        {
            LoggerFactory.GetLogger(ELogger.UserManagement).Error("Uncatched error in service", error);
            return base.HandleError(error);
        }
    }
}