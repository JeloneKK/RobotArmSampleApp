using RobotArm.Common.Patterns.DbContext;
using RobotArm.Common.Patterns.DbContext.DbContextScope.Interfaces;
using RobotArm.Common.Patterns.DbContext.UnitOfWork;
using RobotArm.CommonBusinessLogic;

namespace RobotArm.UserManagementBusinessLogic
{
    public abstract class UserManagementBusinessLogicBase : BusinessLogicBase
    {
        protected UserManagementBusinessLogicBase(IDbContextScopeFactory dbContextScopeFactory) 
            : base(dbContextScopeFactory)
        {
        }
    }
}