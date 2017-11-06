using System;

namespace RobotArm.WebApp.ViewModels.RobotArmControl
{
    public class CartesianPointViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Alpha { get; set; }
        public double Beta { get; set; }
        public double Gamma { get; set; }
        public string StepId { get; set; }
    }
}