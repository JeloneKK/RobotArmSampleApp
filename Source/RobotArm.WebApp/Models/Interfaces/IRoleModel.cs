using System.Collections.Generic;
using RobotArm.WebApp.ViewModels;
using RobotArm.WebApp.ViewModels.UserManagement;

namespace RobotArm.WebApp.Models.Interfaces
{
    public interface IRoleModel
    {
        List<RoleViewModel> GetAllRoles();
        void AddRole(RoleViewModel role);
        void DeleteRole(string roleId);
    }
}