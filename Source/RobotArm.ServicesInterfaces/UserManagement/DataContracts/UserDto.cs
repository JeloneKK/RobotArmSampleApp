using System;
using System.Runtime.Serialization;

namespace RobotArm.ServicesContracts.UserManagement.DataContracts
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public DateTime CreationTime { get; set; }
    }
}