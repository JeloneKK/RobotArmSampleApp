using AutoMapper;

namespace RobotArm.RobotArmControlServices.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<RobotArmControlMappingProfile>();
            });
        }
    }
}