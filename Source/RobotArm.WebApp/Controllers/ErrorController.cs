using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RobotArm.WebApp.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult PageNotFound()
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return View();
        }

        public ActionResult CustomError()
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return View();
        }
    }
}