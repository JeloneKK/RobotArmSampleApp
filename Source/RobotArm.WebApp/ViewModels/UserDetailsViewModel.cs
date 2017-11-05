using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RobotArm.WebApp.ViewModels
{
    public class UserDetailsViewModel
    {
        public UserViewModel User { get; set; }
        [Display(Name = "Roles")]
        public List<RoleViewModel> Roles { get; set; }
        public string Password { get; set; }
    }
}