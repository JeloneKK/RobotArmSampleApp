using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNet.Identity.EntityFramework;
using RobotArm.Data.Entities.UserManagement;

namespace RobotArm.BusinessLogicInterfaces.UserManagement
{
    public interface IUserBusinessLogic
    {
        ApplicationUser GetUser(string userId);
        List<ApplicationUser> GetAllUsers();
        List<IdentityRole> GetUserRoles(string userId);
        void CreateUser(ApplicationUser user);
    }
}