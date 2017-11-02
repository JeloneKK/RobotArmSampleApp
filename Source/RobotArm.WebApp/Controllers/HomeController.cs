using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RobotArm.ServicesContracts.UserManagement;
using RobotArm.ServicesContracts.UserManagement.ServiceContracts;

namespace RobotArm.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILoginService _loginService;
        private IUserService _userService;

        //public HomeController(ILoginService loginService, IUserService userService)
        //{
        //    var userIdentity = User.Identity;

        //    _loginService = loginService;
        //    _userService = userService;
        //}

        public HomeController()
        {
            
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}