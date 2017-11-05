using System;
using System.Collections.Generic;
using RobotArm.WebApp.ViewModels.RobotArmControl;

namespace RobotArm.WebApp.Models.Interfaces
{
    public interface IRobotProgramModel
    {
        List<RobotProgramViewModel> GetPrograms();
        RobotProgramViewModel GetProgram(Guid id);
        void AddProgram(RobotProgramViewModel program);
        void UpdateProgram(RobotProgramViewModel program);
        void DeleteProgram(Guid id);
    }
}