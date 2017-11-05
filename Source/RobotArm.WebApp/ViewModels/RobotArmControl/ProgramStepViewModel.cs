using System.Collections.Generic;

namespace RobotArm.WebApp.ViewModels.RobotArmControl
{
    public class ProgramStepViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public StepDefinitionViewModel Step { get; set; }
        public List<JointPointViewModel> JointPoints { get; set; }
        public List<CartesianPointViewModel> CartesianPoints { get; set; }
        public string ProgramId { get; set; }
    }
}