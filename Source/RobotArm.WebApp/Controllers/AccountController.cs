using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RobotArm.Data.Entities.Identity;
using RobotArm.WebApp.ViewModels;

namespace RobotArm.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser, string> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser, string> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> SignIn(string returnUrl = null)
        {
            //await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            //ViewData["ReturnUrl"] = returnUrl;
            //if (!String.IsNullOrEmpty(returnUrl) &&
            //    returnUrl.IndexOf("checkout", StringComparison.OrdinalIgnoreCase) >= 0)
            //{
            //    ViewData["ReturnUrl"] = "/Basket/Index";
            //}

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            //if (ModelState.IsValid)
            //{
            //    var user = await UserManager.FindAsync(model.Email, model.Password);
            //    if (user != null)
            //    {
            //        await SignInAsync(user, model.RememberMe);
            //        return RedirectToLocal(returnUrl);
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Invalid username or password.");
            //    }
            //}

            // If we got this far, something failed, redisplay form
            return View();
        }
    }
}