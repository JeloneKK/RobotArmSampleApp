using System.Runtime.Serialization;

namespace RobotArm.ServicesContracts.SharedContracts.FaultContracts
{
    [DataContract]
    public class EntityNotFoundFault : BaseFault
    {
        [DataMember]
        public string EntityName { get; set; }
    }
}