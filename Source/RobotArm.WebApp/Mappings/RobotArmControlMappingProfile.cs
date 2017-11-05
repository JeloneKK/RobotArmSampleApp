using AutoMapper;
using RobotArm.ServicesContracts.RobotArmControl.DataContracts;
using RobotArm.WebApp.ViewModels.RobotArmControl;

namespace RobotArm.WebApp.Mappings
{
    public class RobotArmControlMappingProfile : Profile
    {
        public RobotArmControlMappingProfile()
        {
            CreateMap<RobotProgramViewModel, RobotProgramDto>().ReverseMap();

            CreateMap<ProgramStepViewModel, ProgramStepDto>().ReverseMap();
        }        
    }
}