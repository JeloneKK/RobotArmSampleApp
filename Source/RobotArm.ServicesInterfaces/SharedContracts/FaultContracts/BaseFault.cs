using System.Runtime.Serialization;

namespace RobotArm.ServicesContracts.SharedContracts.FaultContracts
{
    [DataContract]
    public class BaseFault
    {
        [DataMember]
        public string Message { get; set; }
    }
}