using System.Collections.Generic;

namespace RobotArm.WebApp.ViewModels
{
    public class UserDetailsViewModel
    {
        public UserViewModel User { get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }
}