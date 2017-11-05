using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RobotArm.WebApp.Models.Interfaces;
using RobotArm.WebApp.ViewModels;
using RobotArm.WebApp.ViewModels.UserManagement;

namespace RobotArm.WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleModel _roleModel;

        public RoleController(IRoleModel roleModel)
        {
            _roleModel = roleModel;
        }

        public ActionResult Index()
        {
            List<RoleViewModel> roles = _roleModel.GetAllRoles();
            return View(roles);
        }

        public ActionResult Create()
        {
            RoleViewModel role = new RoleViewModel();
            return View(role);
        }

        [HttpPost]
        public ActionResult Create(RoleViewModel role)
        {
            _roleModel.AddRole(role);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public void Delete(string roleId)
        {
            _roleModel.DeleteRole(roleId);
        }
    }
}