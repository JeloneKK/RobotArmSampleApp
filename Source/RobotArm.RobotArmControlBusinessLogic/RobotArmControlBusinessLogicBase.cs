using RobotArm.Common.Patterns.DbContext.DbContextScope.Interfaces;
using RobotArm.CommonBusinessLogic;

namespace RobotArm.RobotArmControlBusinessLogic
{
    public abstract class RobotArmControlBusinessLogicBase : BusinessLogicBase
    {
        protected RobotArmControlBusinessLogicBase(IDbContextScopeFactory dbContextScopeFactory) 
            : base(dbContextScopeFactory)
        {
        }
    }
}