using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using RobotArm.Data.Entities.UserManagement;
using RobotArm.WebApp.Helpers;
using RobotArm.WebApp.ViewModels;

namespace RobotArm.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private IAuthenticationManager _authenticationManager;

        public AccountController(
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IAuthenticationManager AuthenticationManager
        {
            get => _authenticationManager ?? (_authenticationManager = HttpContext.GetOwinContext().Authentication);
            set => _authenticationManager = value;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl = null)
        {
            if (Request.QueryString["guid"] != null)
            {
                CurrentSessionFacade.Join = Request.QueryString["guid"];
            }

            LoginViewModel model = new LoginViewModel();
            model.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindAsync(model.Login, model.Password);
                if (user != null)
                {
                    await SignInAsync(user, model.RememberMe);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}