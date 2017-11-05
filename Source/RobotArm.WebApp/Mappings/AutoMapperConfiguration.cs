using AutoMapper;

namespace RobotArm.WebApp.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<UserManagementMappingProfile>();
                x.AddProfile<RobotArmControlMappingProfile>();
            });
        }
    }
}