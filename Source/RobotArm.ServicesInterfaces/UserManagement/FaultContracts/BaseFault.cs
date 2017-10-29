using System.Runtime.Serialization;

namespace RobotArm.ServicesContracts.UserManagement.FaultContracts
{
    [DataContract]
    public class BaseFault
    {
        [DataMember]
        public string Message { get; set; }
    }
}