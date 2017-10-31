using System;
using System.Collections.Generic;

namespace RobotArm.Data.Entities.UserManagement
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HashPassword { get; set; }
        public DateTime CreationTime { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}