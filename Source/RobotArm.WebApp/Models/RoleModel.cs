using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.Web;
using AutoMapper;
using RobotArm.ServicesClients.UserManagement.Role;
using RobotArm.ServicesContracts.UserManagement.DataContracts;
using RobotArm.WebApp.Models.Interfaces;
using RobotArm.WebApp.ViewModels;
using RobotArm.WebApp.ViewModels.UserManagement;

namespace RobotArm.WebApp.Models
{
    public class RoleModel : IRoleModel
    {
        private readonly IRoleService _roleService;

        public RoleModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public List<RoleViewModel> GetAllRoles()
        {
            try
            {
                RoleDto[] roles = _roleService.GetAllRoles();
                return Mapper.Map<List<RoleViewModel>>(roles);
            }
            catch (FaultException ex)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public void AddRole(RoleViewModel role)
        {
            try
            {
                RoleDto roleDto = Mapper.Map<RoleDto>(role);

                _roleService.CreateRole(roleDto);
            }
            catch (FaultException ex)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, "Error occured while creating role", ex);
            }
        }

        public void DeleteRole(string roleId)
        {
            try
            {
                _roleService.DeleteRole(roleId);
            }
            catch (FaultException ex)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, "Error occured while deleting role", ex);
            }
        }
    }
}