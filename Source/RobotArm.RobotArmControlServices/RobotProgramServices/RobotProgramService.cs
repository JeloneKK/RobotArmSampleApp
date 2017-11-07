using System;
using System.Reflection;
using System.ServiceModel;
using AutoMapper;
using RobotArm.BusinessLogicInterfaces.RobotArmControl;
using RobotArm.Common.Logging.Helpers;
using RobotArm.CommonServices.ErrorHandling;
using RobotArm.Data.Entities.RobotArmControl;
using RobotArm.Data.Entities.UserManagement;
using RobotArm.RobotArmControlServices.ErrorHandling;
using RobotArm.ServicesContracts.RobotArmControl.DataContracts;
using RobotArm.ServicesContracts.RobotArmControl.ServiceContracts;
using RobotArm.ServicesContracts.SharedContracts.FaultContracts;
using RobotArm.ServicesContracts.UserManagement.DataContracts;

namespace RobotArm.RobotArmControlServices.RobotProgramServices
{
    [GlobalErrorHandlerBehaviour(typeof(RobotArmControlGlobalErrorHandler))]
    public class RobotProgramService : RobotArmControlServiceBase, IRobotProgramService
    {
        private readonly IRobotProgramBusinessLogic _robotProgramBusinessLogic;

        public RobotProgramService(IRobotProgramBusinessLogic robotProgramBusinessLogic)
        {
            _robotProgramBusinessLogic = robotProgramBusinessLogic;
        }

        public RobotProgramDto[] GetPrograms()
        {
            RobotProgram[] robotPrograms;

            try
            {
                robotPrograms = _robotProgramBusinessLogic.GetPrograms();
            }
            catch (Exception ex)
            {
                this.Log.Error(LogHelper.GetMethodInfoErrorMessage(MethodBase.GetCurrentMethod()), ex);

                throw new FaultException();
            }

            RobotProgramDto[] robotProgramDtos = Mapper.Map<RobotProgramDto[]>(robotPrograms);

            return robotProgramDtos;
        }

        public RobotProgramDto GetProgram(Guid id)
        {
            RobotProgram robotProgram;

            try
            {
                robotProgram = _robotProgramBusinessLogic.GetProgram(id);
            }
            catch (ArgumentException ex)
            {
                this.Log.Error(LogHelper.GetMethodInfoErrorMessage(MethodBase.GetCurrentMethod(), id), ex);

                var fault = new EntityNotFoundFault
                {
                    Message = "Robot program not found",
                    EntityName = typeof(RobotProgram).Name
                };

                throw new FaultException<EntityNotFoundFault>(fault);
            }

            RobotProgramDto programDto = Mapper.Map<RobotProgramDto>(robotProgram);

            return programDto;
        }

        public void AddProgram(RobotProgramDto program)
        {
            if (program == null)
            {
                var fault = new ArgumentFault
                {
                    Message = "Argumnet is null",
                    ArgumentName = nameof(program)
                };

                throw new FaultException<ArgumentFault>(fault);
            }

            RobotProgram programEntity = Mapper.Map<RobotProgram>(program);

            _robotProgramBusinessLogic.AddProgram(programEntity);
        }

        public void UpdateProgram(RobotProgramDto program)
        {
            if (program == null)
            {
                var fault = new ArgumentFault
                {
                    Message = "Argumnet is null",
                    ArgumentName = nameof(program)
                };

                throw new FaultException<ArgumentFault>(fault);
            }

            RobotProgram programEntity = Mapper.Map<RobotProgram>(program);

            _robotProgramBusinessLogic.UpdateProgram(programEntity);
        }

        public void DeleteProgram(Guid id)
        {
            _robotProgramBusinessLogic.DeleteProgram(id);
        }

        public ProgramStepDto GetStep(Guid id)
        {
            ProgramStep programStep;

            try
            {
                programStep = _robotProgramBusinessLogic.GetStep(id);
            }
            catch (ArgumentException ex)
            {
                this.Log.Error(LogHelper.GetMethodInfoErrorMessage(MethodBase.GetCurrentMethod(), id), ex);

                var fault = new EntityNotFoundFault
                {
                    Message = "Step program not found",
                    EntityName = typeof(ProgramStep).Name
                };

                throw new FaultException<EntityNotFoundFault>(fault);
            }

            ProgramStepDto stepDto = Mapper.Map<ProgramStepDto>(programStep);

            return stepDto;
        }

        public void AddStep(ProgramStepDto step)
        {
            // TODO: null-possibility should rather be checked in Buisness logic, and here just try-catch-toFaultConv
            if (step == null)
            {
                var fault = new ArgumentFault
                {
                    Message = "Argumnet is null",
                    ArgumentName = nameof(step)
                };

                throw new FaultException<ArgumentFault>(fault);
            }

            ProgramStep stepEntity = Mapper.Map<ProgramStep>(step);

            _robotProgramBusinessLogic.AddStep(stepEntity);
        }

        public void UpdateStep(ProgramStepDto step)
        {
            if (step == null)
            {
                var fault = new ArgumentFault
                {
                    Message = "Argumnet is null",
                    ArgumentName = nameof(step)
                };

                throw new FaultException<ArgumentFault>(fault);
            }

            ProgramStep stepEntity = Mapper.Map<ProgramStep>(step);

            _robotProgramBusinessLogic.UpdateStep(stepEntity);
        }

        public void DeleteStep(Guid id)
        {
            _robotProgramBusinessLogic.DeleteStep(id);
        }

        public void AddCartesianPoint(CartesianPointDto point)
        {
            // TODO: null-possibility should rather be checked in Buisness logic, and here just try-catch-toFaultConv
            if (point == null)
            {
                var fault = new ArgumentFault
                {
                    Message = "Argumnet is null",
                    ArgumentName = nameof(point)
                };

                throw new FaultException<ArgumentFault>(fault);
            }

            CartesianPoint pointEntity = Mapper.Map<CartesianPoint>(point);

            _robotProgramBusinessLogic.AddCartesianPoint(pointEntity);
        }

        public void UpdateCartesianPoint(CartesianPointDto point)
        {
            // TODO: null-possibility should rather be checked in Buisness logic, and here just try-catch-toFaultConv
            if (point == null)
            {
                var fault = new ArgumentFault
                {
                    Message = "Argumnet is null",
                    ArgumentName = nameof(point)
                };

                throw new FaultException<ArgumentFault>(fault);
            }

            CartesianPoint pointEntity = Mapper.Map<CartesianPoint>(point);

            _robotProgramBusinessLogic.UpdateCartesianPoint(pointEntity);
        }

        public void DeleteCartesianPoint(Guid id)
        {
            _robotProgramBusinessLogic.DeleteCartesianPoint(id);
        }

        public void AddJointPoint(JointPointDto point)
        {
            // TODO: null-possibility should rather be checked in Buisness logic, and here just try-catch-toFaultConv
            if (point == null)
            {
                var fault = new ArgumentFault
                {
                    Message = "Argumnet is null",
                    ArgumentName = nameof(point)
                };

                throw new FaultException<ArgumentFault>(fault);
            }

            JointPoint pointEntity = Mapper.Map<JointPoint>(point);

            _robotProgramBusinessLogic.AddJointPoint(pointEntity);
        }

        public void UpdateJointPoint(JointPointDto point)
        {
            // TODO: null-possibility should rather be checked in Buisness logic, and here just try-catch-toFaultConv
            if (point == null)
            {
                var fault = new ArgumentFault
                {
                    Message = "Argumnet is null",
                    ArgumentName = nameof(point)
                };

                throw new FaultException<ArgumentFault>(fault);
            }

            JointPoint pointEntity = Mapper.Map<JointPoint>(point);

            _robotProgramBusinessLogic.UpdateJointPoint(pointEntity);
        }

        public void DeleteJointPoint(Guid id)
        {
            _robotProgramBusinessLogic.DeleteJointPoint(id);
        }

        public StepDefinitionDto[] GetStepDefinitions()
        {
            StepDefinition[] stepDefinitions;

            try
            {
                stepDefinitions = _robotProgramBusinessLogic.GetStepDefinitions();
            }
            catch (Exception ex)
            {
                this.Log.Error(LogHelper.GetMethodInfoErrorMessage(MethodBase.GetCurrentMethod()), ex);

                throw new FaultException();
            }

            StepDefinitionDto[] stepDefinitionsDtos = Mapper.Map<StepDefinitionDto[]>(stepDefinitions);

            return stepDefinitionsDtos;
        }
    }
}