using System.ComponentModel.DataAnnotations;

namespace RobotArm.WebApp.ViewModels
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Role Name")]
        public string Name { get; set; }
    }
}