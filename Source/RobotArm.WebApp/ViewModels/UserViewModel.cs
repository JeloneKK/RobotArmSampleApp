using System.ComponentModel.DataAnnotations;

namespace RobotArm.WebApp.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}