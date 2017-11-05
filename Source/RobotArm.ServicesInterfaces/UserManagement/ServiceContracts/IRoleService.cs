using System.Collections.Generic;
using System.ServiceModel;
using RobotArm.ServicesContracts.UserManagement.DataContracts;

namespace RobotArm.ServicesContracts.UserManagement.ServiceContracts
{
    [ServiceContract]
    public interface IRoleService
    {
        [OperationContract]
        RoleDto GetRole(string roleId);
        [OperationContract]
        List<RoleDto> GetAllRoles();
        [OperationContract]
        void CreateRole(RoleDto role);
        [OperationContract]
        void DeleteRole(string roleId);
    }
}