using System.Linq;
using RobotArm.Common.Patterns.DbContext;
using RobotArm.Common.Patterns.DbContext.DbContextScope.Interfaces;
using RobotArm.Common.Patterns.DbContext.UnitOfWork;
using RobotArm.Data.DbContexts.UserManagement;
using RobotArm.Data.Entities.UserManagement;
using RobotArm.RepositoriesInterfaces;
using RobotArm.RepositoriesInterfaces.UserManagement;

namespace RobotArm.UserManagementRepositories.UserRepositories
{
    public class UserRepository : UserManagementRepositoryBase<ApplicationUser>, IUserRepository
    {
        public UserRepository(IAmbientDbContextLocator ambientDbContextLocator) 
            : base(ambientDbContextLocator)
        {
        }
    }
}