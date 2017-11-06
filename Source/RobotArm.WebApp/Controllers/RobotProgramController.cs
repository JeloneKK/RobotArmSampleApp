using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RobotArm.WebApp.Models.Interfaces;
using RobotArm.WebApp.ViewModels.RobotArmControl;

namespace RobotArm.WebApp.Controllers
{
    [Authorize(Roles = "Admin, Engineer")]
    public class RobotProgramController : Controller
    {
        private readonly IRobotProgramModel _robotProgramModel;

        public RobotProgramController(IRobotProgramModel robotProgramModel)
        {
            _robotProgramModel = robotProgramModel;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get()
        {
            var programs = _robotProgramModel.GetPrograms();
            return View(programs);
        }

        public ActionResult GetSteps(string programId)
        {
            var program = _robotProgramModel.GetProgram(new Guid(programId));
            return View(program);
        }

        public ActionResult GetPoints(string stepId)
        {
            var step = _robotProgramModel.GetStep(new Guid(stepId));
            return View(step);
        }

        public ActionResult CreateProgram()
        {
            var program = new RobotProgramViewModel();
            return View(program);
        }

        [HttpPost]
        public ActionResult CreateProgram(RobotProgramViewModel program)
        {
            _robotProgramModel.AddProgram(program);
            return RedirectToAction("Get");
        }

        public ActionResult EditProgram(string programId)
        {
            var program = _robotProgramModel.GetProgram(new Guid(programId));
            return View(program);
        }

        [HttpPost]
        public ActionResult EditProgram(RobotProgramViewModel program)
        {
            _robotProgramModel.UpdateProgram(program);
            return RedirectToAction("Get");
        }

        public ActionResult CreateStep()
        {
            var step = new ProgramStepViewModel();
            return View(step);
        }

        [HttpPost]
        public ActionResult CreateStep(ProgramStepViewModel step)
        {
            _robotProgramModel.AddStep(step);
            return RedirectToAction("GetSteps", new { programId = step.ProgramId });
        }

        public ActionResult EditStep(string stepId)
        {
            var step = _robotProgramModel.GetStep(new Guid(stepId));
            return View(step);
        }

        [HttpPost]
        public ActionResult EditStep(ProgramStepViewModel step)
        {
            _robotProgramModel.UpdateStep(step);
            return RedirectToAction("GetSteps", new { programId = step.ProgramId });
        }
    }
}