using RobotArm.Data.DbContexts.UserManagement;

namespace RobotArm.RepositoriesInterfaces.UserManagement
{
    public interface IUserManagementRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        
    }
}