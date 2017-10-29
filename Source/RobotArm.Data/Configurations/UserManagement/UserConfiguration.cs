using System.Data.Entity.ModelConfiguration;
using RobotArm.Data.Entities.UserManagement;

namespace RobotArm.Data.Configurations.UserManagement
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(u => u.Login).IsRequired().HasMaxLength(40);
            Property(u => u.HashPassword).IsRequired().HasMaxLength(40);
            Property(u => u.FirstName).HasMaxLength(40);
            Property(u => u.LastName).HasMaxLength(40);

            this.Map(map =>
            {
                map.Properties(u => new
                {
                    u.UserId,
                    u.Login,
                    u.HashPassword
                });
                map.ToTable("Users");
            });

            this.Map(map =>
            {
                map.Properties(u => new
                {
                    u.FirstName,
                    u.LastName
                });
                map.ToTable("UserDetails");
            });
        }
    }
}