using System.Runtime.Serialization;

namespace RobotArm.ServicesContracts.UserManagement.FaultContracts
{
    [DataContract]
    public class ArgumentFault : BaseFault
    {
        [DataMember]
        public string ArgumentName { get; set; }
    }
}