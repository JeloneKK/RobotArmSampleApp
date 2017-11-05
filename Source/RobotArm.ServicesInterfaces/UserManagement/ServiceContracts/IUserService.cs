using System.Collections.Generic;
using System.ServiceModel;
using RobotArm.ServicesContracts.UserManagement.DataContracts;

namespace RobotArm.ServicesContracts.UserManagement.ServiceContracts
{
    [ServiceContract]
    public interface IUserService
    {       
        [OperationContract]
        UserDto GetUser(string userId);
        [OperationContract]
        UserDto[] GetAllUsers();
        [OperationContract]
        RoleDto[] GetUserRoles(string userId);
        [OperationContract]
        void CreateUser(UserDto user);
        [OperationContract]
        void UpdateUser(UserDto user);
        [OperationContract]
        void DeleteUser(string userId);
    }
}