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

            CreateMap<RoleDto, RoleViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.RoleId));
            CreateMap<RoleViewModel, RoleDto>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(s => s.Id));
        }
    }
}