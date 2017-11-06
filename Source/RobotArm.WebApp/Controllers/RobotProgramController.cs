using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RobotArm.WebApp.Models.Interfaces;

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
    }
}