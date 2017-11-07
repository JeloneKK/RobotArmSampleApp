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

        ProgramStepViewModel GetStep(Guid id);
        void AddStep(ProgramStepViewModel step);
        void UpdateStep(ProgramStepViewModel step);
        void DeleteStep(Guid id);

        void AddCartesianPoint(CartesianPointViewModel point);
        void UpdateCartesianPoint(CartesianPointViewModel point);
        void DeleteCartesianPoint(Guid id);

        void AddJointPoint(JointPointViewModel point);
        void UpdateJointPoint(JointPointViewModel point);
        void DeleteJointPoint(Guid id);

        List<StepDefinitionViewModel> GetStepDefinitions();
    }
}