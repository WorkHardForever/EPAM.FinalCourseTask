using ProjectManagement.AspNetMvc.PL.Infrastructure.Mappers.AdminMappers;
using ProjectManagement.AspNetMvc.PL.Models.AdminViewModels;
using ProjectManagement.AspNetMvc.PL.Providers;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjectManagement.AspNetMvc.PL.Controllers
{
    //[Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public AdminController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        #region User account

        [HttpGet]
        public ActionResult UserAccounts()
        {
            var allUsers = _userService.GetAll();
            var accountList = allUsers.ToUserAccountsViewModel();

            return View(accountList);
        }

        [HttpPost]
        public ActionResult DeleteUser(DeleteUserViewModel deleteUserViewModel, string id)
        {
            _userService.Delete(deleteUserViewModel.LoginName);

            ModelState.AddModelError("", $"User '{deleteUserViewModel.LoginName}' was deleted.");
            return View();
        }

        [HttpPost]
        public ActionResult AddUserToRole(AddUserToRoleViewModel addUserToRoleViewModel)
        {
            _roleService.AddUserByName(addUserToRoleViewModel.UserLogin, addUserToRoleViewModel.RoleName);

            ModelState.AddModelError("", $"User get '{addUserToRoleViewModel.RoleName}' permissions.");
            return View();
        }

        [HttpPost]
        public ActionResult RemoveUserFromRole(RemoveUserFromRoleViewModel removeRoleViewModel)
        {
            _roleService.RemoveUserByName(removeRoleViewModel.UserLogin, removeRoleViewModel.RoleName);

            ModelState.AddModelError("", $"User lose '{removeRoleViewModel.RoleName}' permissions.");
            return View();
        }

        #endregion

        #region Roles

        [HttpGet]
        public ActionResult Roles()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewRole(AddRoleViewModel newRoleViewModel)
        {
            _roleService.CreateByName(newRoleViewModel.Name);

            ModelState.AddModelError("", "New role was added.");
            return View();
        }

        [HttpGet]
        public ActionResult RemoveRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RemoveRole(AddRoleViewModel newRoleViewModel)
        {
            _roleService.DeleteByName(newRoleViewModel.Name);

            ModelState.AddModelError("", "New role was deleted.");
            return View();
        }

        #endregion
    }
}