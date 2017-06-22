using ProjectManagement.AspNetMvc.PL.Infrastructure.Mappers;
using ProjectManagement.AspNetMvc.PL.Models.AccountViewModels;
using ProjectManagement.AspNetMvc.PL.Providers;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectManagement.AspNetMvc.PL.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public AccountController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
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
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            //if (service.IsUserExists(model.UserName))
            //{
            //    logger.Log(LogLevel.Trace, "Try to register exist user userName = {0}", model.UserName);
            //    ModelState.AddModelError("UserName", "User with this name already exists");
            //    return View(model);
            //}

            if (ModelState.IsValid)
            {
                var membershipProvider = new UserMembershipProvider(_userService);
                var membershipUser = membershipProvider.CreateUser(model.RegisterToBllUser());

                if (membershipUser != null)
                {
                    Roles.AddUserToRole(model.Login, "Default");
                    FormsAuthentication.SetAuthCookie(model.Login, false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Such user exist yet.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Model is not valid.");
            }
            
            return View(model);
        }


        //[HttpGet]
        //[Authorize]
        //public ActionResult Edit()
        //{
        //    logger.Log(LogLevel.Trace, "Request edit user page userName = {0}", User.Identity.Name);
        //    try
        //    {
        //        return View(service.GetByName(User.Identity.Name).ToEdirAccountViewModel());
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Log(LogLevel.Fatal, ex.ToString());
        //        ViewBag.StatusMessage = "User not found. Please try again later.";
        //        return View((object)null);
        //    }
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize]
        //public ActionResult Edit(EditAccountViewModel model, HttpPostedFileWrapper avatar)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        logger.Log(LogLevel.Trace, "Edit user page userName = {0}", User.Identity.Name);

        //        BllUser newUser = model.ToBllUser();
        //        BllUser oldUser = service.GetById(model.Id);
        //        if (oldUser == null) throw new HttpException(404, "Not found");

        //        newUser.UserName = oldUser.UserName;
        //        newUser.PasswordHash = oldUser.PasswordHash;
        //        service.Update(newUser);

        //        if (avatar != null) service.SetUserAvatar(model.Id, avatar.InputStream);

        //        ViewBag.StatusMessage = "User information successfully changed";
        //        return View(model);
        //    }
        //    return View(model);
        //}

        //[HttpGet]
        //[Authorize]
        //public ActionResult ChangePassword()
        //{
        //    logger.Log(LogLevel.Trace, "Request ChangePassword page userName = {0}", User.Identity.Name);
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize]
        //public ActionResult ChangePassword(ChangePasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Membership.Provider.ChangePassword(User.Identity.Name, model.OldPassword,
        //            model.NewPassword))
        //        {
        //            logger.Log(LogLevel.Trace, "Change password  userName = {0}", User.Identity.Name);
        //            ViewBag.StatusMessage = "Password successfully changed";
        //            return View(model);
        //        }
        //        logger.Log(LogLevel.Trace, "Change password fault userName = {0}", User.Identity.Name);
        //    }
        //    ModelState.AddModelError("", "Incorrect password");
        //    return View(model);
        //}
        

        #region Private Methods

        private ActionResult RedirectToLocal(string url)
        {
            if (Url.IsLocalUrl(url))
            {
                return Redirect(url);
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}
