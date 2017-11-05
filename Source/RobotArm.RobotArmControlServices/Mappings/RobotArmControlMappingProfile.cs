using AutoMapper;
using RobotArm.Data.Entities.RobotArmControl;
using RobotArm.ServicesContracts.RobotArmControl.DataContracts;

namespace RobotArm.RobotArmControlServices.Mappings
{
    public class RobotArmControlMappingProfile : Profile
    {
        public RobotArmControlMappingProfile()
        {
            CreateMap<RobotProgram, RobotProgramDto>().ReverseMap();

            CreateMap<ProgramStep, ProgramStepDto>();
            CreateMap<ProgramStepDto, ProgramStep>()
                .ForMember(dest => dest.Program, opt => opt.MapFrom(s => new RobotProgram { Id = s.ProgramId }));

            CreateMap<StepDefinition, StepDefinitionDto>().ReverseMap();

            CreateMap<CartesianPoint, CartesianPointDto>().ReverseMap();

            CreateMap<JointPoint, JointPointDto>().ReverseMap();
        }
    }
}