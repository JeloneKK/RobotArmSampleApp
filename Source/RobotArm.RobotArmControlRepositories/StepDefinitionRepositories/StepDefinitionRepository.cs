using RobotArm.Common.Patterns.DbContext.DbContextScope.Interfaces;
using RobotArm.Data.Entities.RobotArmControl;
using RobotArm.RepositoriesInterfaces.RobotArmControl;

namespace RobotArm.RobotArmControlRepositories.StepDefinitionRepositories
{
    public class StepDefinitionRepository : RobotArmControlRepositoryBase<StepDefinition>, IStepDefinitionRepository
    {
        public StepDefinitionRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }
    }
}