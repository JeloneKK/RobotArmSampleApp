using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
       
        public ActionResult Get()
        {
            UserViewModel[] userViewModels = _userModel.Get();
            return View(userViewModels);
        }

        public ActionResult Details(int userId)
        {
            UserViewModel userViewModel = _userModel.Get(userId);
            return View(userViewModel);
        }

        public ActionResult Edit(int userId)
        {
            UserViewModel userViewModel = _userModel.Get(userId);
            return View(userViewModel);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel user)
        {
            _userModel.Update(user);
            return View(user);
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
            return View(user);
        }

        [HttpPost]
        public void Delete(int userId)
        {
            _userModel.Delete(userId);
        }
    }
}