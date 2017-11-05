using System.Collections.Generic;
using System.Web.Mvc;

namespace RobotArm.WebApp.ViewModels
{
    public class CreateEditUserViewModel
    {
        public UserDetailsViewModel UserDetails { get; set; }
        public List<RoleViewModel> AllowedRoles { get; set; }
        public IEnumerable<string> SelectedRoles { get; set; }
    }
}