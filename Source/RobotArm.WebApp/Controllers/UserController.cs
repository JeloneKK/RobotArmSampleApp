using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using RobotArm.WebApp.Models.Interfaces;
using RobotArm.WebApp.ViewModels;

namespace RobotArm.WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserModel _userModel;

        public UserController(IUserModel userModel)
        {
            _userModel = userModel;
        }
       
        public ActionResult Index()
        {
            UserViewModel[] userViewModels = _userModel.Get();
            return View(userViewModels);
        }

        public ActionResult Details(string userId)
        {
            UserDetailsViewModel userDetails = _userModel.GetDetails(userId);
            return View(userDetails);
        }

        public ActionResult Edit(string userId)
        {
            UserDetailsViewModel userDetails = _userModel.GetDetails(userId);
            return View(userDetails);
        }

        [HttpPost]
        public ActionResult Edit(UserDetailsViewModel user)
        {
            _userModel.Update(user);
            return View("Details", user);
        }

        public ActionResult Create()
        {
            var userViewModel = new UserViewModel();
            return View(userViewModel);
        }

        [HttpPost]
        public ActionResult Create(UserViewModel user)
        {
            _userModel.Create(user);
            return View("Details", user);
        }

        [HttpPost]
        public void Delete(string userId)
        {
            _userModel.Delete(userId);
        }

        // TODO: Move to WebAPI ?
        public JsonResult GetAllRoles()
        {
            RoleViewModel[] roles = _userModel.GetAllRoles();
            return this.Json(roles, JsonRequestBehavior.AllowGet);
        }
    }
}