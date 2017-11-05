using System;
using System.Runtime.Serialization;

namespace RobotArm.ServicesContracts.UserManagement.DataContracts
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public RoleDto[] Roles { get; set; }
        [DataMember]
        public DateTime CreationTime { get; set; }
    }
}