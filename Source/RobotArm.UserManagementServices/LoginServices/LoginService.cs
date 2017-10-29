using System;
using System.Collections.Generic;
using System.Linq;
using RobotArm.Common.Patterns.DbContext;
using RobotArm.Common.ServiceResponses.ResponseData;
using RobotArm.Data.Entities.UserManagement;
using RobotArm.RepositoriesInterfaces.UserManagement;
using RobotArm.ServicesContracts.UserManagement;
using RobotArm.ServicesContracts.UserManagement.ServiceContracts;

namespace RobotArm.UserManagementServices.LoginServices
{
    public class LoginService : UserManagementServiceBase, ILoginService
    {
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository) 
            : base()
        {
            _userRepository = userRepository;
        }

        public void Login(string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}