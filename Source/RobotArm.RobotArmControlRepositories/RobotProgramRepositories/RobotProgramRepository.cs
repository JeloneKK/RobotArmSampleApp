using RobotArm.Common.Patterns.DbContext.DbContextScope.Interfaces;
using RobotArm.Data.Entities.RobotArmControl;
using RobotArm.RepositoriesInterfaces.RobotArmControl;

namespace RobotArm.RobotArmControlRepositories.RobotProgramRepositories
{
    public class RobotProgramRepository : RobotArmControlRepositoryBase<RobotProgram>, IRobotProgramRepository
    {
        public RobotProgramRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }
    }
}