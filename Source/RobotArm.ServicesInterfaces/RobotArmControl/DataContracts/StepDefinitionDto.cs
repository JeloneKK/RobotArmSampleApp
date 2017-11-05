using System;
using System.Runtime.Serialization;

namespace RobotArm.ServicesContracts.RobotArmControl.DataContracts
{
    [DataContract]
    public class StepDefinitionDto
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public int BusinessId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}