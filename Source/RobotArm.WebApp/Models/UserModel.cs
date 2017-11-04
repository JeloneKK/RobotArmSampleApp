using System.Net;
using System.ServiceModel;
using System.Web;
using AutoMapper;
using RobotArm.ServicesClients.UserManagement;
using RobotArm.ServicesContracts.UserManagement.FaultContracts;
using RobotArm.WebApp.Models.Interfaces;
using RobotArm.WebApp.ViewModels;

namespace RobotArm.WebApp.Models
{
    public class UserModel : IUserModel
    {
        private readonly IUserService _userService;

        public UserModel(IUserService userService)
        {
            _userService = userService;
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
                throw new HttpException((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public UserViewModel Get(int userId)
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
                throw new HttpException((int)HttpStatusCode.InternalServerError, "Error occured while getting users", ex);
            }
        }

        public void Update(UserViewModel user)
        {
            throw new System.NotImplementedException();
        }

        public void Create(UserViewModel user)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}