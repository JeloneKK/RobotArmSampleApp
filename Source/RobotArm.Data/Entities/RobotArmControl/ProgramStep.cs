using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobotArm.Data.Entities.RobotArmControl
{
    public class ProgramStep
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(Program))]
        public Guid ProgramId { get; set; }
        [ForeignKey(nameof(Step))]
        public Guid StepDefinitionId { get; set; }

        public virtual RobotProgram Program { get; set; }
        public virtual StepDefinition Step { get; set; }
        public virtual ICollection<JointPoint> JointPoints { get; set; }
        public virtual ICollection<CartesianPoint> CartesianPoints { get; set; }       
    }
}