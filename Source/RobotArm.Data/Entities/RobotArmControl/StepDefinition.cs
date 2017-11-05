using System;

namespace RobotArm.Data.Entities.RobotArmControl
{
    public class StepDefinition
    {
        public Guid Id { get; set; }
        public int BusinessId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}