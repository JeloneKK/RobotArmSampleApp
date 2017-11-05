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

        public RobotProgramBusinessLogic(IDbContextScopeFactory dbContextScopeFactory, IRobotProgramRepository robotProgramRepository) 
            : base(dbContextScopeFactory)
        {
            _robotProgramRepository = robotProgramRepository;
        }

        public RobotProgram[] GetPrograms()
        {
            using (DbContextScopeFactory.CreateReadOnly())
            {
                return _robotProgramRepository.GetAll().ToArray();
            }
        }

        public RobotProgram GetProgram(Guid id)
        {
            using (DbContextScopeFactory.CreateReadOnly())
            {
                return _robotProgramRepository.GetById(id.ToString());
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
    }
}