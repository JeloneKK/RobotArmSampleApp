using System.Data.Entity;
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

        public override void Update(RobotProgram entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;

            if (entity.ProgramSteps == null)
            {
                DbContext.Entry(entity).Property(x => x.ProgramSteps).IsModified = false;
            }
        }
    }
}