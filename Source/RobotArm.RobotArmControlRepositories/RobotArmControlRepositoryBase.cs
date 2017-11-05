using RobotArm.Common.Patterns.DbContext.DbContextScope.Interfaces;
using RobotArm.CommonRepositories;
using RobotArm.Data.DbContexts.RobotArmControl;
using RobotArm.RepositoriesInterfaces.RobotArmControl;

namespace RobotArm.RobotArmControlRepositories
{
    public abstract class RobotArmControlRepositoryBase<TEntity> : RepositoryBase<TEntity, RobotArmControlDbContext>, IRobotArmControlRepository<TEntity>
        where TEntity : class
    {
        protected RobotArmControlRepositoryBase(IAmbientDbContextLocator ambientDbContextLocator) 
            : base(ambientDbContextLocator)
        {
        }
    }
}