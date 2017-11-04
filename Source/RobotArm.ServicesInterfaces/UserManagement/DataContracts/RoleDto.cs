using System.Runtime.Serialization;

namespace RobotArm.ServicesContracts.UserManagement.DataContracts
{
    [DataContract]
    public class RoleDto
    {
        [DataMember]
        public string RoleId { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}