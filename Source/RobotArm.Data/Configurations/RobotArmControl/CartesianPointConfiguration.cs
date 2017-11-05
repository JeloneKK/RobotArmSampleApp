using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using RobotArm.Data.Entities.RobotArmControl;

namespace RobotArm.Data.Configurations.RobotArmControl
{
    public class CartesianPointConfiguration : EntityTypeConfiguration<CartesianPoint>
    {
        public CartesianPointConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Id).IsRequired();
            Property(x => x.Name).IsRequired();
        }
    }
}