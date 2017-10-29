using System.Collections.Generic;
using RobotArm.Data.Entities.UserManagement;

namespace RobotArm.BusinessLogicInterfaces.UserManagement
{
    public interface IUserBusinessLogic
    {
        User GetUser(int userId);
        List<Role> GetUserRoles(int userId);
        void CreateUser(User user);
    }
}