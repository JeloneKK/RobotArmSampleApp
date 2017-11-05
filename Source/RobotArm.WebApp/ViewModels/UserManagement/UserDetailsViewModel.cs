using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RobotArm.WebApp.ViewModels.UserManagement
{
    public class UserDetailsViewModel
    {
        public UserViewModel User { get; set; }
        [Display(Name = "Roles")]
        public List<RoleViewModel> Roles { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}