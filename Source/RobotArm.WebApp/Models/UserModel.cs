﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Web;
using AutoMapper;
using RobotArm.ServicesClients.UserManagement;
using RobotArm.ServicesClients.UserManagement.Role;
using RobotArm.ServicesClients.UserManagement.User;
using RobotArm.ServicesContracts.SharedContracts.FaultContracts;
using RobotArm.ServicesContracts.UserManagement.DataContracts;
using RobotArm.WebApp.Models.Interfaces;
using RobotArm.WebApp.ViewModels;
using RobotArm.WebApp.ViewModels.UserManagement;

namespace RobotArm.WebApp.Models
{
    public class UserModel : IUserModel
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UserModel(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public UserViewModel[] Get()
        {
            try
            {
                UserDto[] users = _userService.GetAllUsers();
                return Mapper.Map<UserViewModel[]>(users);
            }
            catch (FaultException ex)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public UserViewModel Get(string userId)
        {
            try
            {
                UserDto user = _userService.GetUser(userId);
                return Mapper.Map<UserViewModel>(user);
            }
            catch (FaultException<EntityNotFoundFault> ex)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, ex.Message, ex);
            }
            catch (FaultException ex)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, $"Error occured while getting user {userId}", ex);
            }
        }

        public UserDetailsViewModel GetDetails(string userId)
        {
            UserViewModel user = this.Get(userId);

            try
            {
                RoleDto[] userRoles = _userService.GetUserRoles(userId);
                List<RoleViewModel> roles = Mapper.Map<List<RoleViewModel>>(userRoles);

                return new UserDetailsViewModel
                {
                    User = user,
                    Roles = roles
                };
            }
            catch (FaultException ex)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, "Error occured while getting user details", ex);
            }
        }

        public void Update(UserDetailsViewModel user)
        {
            try
            {
                UserDto userDto = Mapper.Map<UserDto>(user);

                _userService.UpdateUser(userDto);
            }
            catch (FaultException ex)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, "Error occured while getting user details", ex);
            }
        }

        public void Create(UserDetailsViewModel user)
        {
            try
            {
                UserDto userDto = Mapper.Map<UserDto>(user);
                userDto.UserId = Guid.NewGuid().ToString("D");

                _userService.CreateUser(userDto);
            }
            catch (FaultException ex)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, "Error occured while creating user", ex);
            }
        }

        public void Delete(string userId)
        {
            try
            {
                _userService.DeleteUser(userId);
            }
            catch (FaultException ex)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, "Error occured while deleting user", ex);
            }
        }

        public RoleViewModel[] GetAllRoles()
        {
            try
            {
                RoleDto[] roles = _roleService.GetAllRoles();
                return Mapper.Map<RoleViewModel[]>(roles);
            }
            catch (FaultException ex)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public RoleViewModel[] GetRoles(IEnumerable<string> rolesIds)
        {
            return this.GetAllRoles().Where(r => (rolesIds ?? Enumerable.Empty<string>()).Contains(r.Id)).ToArray();
        }
    }
}