using System;
using System.Runtime.Serialization;

namespace RobotArm.ServicesContracts.RobotArmControl.DataContracts
{
    [DataContract]
    public class CartesianPointDto
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double X { get; set; }
        [DataMember]
        public double Y { get; set; }
        [DataMember]
        public double Z { get; set; }
        [DataMember]
        public double Alpha { get; set; }
        [DataMember]
        public double Beta { get; set; }
        [DataMember]
        public double Gamma { get; set; }
    }
}