using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RobotArm.WebApp.Models.Interfaces;
using RobotArm.WebApp.ViewModels.RobotArmControl;

namespace RobotArm.WebApp.Controllers
{

    // TODO: Do something with CRUD operation to do not repeat code all the time (it's very schematic), (include all layers)
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
            if (!ModelState.IsValid)
            {
                return View(program);
            }

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
            if (!ModelState.IsValid)
            {
                return View(program);
            }

            _robotProgramModel.UpdateProgram(program);
            return RedirectToAction("Get");
        }

        [HttpPost]
        public void DeleteProgram(string programId)
        {
            _robotProgramModel.DeleteProgram(new Guid(programId));
        }

        public ActionResult CreateStep(string programId)
        {
            var step = new CreateEditProgramStepViewModel
            {
                ProgramStep = new ProgramStepViewModel
                {
                    ProgramId = programId
                },
                StepDefinitions = _robotProgramModel.GetStepDefinitions()
                    .Select(sd => new SelectListItem { Value = sd.Id, Text = sd.Name })
                    .ToList()
            };

            return View(step);
        }

        [HttpPost]
        public ActionResult CreateStep(CreateEditProgramStepViewModel step)
        {
            if (!ModelState.IsValid)
            {
                return View(step);
            }

            _robotProgramModel.AddStep(step.ProgramStep);
            return RedirectToAction("GetSteps", new { programId = step.ProgramStep.ProgramId });
        }

        public ActionResult EditStep(string stepId)
        {
            var programStep = _robotProgramModel.GetStep(new Guid(stepId));

            var step = new CreateEditProgramStepViewModel()
            {
                ProgramStep = programStep,
                StepDefinitions = _robotProgramModel.GetStepDefinitions()
                    .Select(sd => new SelectListItem { Value = sd.Id, Text = sd.Name, Selected = sd.Id == programStep.StepDefinitionId })
                    .ToList()
            };

            return View(step);
        }

        [HttpPost]
        public ActionResult EditStep(CreateEditProgramStepViewModel step)
        {
            if (!ModelState.IsValid)
            {
                return View(step);
            }

            _robotProgramModel.UpdateStep(step.ProgramStep);
            return RedirectToAction("GetSteps", new { programId = step.ProgramStep.ProgramId });
        }

        [HttpPost]
        public void DeleteStep(string stepId)
        {
            _robotProgramModel.DeleteStep(new Guid(stepId));
        }

        public ActionResult CreateCartesianPoint(string stepId)
        {
            var point = new CartesianPointViewModel
            {
                StepId = stepId
            };

            return View(point);
        }

        [HttpPost]
        public ActionResult CreateCartesianPoint(CartesianPointViewModel point)
        {
            if (!ModelState.IsValid)
            {
                return View(point);
            }

            _robotProgramModel.AddCartesianPoint(point);
            return RedirectToAction("GetPoints", new { stepId = point.StepId });
        }

        [HttpPost]
        public void DeleteCartesianPoint(string pointId)
        {
            _robotProgramModel.DeleteCartesianPoint(new Guid(pointId));
        }

        public ActionResult CreateJointPoint(string stepId)
        {
            var point = new JointPointViewModel
            {
                StepId = stepId
            };

            return View(point);
        }

        [HttpPost]
        public ActionResult CreateJointPoint(JointPointViewModel point)
        {
            if (!ModelState.IsValid)
            {
                return View(point);
            }

            _robotProgramModel.AddJointPoint(point);
            return RedirectToAction("GetPoints", new { stepId = point.StepId });
        }

        [HttpPost]
        public void DeleteJointPoint(string pointId)
        {
            _robotProgramModel.DeleteJointPoint(new Guid(pointId));
        }
    }
}