using ProjectManagement.AspNetMvc.PL.Infrastructure.Mappers.AccountMappers;
using ProjectManagement.AspNetMvc.PL.Models.AccountViewModels;
using ProjectManagement.AspNetMvc.PL.Providers;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectManagement.AspNetMvc.PL.Controllers
{
    public class AccountController : Controller
    {
        private static readonly string DefaultRole = "default";

        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public AccountController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Login, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Login, model.RememberMe);
                    return RedirectToLocal(returnUrl);
                }

                ModelState.AddModelError(string.Empty, "Incorrect login or password");
            }

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var membershipProvider = new UserMembershipProvider();
                var membershipUser = membershipProvider.CreateUser(model.RegisterToBllUser());

                if (membershipUser != null)
                {
                    Roles.AddUserToRole(model.Login, DefaultRole);
                    FormsAuthentication.SetAuthCookie(model.Login, false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Such user exist yet.");
                }
            }

            return View(model);
        }

        #region Private Methods

        private ActionResult RedirectToLocal(string url)
        {
            if (Url.IsLocalUrl(url))
                return Redirect(url);

            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}
