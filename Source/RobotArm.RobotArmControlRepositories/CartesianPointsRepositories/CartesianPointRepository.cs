using RobotArm.Common.Patterns.DbContext.DbContextScope.Interfaces;
using RobotArm.Data.Entities.RobotArmControl;
using RobotArm.RepositoriesInterfaces.RobotArmControl;

namespace RobotArm.RobotArmControlRepositories.CartesianPointsRepositories
{
    public class CartesianPointRepository : RobotArmControlRepositoryBase<CartesianPoint>, ICartesianPointRepository
    {
        public CartesianPointRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }
    }
}