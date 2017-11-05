using System.Linq;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RobotArm.Data.Entities.UserManagement;
using RobotArm.ServicesContracts.UserManagement.DataContracts;

namespace RobotArm.UserManagementServices.Mappings
{
    public class UserMappingProfile : Profile
    {
        public override string ProfileName => nameof(UserMappingProfile);

        public UserMappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());

            CreateMap<UserDto, User>()
                .ForMember(dest => dest.HashPassword, opt => opt.Ignore())
                .ForMember(dest => dest.Roles, opt => opt.Ignore());

            CreateMap<Role, RoleDto>(MemberList.Destination);

            CreateMap<RoleDto, Role>(MemberList.Source);

            CreateMap<ApplicationUser, ApplicationUser>();
            CreateMap<IdentityUserLogin, IdentityUserLogin>();
            CreateMap<IdentityUserRole, IdentityUserRole>();
            CreateMap<IdentityUserClaim, IdentityUserClaim>();

            CreateMap<ApplicationUser, UserDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(s => s.UserName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(s => s.Id))
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.Roles, opt => opt.Ignore())
                .ForMember(dest => dest.CreationTime, opt => opt.Ignore());

            CreateMap<UserDto, ApplicationUser>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.UserId))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(s => s.UserName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(s => false))
                .ForMember(dest => dest.PhoneNumberConfirmed, opt => opt.MapFrom(s => false))
                .ForMember(dest => dest.TwoFactorEnabled, opt => opt.MapFrom(s => false))
                .ForMember(dest => dest.LockoutEnabled, opt => opt.MapFrom(s => false))
                .ForMember(dest => dest.AccessFailedCount, opt => opt.MapFrom(s => false))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(s => new PasswordHasher().HashPassword(s.Password)))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(s => s.Roles.Select(r => new IdentityUserRole { UserId = s.UserId, RoleId = r.RoleId })));

            CreateMap<IdentityRole, RoleDto>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(s => s.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.Name));

            CreateMap<RoleDto, IdentityRole>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.RoleId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.Name));
        }
    }
}