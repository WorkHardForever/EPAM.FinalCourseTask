using ProjectManagement.AspNetMvc.PL.Infrastructure.Mappers.ProfileMappers;
using ProjectManagement.AspNetMvc.PL.Models.ProfileViewModels;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectManagement.AspNetMvc.PL.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly IProfileService _profileService;

        public ProfileController(IUserService userService, IProfileService profileService)
        {
            _userService = userService;
            _profileService = profileService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Info(int id)
        {
            var profile = _profileService.GetById(id);

            if (profile != null)
                return View(profile.ToInfoViewModel());
            else
                return RedirectToAction("PageNotFound");
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(EditProfileViewModel model, HttpPostedFileWrapper avatar)
        {
            if (ModelState.IsValid)
            {
                //var newUser = model.ToBllUser();
                //var oldUser = service.GetById(model.Id);

                ////if (oldUser == null)
                ////    throw new HttpException(404, "Not found");

                //newUser.UserName = oldUser.UserName;
                //newUser.PasswordHash = oldUser.PasswordHash;
                //_userService.Update(newUser);

                //if (avatar != null)
                //    service.SetUserAvatar(model.Id, avatar.InputStream);

                ////ViewBag.StatusMessage = "User information successfully changed";

                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (Membership.Provider.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    //ViewBag.StatusMessage = "Password successfully changed";
                    return View(model);
                }
                else
                {
                    ModelState.AddModelError("", "Password was wrong.");
                }
            }

            return View(model);
        }
    }
}