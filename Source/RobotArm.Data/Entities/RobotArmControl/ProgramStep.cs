using System;
using System.Collections.Generic;

namespace RobotArm.Data.Entities.RobotArmControl
{
    public class ProgramStep
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual StepDefinition Step { get; set; }
        public virtual ICollection<JointPoint> JointPoints { get; set; }
        public virtual ICollection<CartesianPoint> CartesianPoints { get; set; }       
    }
}