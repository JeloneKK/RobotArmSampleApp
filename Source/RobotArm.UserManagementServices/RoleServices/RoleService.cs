using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;
using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;
using RobotArm.BusinessLogicInterfaces.UserManagement;
using RobotArm.Common.Logging.Helpers;
using RobotArm.CommonServices.ErrorHandling;
using RobotArm.Data.Entities.UserManagement;
using RobotArm.ServicesContracts.SharedContracts.FaultContracts;
using RobotArm.ServicesContracts.UserManagement.DataContracts;
using RobotArm.ServicesContracts.UserManagement.ServiceContracts;
using RobotArm.UserManagementServices.ErrorHandling;

namespace RobotArm.UserManagementServices.RoleServices
{
    [GlobalErrorHandlerBehaviour(typeof(UserManagementGlobalErrorHandler))]
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

        public void CreateRole(RoleDto role)
        {
            // TODO: Move that validation to business logic layer ?
            if (role == null)
            {
                var fault = new ArgumentFault
                {
                    Message = "Argumnet is null",
                    ArgumentName = nameof(role)
                };

                throw new FaultException<ArgumentFault>(fault);
            }

            IdentityRole userEntity = Mapper.Map<IdentityRole>(role);

            _rolesBusinessLogic.CreateRole(userEntity);
        }

        public void DeleteRole(string roleId)
        {
            _rolesBusinessLogic.DeleteRole(roleId);
        }
    }
}