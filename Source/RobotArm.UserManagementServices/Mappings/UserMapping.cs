using AutoMapper;
using RobotArm.Data.Entities.UserManagement;
using RobotArm.ServicesContracts.UserManagement.DataContracts;

namespace RobotArm.UserManagementServices.Mappings
{
    public class UserMapping : Profile
    {
        public override string ProfileName => nameof(UserMapping);

        protected void Configure()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());

            CreateMap<UserDto, User>()
                .ForMember(dest => dest.HashPassword, opt => opt.Ignore())
                .ForMember(dest => dest.Roles, opt => opt.Ignore());

            CreateMap<Role, RoleDto>(MemberList.Destination);

            CreateMap<RoleDto, Role>(MemberList.Source);
        }
    }
}