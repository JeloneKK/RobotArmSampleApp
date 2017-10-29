using RobotArm.Common.Logging;
using RobotArm.Common.Patterns.DbContext;
using RobotArm.CommonServices;

namespace RobotArm.UserManagementServices
{
    public abstract class UserManagementServiceBase : ServiceBase
    {
        protected UserManagementServiceBase()
            : base(ELogger.UserManagement)
        {
            
        }
    }
}