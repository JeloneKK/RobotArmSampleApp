using System.ComponentModel.DataAnnotations;

namespace RobotArm.WebApp.ViewModels.RobotArmControl
{
    public class JointPointViewModel
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double N1 { get; set; }
        public double N2 { get; set; }
        public double N3 { get; set; }
        public double N4 { get; set; }
        public double N5 { get; set; }
        public double N6 { get; set; }
        public string StepId { get; set; }
    }
}