using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobotArm.Data.Entities.RobotArmControl
{
    public class JointPoint
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double N1 { get; set; }
        public double N2 { get; set; }
        public double N3 { get; set; }
        public double N4 { get; set; }
        public double N5 { get; set; }
        public double N6 { get; set; }
        [ForeignKey(nameof(Step))]
        public Guid StepId { get; set; }

        public virtual ProgramStep Step { get; set; }
    }
}