using System.Collections.Generic;
using RobotArm.WebApp.ViewModels;
using RobotArm.WebApp.ViewModels.UserManagement;

namespace RobotArm.WebApp.Models.Interfaces
{
    public interface IUserModel
    {
        UserViewModel[] Get();
        UserViewModel Get(string userId);
        UserDetailsViewModel GetDetails(string userId);
        void Update(UserDetailsViewModel user);
        void Create(UserDetailsViewModel user);
        void Delete(string userId);
        RoleViewModel[] GetAllRoles();
        RoleViewModel[] GetRoles(IEnumerable<string> rolesIds);
    }
}