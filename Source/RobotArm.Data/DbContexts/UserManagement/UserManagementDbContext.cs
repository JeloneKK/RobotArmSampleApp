using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RobotArm.Data.Configurations.UserManagement;
using RobotArm.Data.Entities.UserManagement;

namespace RobotArm.Data.DbContexts.UserManagement
{
    public class UserManagementDbContext : IdentityDbContext<ApplicationUser>
    {
        public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            //modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
            //modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());
        }
    }
}