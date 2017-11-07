using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobotArm.Data.Entities.RobotArmControl
{
    public class CartesianPoint
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Alpha { get; set; }
        public double Beta { get; set; }
        public double Gamma { get; set; }
        [ForeignKey(nameof(Step))]
        public Guid StepId { get; set; }

        public virtual ProgramStep Step { get; set; }
    }
}