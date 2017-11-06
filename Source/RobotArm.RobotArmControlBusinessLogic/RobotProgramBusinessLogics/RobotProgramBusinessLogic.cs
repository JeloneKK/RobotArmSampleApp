using System;
using System.Linq;
using RobotArm.BusinessLogicInterfaces.RobotArmControl;
using RobotArm.Common.Patterns.DbContext.DbContextScope;
using RobotArm.Common.Patterns.DbContext.DbContextScope.Interfaces;
using RobotArm.Data.Entities.RobotArmControl;
using RobotArm.RepositoriesInterfaces.RobotArmControl;

namespace RobotArm.RobotArmControlBusinessLogic.RobotProgramBusinessLogics
{
    public class RobotProgramBusinessLogic : RobotArmControlBusinessLogicBase, IRobotProgramBusinessLogic
    {
        private readonly IRobotProgramRepository _robotProgramRepository;
        private readonly IProgramStepRepository _programStepRepositor;

        public RobotProgramBusinessLogic(IDbContextScopeFactory dbContextScopeFactory, IRobotProgramRepository robotProgramRepository, IProgramStepRepository programStepRepositor) 
            : base(dbContextScopeFactory)
        {
            _robotProgramRepository = robotProgramRepository;
            _programStepRepositor = programStepRepositor;
        }

        public RobotProgram[] GetPrograms()
        {
            using (DbContextScopeFactory.CreateReadOnly())
            {
                var programs = _robotProgramRepository.GetAll().ToArray();

                // TODO: Refactor // Just materializee it // probably not need to return all data here
                foreach (var program in programs)
                {
                    program.ProgramSteps = program.ProgramSteps.ToArray();

                    foreach (var programStep in program.ProgramSteps)
                    {
                        programStep.Step = programStep.Step;

                        programStep.CartesianPoints = programStep.CartesianPoints.ToArray();
                        programStep.JointPoints = programStep.JointPoints.ToArray();
                    }
                }

                return programs;
            }
        }

        public RobotProgram GetProgram(Guid id)
        {
            using (DbContextScopeFactory.CreateReadOnly())
            {
                var program = _robotProgramRepository.GetById(id.ToString());

                program.ProgramSteps = program.ProgramSteps.ToArray();

                foreach (var programStep in program.ProgramSteps)
                {
                    programStep.Step = programStep.Step;

                    programStep.CartesianPoints = programStep.CartesianPoints.ToArray();
                    programStep.JointPoints = programStep.JointPoints.ToArray();
                }

                return program;
            }
        }

        public void DeleteProgram(Guid id)
        {
            using (var dbContextScope = DbContextScopeFactory.Create())
            {
                _robotProgramRepository.Delete(p => p.Id == id);
                dbContextScope.SaveChanges();
            }
        }

        public void UpdateProgram(RobotProgram program)
        {
            using (var dbContextScope = DbContextScopeFactory.Create())
            {
                _robotProgramRepository.Update(program);
                dbContextScope.SaveChanges();
            }
        }

        public void AddProgram(RobotProgram program)
        {
            using (var dbContextScope = DbContextScopeFactory.Create())
            {
                _robotProgramRepository.Add(program);
                dbContextScope.SaveChanges();
            }
        }

        public ProgramStep GetStep(Guid id)
        {
            using (DbContextScopeFactory.CreateReadOnly())
            {
                var step = _programStepRepositor.GetById(id.ToString());

                step.Program = step.Program;
                step.Step = step.Step;
                step.CartesianPoints = step.CartesianPoints.ToArray();
                step.JointPoints = step.JointPoints.ToArray();

                return step;
            }
        }

        public void AddStep(ProgramStep step)
        {
            using (var dbContextScope = DbContextScopeFactory.Create())
            {
                _programStepRepositor.Add(step);
                dbContextScope.SaveChanges();
            }
        }

        public void UpdateStep(ProgramStep step)
        {
            using (var dbContextScope = DbContextScopeFactory.Create())
            {
                _programStepRepositor.Update(step);
                dbContextScope.SaveChanges();
            }
        }

        public void DeleteStep(Guid id)
        {
            using (var dbContextScope = DbContextScopeFactory.Create())
            {
                _programStepRepositor.Delete(p => p.Id == id);
                dbContextScope.SaveChanges();
            }
        }
    }
}