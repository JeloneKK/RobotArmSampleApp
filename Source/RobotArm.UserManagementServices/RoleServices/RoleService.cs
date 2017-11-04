using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;
using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;
using RobotArm.BusinessLogicInterfaces.UserManagement;
using RobotArm.Common.Logging.Helpers;
using RobotArm.Data.Entities.UserManagement;
using RobotArm.ServicesContracts.UserManagement.DataContracts;
using RobotArm.ServicesContracts.UserManagement.FaultContracts;
using RobotArm.ServicesContracts.UserManagement.ServiceContracts;

namespace RobotArm.UserManagementServices.RoleServices
{
    public class RoleService : UserManagementServiceBase, IRoleService
    {
        private readonly IUserRolesBusinessLogic _rolesBusinessLogic;

        public RoleService(IUserRolesBusinessLogic rolesBusinessLogic)
        {
            _rolesBusinessLogic = rolesBusinessLogic;
        }

        public RoleDto GetRole(string roleId)
        {
            IdentityRole role;

            try
            {
                role = _rolesBusinessLogic.GetRole(roleId);
            }
            catch (ArgumentException ex)
            {
                this.Log.Error(LogHelper.GetMethodInfoErrorMessage(MethodBase.GetCurrentMethod(), roleId), ex);

                var fault = new EntityNotFoundFault
                {
                    Message = "Role not found",
                    EntityName = typeof(IdentityRole).Name
                };

                throw new FaultException<EntityNotFoundFault>(fault);
            }

            RoleDto roleDto = Mapper.Map<RoleDto>(role);

            return roleDto;
        }

        public List<RoleDto> GetAllRoles()
        {
            List<IdentityRole> roles;

            try
            {
                roles = _rolesBusinessLogic.GetAllRoles();
            }
            catch (Exception ex)
            {
                this.Log.Error(LogHelper.GetMethodInfoErrorMessage(MethodBase.GetCurrentMethod()), ex);

                throw new FaultException();
            }

            List<RoleDto> rolesDtos = Mapper.Map<List<RoleDto>>(roles);

            return rolesDtos;
        }
    }
}