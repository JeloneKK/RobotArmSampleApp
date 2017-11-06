using System;
using System.Runtime.Serialization;

namespace RobotArm.ServicesContracts.RobotArmControl.DataContracts
{
    [DataContract]
    public class JointPointDto
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double N1 { get; set; }
        [DataMember]
        public double N2 { get; set; }
        [DataMember]
        public double N3 { get; set; }
        [DataMember]
        public double N4 { get; set; }
        [DataMember]
        public double N5 { get; set; }
        [DataMember]
        public double N6 { get; set; }
        [DataMember]
        public Guid StepId { get; set; }
    }
}