using AutoMapper;
using RobotArm.Data.Entities.UserManagement;
using RobotArm.ServicesClients.UserManagement;
using RobotArm.WebApp.ViewModels;

namespace RobotArm.WebApp.Mappings
{
    public class UserManagementMapping : Profile
    {
        public override string ProfileName => nameof(UserManagementMapping);

        public UserManagementMapping()
        {
            CreateMap<UserDto, UserViewModel>();
            CreateMap<UserViewModel, UserDto>();
        }
    }
}