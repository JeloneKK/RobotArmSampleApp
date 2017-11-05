using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using RobotArm.Data.Configurations.RobotArmControl;
using RobotArm.Data.Entities.RobotArmControl;

namespace RobotArm.Data.DbContexts.RobotArmControl
{
    public class RobotArmControlDbContext : DbContext
    {
        public RobotArmControlDbContext()
            : base(ConfigurationManager.ConnectionStrings["RobotArmControl"].ConnectionString)
        {
            
        }

        public virtual DbSet<RobotProgram> RobotProgram { get; set; }
        public virtual DbSet<ProgramStep> ProgramStep { get; set; }
        public virtual DbSet<StepDefinition> StepDefinition { get; set; }
        public virtual DbSet<CartesianPoint> CartesianPoint { get; set; }
        public virtual DbSet<JointPoint> JointPoint { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RobotProgramConfiguration());
            modelBuilder.Configurations.Add(new ProgramStepConfiguration());
            modelBuilder.Configurations.Add(new StepDefinitionConfiguration());
            modelBuilder.Configurations.Add(new CartesianPointConfiguration());
            modelBuilder.Configurations.Add(new JointPointConfiguration());
        }
    }
}