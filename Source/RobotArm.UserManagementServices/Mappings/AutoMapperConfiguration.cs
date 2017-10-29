using AutoMapper;

namespace RobotArm.UserManagementServices.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<UserMapping>();
            });
        }
    }
}