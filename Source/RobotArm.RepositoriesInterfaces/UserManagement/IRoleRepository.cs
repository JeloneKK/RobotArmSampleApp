using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using RobotArm.Data.Entities.UserManagement;

namespace RobotArm.RepositoriesInterfaces.UserManagement
{
    public interface IRoleRepository : IUserManagementRepository<IdentityRole>
    {
    }
}