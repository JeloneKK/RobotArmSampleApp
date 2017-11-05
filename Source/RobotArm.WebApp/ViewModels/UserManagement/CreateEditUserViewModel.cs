using System.Collections.Generic;

namespace RobotArm.WebApp.ViewModels.UserManagement
{
    public class CreateEditUserViewModel
    {
        public UserDetailsViewModel UserDetails { get; set; }
        public List<RoleViewModel> AllowedRoles { get; set; }
        public IEnumerable<string> SelectedRoles { get; set; }
    }
}