using System;
using System.Collections.Generic;

namespace RobotArm.Data.Entities.RobotArmControl
{
    public class RobotProgram
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<ProgramStep> ProgramSteps { get; set; }
    }
}