using System;
using RobotArm.Data.Entities.RobotArmControl;

namespace RobotArm.BusinessLogicInterfaces.RobotArmControl
{
    public interface IRobotProgramBusinessLogic
    {
        RobotProgram[] GetPrograms();
        RobotProgram GetProgram(Guid id);
        void AddProgram(RobotProgram program);
        void UpdateProgram(RobotProgram program);
        void DeleteProgram(Guid id);

        ProgramStep GetStep(Guid id);
        void AddStep(ProgramStep step);
        void UpdateStep(ProgramStep step);
        void DeleteStep(Guid id);
    }
}