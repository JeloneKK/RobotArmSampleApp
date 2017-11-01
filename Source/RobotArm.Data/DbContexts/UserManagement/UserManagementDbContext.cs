using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using RobotArm.Data.Configurations.UserManagement;
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            //modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
            //modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}