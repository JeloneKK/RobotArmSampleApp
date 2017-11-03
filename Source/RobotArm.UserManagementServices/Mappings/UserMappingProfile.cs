﻿using AutoMapper;
using Microsoft.AspNet.Identity;
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

            CreateMap<ApplicationUser, UserDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.CreationTime, opt => opt.Ignore());

            CreateMap<UserDto, ApplicationUser>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(s => new PasswordHasher().HashPassword(s.Password)))
                .ForMember(dest => dest.Roles, opt => opt.Ignore());
        }
    }
}