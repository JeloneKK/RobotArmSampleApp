using System;
using System.Collections.Generic;
using RobotArm.ServicesContracts.RobotArmControl.DataContracts;

namespace RobotArm.WebApp.ViewModels.RobotArmControl
{
    public class RobotProgramViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<ProgramStepViewModel> ProgramSteps { get; set; }
    }
}