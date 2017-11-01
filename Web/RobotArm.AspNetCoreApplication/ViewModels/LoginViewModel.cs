using System.ComponentModel.DataAnnotations;

namespace RobotArm.AspNetCoreApplication.ViewModels
{
    public class LoginViewModel
    {
        [Display(Description = "Username")]
        public string Login { get; set; }
        [Display(Description = "Password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }              
    }
}