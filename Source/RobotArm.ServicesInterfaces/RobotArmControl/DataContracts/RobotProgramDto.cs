using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using RobotArm.Data.Entities.RobotArmControl;

namespace RobotArm.ServicesContracts.RobotArmControl.DataContracts
{
    [DataContract]
    public class RobotProgramDto
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime CreationDate { get; set; }
        [DataMember]
        public ProgramStepDto[] ProgramSteps { get; set; }
    }
}