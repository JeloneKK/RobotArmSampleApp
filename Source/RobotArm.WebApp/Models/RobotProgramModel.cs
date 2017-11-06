using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.Web;
using AutoMapper;
using RobotArm.ServicesClients.RobotArmControl.RobotProgram;
using RobotArm.ServicesContracts.RobotArmControl.DataContracts;
using RobotArm.ServicesContracts.SharedContracts.FaultContracts;
using RobotArm.WebApp.Models.Interfaces;
using RobotArm.WebApp.ViewModels.RobotArmControl;

namespace RobotArm.WebApp.Models
{
    public class RobotProgramModel : IRobotProgramModel
    {
        private readonly IRobotProgramService _robotProgramService;

        public RobotProgramModel(IRobotProgramService robotProgramService)
        {
            _robotProgramService = robotProgramService;
        }

        public List<RobotProgramViewModel> GetPrograms()
        {
            try
            {
                RobotProgramDto[] programs = _robotProgramService.GetPrograms();
                return Mapper.Map<List<RobotProgramViewModel>>(programs);
            }
            catch (FaultException ex)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public RobotProgramViewModel GetProgram(Guid id)
        {
            try
            {
                RobotProgramDto program = _robotProgramService.GetProgram(id);
                return Mapper.Map<RobotProgramViewModel>(program);
            }
            catch (FaultException<EntityNotFoundFault> ex)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, ex.Message, ex);
            }
            catch (FaultException ex)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, $"Error occured while getting program {id}", ex);
            }
        }

        public void AddProgram(RobotProgramViewModel program)
        {
            try
            {
                RobotProgramDto programDto = Mapper.Map<RobotProgramDto>(program);

                _robotProgramService.AddProgram(programDto);
            }
            catch (FaultException ex)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, "Error occured while adding program", ex);
            }
        }

        public void UpdateProgram(RobotProgramViewModel program)
        {
            try
            {
                RobotProgramDto programDto = Mapper.Map<RobotProgramDto>(program);

                _robotProgramService.UpdateProgram(programDto);
            }
            catch (FaultException ex)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, "Error occured while updating program", ex);
            }
        }

        public void DeleteProgram(Guid id)
        {
            try
            {
                _robotProgramService.DeleteProgram(id);
            }
            catch (FaultException ex)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, "Error occured while deleting program", ex);
            }
        }

        public ProgramStepViewModel GetStep(Guid id)
        {
            try
            {
                ProgramStepDto step = _robotProgramService.GetStep(id);
                return Mapper.Map<ProgramStepViewModel>(step);
            }
            catch (FaultException<EntityNotFoundFault> ex)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, ex.Message, ex);
            }
            catch (FaultException ex)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, $"Error occured while getting step {id}", ex);
            }
        }

        public void AddStep(ProgramStepViewModel step)
        {
            try
            {
                ProgramStepDto stepDto = Mapper.Map<ProgramStepDto>(step);

                _robotProgramService.AddStep(stepDto);
            }
            catch (FaultException ex)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, "Error occured while adding step", ex);
            }
        }

        public void UpdateStep(ProgramStepViewModel step)
        {
            try
            {
                ProgramStepDto stepDto = Mapper.Map<ProgramStepDto>(step);

                _robotProgramService.UpdateStep(stepDto);
            }
            catch (FaultException ex)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, "Error occured while updating step", ex);
            }
        }

        public void DeleteStep(Guid id)
        {
            try
            {
                _robotProgramService.DeleteStep(id);
            }
            catch (FaultException ex)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, "Error occured while deleting step", ex);
            }
        }
    }
}