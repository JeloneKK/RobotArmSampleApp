using RobotArm.Common.Patterns.DbContext;
using RobotArm.Common.Patterns.DbContext.DbContextScope.Interfaces;
using RobotArm.Common.Patterns.DbContext.UnitOfWork;

namespace RobotArm.CommonBusinessLogic
{
    public abstract class BusinessLogicBase
    {
        protected IDbContextScopeFactory DbContextScopeFactory;

        protected BusinessLogicBase(IDbContextScopeFactory dbContextScopeFactory)
        {
            this.DbContextScopeFactory = dbContextScopeFactory;
        }
    }
}