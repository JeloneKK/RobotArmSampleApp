using System;
using System.ServiceModel;
using RobotArm.Data.Entities.RobotArmControl;
using RobotArm.ServicesContracts.RobotArmControl.DataContracts;

namespace RobotArm.ServicesContracts.RobotArmControl.ServiceContracts
{
    [ServiceContract]
    public interface IRobotProgramService
    {
        [OperationContract]
        RobotProgramDto[] GetPrograms();
        [OperationContract]
        RobotProgramDto GetProgram(Guid id);
        [OperationContract]
        void AddProgram(RobotProgramDto program);
        [OperationContract]
        void UpdateProgram(RobotProgramDto program);
        [OperationContract]
        void DeleteProgram(Guid id);

        [OperationContract]
        ProgramStepDto GetStep(Guid id);
        [OperationContract]
        void AddStep(ProgramStepDto step);
        [OperationContract]
        void UpdateStep(ProgramStepDto step);
        [OperationContract]
        void DeleteStep(Guid id);
    }
}