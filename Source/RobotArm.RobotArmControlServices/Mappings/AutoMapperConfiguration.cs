using System;
using AutoMapper;
using AutoMapper.Configuration;

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

        public static Action<IMapperConfigurationExpression> ConfigAction = cfg =>
        {
            cfg.AddProfile<RobotArmControlMappingProfile>();
        };
    }
}