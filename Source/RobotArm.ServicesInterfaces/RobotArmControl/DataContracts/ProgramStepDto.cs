using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using RobotArm.Data.Entities.RobotArmControl;

namespace RobotArm.ServicesContracts.RobotArmControl.DataContracts
{
    [DataContract]
    public class ProgramStepDto
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Guid StepDefinitionId { get; set; }
        [DataMember]
        public StepDefinitionDto Step { get; set; }
        [DataMember]
        public JointPointDto[] JointPoints { get; set; }
        [DataMember]
        public CartesianPointDto[] CartesianPoints { get; set; }

        [DataMember]
        public Guid ProgramId { get; set; }
    }
}