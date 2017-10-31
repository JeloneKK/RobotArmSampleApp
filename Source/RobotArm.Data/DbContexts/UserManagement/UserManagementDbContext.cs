using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using RobotArm.Data.Configurations.UserManagement;
using RobotArm.Data.DbContexts.Identity;
using RobotArm.Data.Entities.Identity;
using RobotArm.Data.Entities.UserManagement;

namespace RobotArm.Data.DbContexts.UserManagement
{
    public class UserManagementDbContext : IdentityDbContext<ApplicationUser>
    {
        public UserManagementDbContext()
            : base(ConfigurationManager.ConnectionStrings["UserManagement"].ConnectionString)
        {
            
        }

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