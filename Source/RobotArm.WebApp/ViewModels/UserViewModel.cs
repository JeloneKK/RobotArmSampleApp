using System.ComponentModel.DataAnnotations;

namespace RobotArm.WebApp.ViewModels
{
    public class UserViewModel
    {
        public string Id { get;set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}