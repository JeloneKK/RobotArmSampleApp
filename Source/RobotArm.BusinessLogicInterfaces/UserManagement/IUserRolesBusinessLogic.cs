using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RobotArm.BusinessLogicInterfaces.UserManagement
{
    public interface IUserRolesBusinessLogic
    {
        List<IdentityRole> GetAllRoles();
        IdentityRole GetRole(string roleId);
        void CreateRole(IdentityRole role);
        void DeleteRole(string roleId);
    }
}