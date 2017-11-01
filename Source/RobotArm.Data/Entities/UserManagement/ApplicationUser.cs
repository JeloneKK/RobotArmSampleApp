using Microsoft.AspNet.Identity.EntityFramework;

namespace RobotArm.Data.Entities.UserManagement
{
    public class ApplicationUser : IdentityUser
    {
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
    }
}