using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RobotArm.WebApp.ViewModels.UserManagement
{
    public class LoginViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }              
    }
}