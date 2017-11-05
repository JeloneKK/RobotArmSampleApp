using RobotArm.Common.Patterns.DbContext.DbContextScope.Interfaces;
using RobotArm.Data.Entities.RobotArmControl;
using RobotArm.RepositoriesInterfaces.RobotArmControl;

namespace RobotArm.RobotArmControlRepositories.ProgramStepRepositories
{
    public class ProgramStepRepository : RobotArmControlRepositoryBase<ProgramStep>, IProgramStepRepository
    {
        public ProgramStepRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }
    }
}