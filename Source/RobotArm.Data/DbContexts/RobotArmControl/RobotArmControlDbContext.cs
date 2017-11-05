using System.Configuration;
using System.Data.Entity;
using RobotArm.Data.Configurations.RobotArmControl;

namespace RobotArm.Data.DbContexts.RobotArmControl
{
    public class RobotArmControlDbContext : DbContext
    {
        public RobotArmControlDbContext()
            : base(ConfigurationManager.ConnectionStrings["RobotArmControl"].ConnectionString)
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RobotProgramConfiguration());
        }
    }
}