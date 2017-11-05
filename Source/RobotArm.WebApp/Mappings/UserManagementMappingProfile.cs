using AutoMapper;
using RobotArm.Data.Entities.UserManagement;
using RobotArm.ServicesClients.UserManagement;
using RobotArm.ServicesContracts.UserManagement.DataContracts;
using RobotArm.WebApp.ViewModels;
using RobotArm.WebApp.ViewModels.UserManagement;

namespace RobotArm.WebApp.Mappings
{
    public class UserManagementMappingProfile : Profile
    {
        public override string ProfileName => nameof(UserManagementMappingProfile);

        public UserManagementMappingProfile()
        {
            CreateMap<UserDto, UserViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.UserId));
            CreateMap<UserViewModel, UserDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(s => s.Id));

            CreateMap<RoleDto, RoleViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.RoleId));
            CreateMap<RoleViewModel, RoleDto>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(s => s.Id));

            CreateMap<UserDetailsViewModel, UserDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(s => s.User.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(s => s.User.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(s => s.User.Email))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(s => s.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(s => s.User.LastName))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(s => s.Password))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(s => s.Roles));
        }
    }
}