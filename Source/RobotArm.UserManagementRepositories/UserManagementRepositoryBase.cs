using RobotArm.Common.Patterns.DbContext;
using RobotArm.Common.Patterns.DbContext.DbContextScope.Interfaces;
using RobotArm.Common.Patterns.DbContext.UnitOfWork;
using RobotArm.CommonRepositories;
using RobotArm.Data.DbContexts.UserManagement;
using RobotArm.RepositoriesInterfaces.UserManagement;

namespace RobotArm.UserManagementRepositories
{
    public class UserManagementRepositoryBase<TEntity> : RepositoryBase<TEntity, UserManagementDbContext>, IUserManagementRepository<TEntity>
        where TEntity : class
    {
        protected UserManagementRepositoryBase(IAmbientDbContextLocator ambientDbContextLocator) 
            : base(ambientDbContextLocator)
        {
        }
    }
}