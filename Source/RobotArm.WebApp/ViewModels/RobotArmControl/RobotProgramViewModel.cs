using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RobotArm.ServicesContracts.RobotArmControl.DataContracts;

namespace RobotArm.WebApp.ViewModels.RobotArmControl
{
    public class RobotProgramViewModel
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<ProgramStepViewModel> ProgramSteps { get; set; }
    }
}