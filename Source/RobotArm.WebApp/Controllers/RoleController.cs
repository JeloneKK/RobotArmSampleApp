using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RobotArm.WebApp.Models.Interfaces;
using RobotArm.WebApp.ViewModels;

namespace RobotArm.WebApp.Controllers
{
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
            return this.Index();
        }

        [HttpPost]
        public ActionResult Delete(string roleId)
        {
            _roleModel.DeleteRole(roleId);
            return this.Index();
        }
    }
}