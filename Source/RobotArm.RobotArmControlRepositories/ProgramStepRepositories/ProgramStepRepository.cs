using System.Data.Entity;
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

        public override void Update(ProgramStep entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;

            DbContext.Entry(entity).Property(x => x.Program).IsModified = false;

            if (entity.CartesianPoints == null)
            {
                DbContext.Entry(entity).Property(x => x.CartesianPoints).IsModified = false;
            }

            if (entity.JointPoints == null)
            {
                DbContext.Entry(entity).Property(x => x.JointPoints).IsModified = false;
            }
        }
    }
}