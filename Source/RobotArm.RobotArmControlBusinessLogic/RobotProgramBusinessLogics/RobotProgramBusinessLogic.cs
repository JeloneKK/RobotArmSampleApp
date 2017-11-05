using System;
using RobotArm.BusinessLogicInterfaces.RobotArmControl;
using RobotArm.Data.Entities.RobotArmControl;
using RobotArm.RepositoriesInterfaces.RobotArmControl;

namespace RobotArm.RobotArmControlBusinessLogic.RobotProgramBusinessLogics
{
    public class RobotProgramBusinessLogic : IRobotProgramBusinessLogic
    {
        private IRobotProgramRepository _robotProgramRepository;

        public RobotProgramBusinessLogic(IRobotProgramRepository robotProgramRepository)
        {
            _robotProgramRepository = robotProgramRepository;
        }

        public RobotProgram[] GetPrograms()
        {
            throw new NotImplementedException();
        }

        public RobotProgram GetProgram(Guid id)
        {
            throw new NotImplementedException();
        }

        public void DeleteProgram(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProgram(RobotProgram program)
        {
            throw new NotImplementedException();
        }

        public void AddProgram(RobotProgram program)
        {
            throw new NotImplementedException();
        }
    }
}