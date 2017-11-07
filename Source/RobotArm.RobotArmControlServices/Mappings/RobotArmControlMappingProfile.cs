using System;
using AutoMapper;
using RobotArm.Data.Entities.RobotArmControl;
using RobotArm.ServicesContracts.RobotArmControl.DataContracts;

namespace RobotArm.RobotArmControlServices.Mappings
{
    public class RobotArmControlMappingProfile : Profile
    {
        public RobotArmControlMappingProfile()
        {
            CreateMap<RobotProgram, RobotProgramDto>()
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(s => s.CreationDate ?? DateTime.MinValue));
            CreateMap<RobotProgramDto, RobotProgram>()
                .ForMember(dest => dest.CreationDate, opt => opt.Ignore());

            CreateMap<ProgramStep, ProgramStepDto>();
            CreateMap<ProgramStepDto, ProgramStep>()
                .ForMember(dest => dest.Program, opt => opt.Ignore());

            CreateMap<StepDefinition, StepDefinitionDto>().ReverseMap();

            CreateMap<CartesianPoint, CartesianPointDto>();
            CreateMap<CartesianPointDto, CartesianPoint>();

            CreateMap<JointPoint, JointPointDto>();
            CreateMap<JointPointDto, JointPoint>();
        }
    }
}