using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RobotArm.Data.Configurations.UserManagement
{
    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    { 
        public IdentityUserLoginConfiguration()
        {
            
        }
    }
}