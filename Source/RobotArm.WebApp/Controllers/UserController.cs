using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using RobotArm.WebApp.Models.Interfaces;
using RobotArm.WebApp.ViewModels;
using RobotArm.WebApp.ViewModels.UserManagement;

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
            var editUserViewModel = new CreateEditUserViewModel();

            editUserViewModel.UserDetails = _userModel.GetDetails(userId);
            editUserViewModel.AllowedRoles = _userModel.GetAllRoles().ToList();

            return View(editUserViewModel);
        }

        [HttpPost]
        public ActionResult Edit(CreateEditUserViewModel user)
        {
            user.UserDetails.Roles = _userModel.GetRoles(user.SelectedRoles).ToList();
            _userModel.Update(user.UserDetails);
            return View("Details", user.UserDetails);
        }

        public ActionResult Create()
        {
            var createUserViewModel = new CreateEditUserViewModel
            {
                UserDetails = new UserDetailsViewModel
                {
                    User = new UserViewModel()
                },
                AllowedRoles = _userModel.GetAllRoles().ToList()
            };

            return View(createUserViewModel);
        }

        [HttpPost]
        public ActionResult Create(CreateEditUserViewModel user)
        {
            user.UserDetails.Roles = _userModel.GetRoles(user.SelectedRoles).ToList();
            _userModel.Create(user.UserDetails);
            return View("Details", user.UserDetails);
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