using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNet.Identity.EntityFramework;
using RobotArm.Data.Entities.UserManagement;

namespace RobotArm.BusinessLogicInterfaces.UserManagement
{
    public interface IUserBusinessLogic
    {
        ApplicationUser GetUser(int userId);
        List<ApplicationUser> GetAllUsers();
        List<IdentityUserRole> GetUserRoles(int userId);
        void CreateUser(ApplicationUser user);
    }
}