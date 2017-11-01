using System.Data.Entity.ModelConfiguration;
using RobotArm.Data.Entities.UserManagement;

namespace RobotArm.Data.Configurations.UserManagement
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            ToTable("Test");
        }
    }
}