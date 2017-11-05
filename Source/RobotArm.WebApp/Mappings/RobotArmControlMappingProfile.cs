using System;
using AutoMapper;
using RobotArm.ServicesContracts.RobotArmControl.DataContracts;
using RobotArm.WebApp.ViewModels.RobotArmControl;

namespace RobotArm.WebApp.Mappings
{
    public class RobotArmControlMappingProfile : Profile
    {
        public RobotArmControlMappingProfile()
        {
            CreateMap<RobotProgramDto, RobotProgramViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.Id.ToString()));
            CreateMap<RobotProgramViewModel, RobotProgramDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => new Guid(s.Id)));

            CreateMap<ProgramStepDto, ProgramStepViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.Id.ToString()));
            CreateMap<ProgramStepViewModel, ProgramStepDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => new Guid(s.Id)));

            CreateMap<StepDefinitionDto, StepDefinitionViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.Id.ToString()));
            CreateMap<StepDefinitionViewModel, StepDefinitionDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => new Guid(s.Id)));

            CreateMap<CartesianPointDto, CartesianPointViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.Id.ToString()));
            CreateMap<CartesianPointViewModel, CartesianPointDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => new Guid(s.Id)));

            CreateMap<JointPointDto, JointPointViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.Id.ToString()));
            CreateMap<JointPointViewModel, JointPointDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => new Guid(s.Id)));
        }        
    }
}