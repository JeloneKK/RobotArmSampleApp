using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using RobotArm.Data.Configurations.UserManagement;
using RobotArm.Data.Entities.UserManagement;

namespace RobotArm.Data.DbContexts.UserManagement
{
    public class UserDbContext : DbContext
    {
        public UserDbContext()
            : base(ConfigurationManager.ConnectionStrings["UserManagement"].ConnectionString)
        {
            
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}