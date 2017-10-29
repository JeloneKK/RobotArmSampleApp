using AutoMapper;
using RobotArm.Data.Entities.UserManagement;
using RobotArm.ServicesContracts.UserManagement.DataContracts;
using RobotArm.WebApp.ViewModels;

namespace RobotArm.WebApp.Mappings
{
    public class UserManagementMapping : Profile
    {
        public override string ProfileName => nameof(UserManagementMapping);

        protected void Configure()
        {
            CreateMap<UserDto, UserViewModel>();
            CreateMap<UserViewModel, UserDto>();
        }
    }
}