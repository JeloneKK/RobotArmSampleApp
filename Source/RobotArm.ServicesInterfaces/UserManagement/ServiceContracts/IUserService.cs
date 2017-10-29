using System.Collections.Generic;
using System.ServiceModel;
using RobotArm.ServicesContracts.UserManagement.DataContracts;

namespace RobotArm.ServicesContracts.UserManagement.ServiceContracts
{
    [ServiceContract]
    public interface IUserService
    {       
        [OperationContract]
        UserDto GetUser(int userId);
        [OperationContract]
        List<RoleDto> GetUserRoles(int userId);
        [OperationContract]
        void CreateUser(UserDto user);
    }
}