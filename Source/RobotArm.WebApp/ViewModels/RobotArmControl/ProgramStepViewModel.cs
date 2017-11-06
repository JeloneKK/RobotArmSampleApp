using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RobotArm.WebApp.ViewModels.RobotArmControl
{
    public class ProgramStepViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Step Type")]
        public StepDefinitionViewModel Step { get; set; }
        public List<JointPointViewModel> JointPoints { get; set; }
        public List<CartesianPointViewModel> CartesianPoints { get; set; }
        public string ProgramId { get; set; }
    }
}