using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;
using RobotArm.BusinessLogicInterfaces.UserManagement;
using RobotArm.Common.Logging.Helpers;
using RobotArm.Common.Patterns.DbContext;
using RobotArm.Common.ServiceResponses.Helpers;
using RobotArm.Common.ServiceResponses.ResponseData;
using RobotArm.CommonServices.ErrorHandling;
using RobotArm.Data.Entities.UserManagement;
using RobotArm.RepositoriesInterfaces.UserManagement;
using RobotArm.ServicesContracts.UserManagement;
using RobotArm.ServicesContracts.UserManagement.DataContracts;
using RobotArm.ServicesContracts.UserManagement.FaultContracts;
using RobotArm.ServicesContracts.UserManagement.ServiceContracts;
using RobotArm.UserManagementServices.ErrorHandling;

namespace RobotArm.UserManagementServices.UserServices
{
    [GlobalErrorHandlerBehaviour(typeof(UserManagementGlobalErrorHandler))]
    public class UserService : UserManagementServiceBase, IUserService
    {
        private readonly IUserBusinessLogic _userBusinessLogic;

        public UserService(IUserBusinessLogic userBusinessLogic)
            : base()
        {
            _userBusinessLogic = userBusinessLogic;
        }

        public UserDto GetUser(string userId)
        {
            ApplicationUser user;

            try
            {
                user = _userBusinessLogic.GetUser(userId);
            }
            catch (ArgumentException ex)
            {                
                this.Log.Error(LogHelper.GetMethodInfoErrorMessage(MethodBase.GetCurrentMethod(), userId), ex);

                var fault = new EntityNotFoundFault
                {
                    Message = "User not found",
                    EntityName = typeof(User).Name
                };

                throw new FaultException<EntityNotFoundFault>(fault);
            }

            UserDto userDto = Mapper.Map<UserDto>(user);

            return userDto;
        }

        public UserDto[] GetAllUsers()
        {
            List<ApplicationUser> users;

            try
            {
                users = _userBusinessLogic.GetAllUsers();
            }
            catch (Exception ex)
            {
                this.Log.Error(LogHelper.GetMethodInfoErrorMessage(MethodBase.GetCurrentMethod()), ex);

                throw new FaultException();
            }

            UserDto[] usersDtos = Mapper.Map<UserDto[]>(users);

            return usersDtos;
        }

        public RoleDto[] GetUserRoles(string userId)
        {
            List<IdentityRole> roles;

            try
            {
                roles = _userBusinessLogic.GetUserRoles(userId);
            }
            catch (ArgumentException ex)
            {
                this.Log.Error(LogHelper.GetMethodInfoErrorMessage(MethodBase.GetCurrentMethod(), userId), ex);

                var fault = new EntityNotFoundFault
                {
                    Message = "User not found",
                    EntityName = typeof(ApplicationUser).Name
                };

                throw new FaultException<EntityNotFoundFault>(fault);
            }

            RoleDto[] rolesDto = Mapper.Map<RoleDto[]>(roles);

            return rolesDto;
        }

        public void CreateUser(UserDto user)
        {
            if (user == null)
            {
                var fault = new ArgumentFault
                {
                    Message = "Argumnet is null",
                    ArgumentName = nameof(user)
                };

                throw new FaultException<ArgumentFault>(fault);
            }

            ApplicationUser userEntity = Mapper.Map<ApplicationUser>(user);

            _userBusinessLogic.CreateUser(userEntity);
        }

        public void UpdateUser(UserDto user)
        {
            if (user == null)
            {
                var fault = new ArgumentFault
                {
                    Message = "Argumnet is null",
                    ArgumentName = nameof(user)
                };

                throw new FaultException<ArgumentFault>(fault);
            }

            ApplicationUser userEntity = Mapper.Map<ApplicationUser>(user);

            _userBusinessLogic.UpdateUser(userEntity);
        }

        public void DeleteUser(string userId)
        {
            _userBusinessLogic.DeleteUser(userId);
        }
    }
}