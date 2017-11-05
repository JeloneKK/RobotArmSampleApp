using System;
using System.Collections.Generic;
using System.ComponentModel;
using RobotArm.Data.Attributes;

namespace RobotArm.Data.Entities.RobotArmControl
{
    public class RobotProgram
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [DefaultDateTimeValue("Now")]
        public DateTime? CreationDate { get; set; }

        public virtual ICollection<ProgramStep> ProgramSteps { get; set; }
    }
}