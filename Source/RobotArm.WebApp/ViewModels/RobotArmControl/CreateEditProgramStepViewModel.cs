using System.Collections.Generic;
using System.Web.Mvc;

namespace RobotArm.WebApp.ViewModels.RobotArmControl
{
    public class CreateEditProgramStepViewModel
    {
        public ProgramStepViewModel ProgramStep { get; set; }
        public List<SelectListItem> StepDefinitions { get; set; }
    }
}