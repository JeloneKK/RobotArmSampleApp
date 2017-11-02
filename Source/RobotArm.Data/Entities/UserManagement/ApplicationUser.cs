using Microsoft.AspNet.Identity.EntityFramework;

namespace RobotArm.Data.Entities.UserManagement
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}