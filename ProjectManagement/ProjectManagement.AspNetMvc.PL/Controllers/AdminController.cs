using ProjectManagement.AspNetMvc.PL.Models.AdminViewModels;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using System.Web.Mvc;

namespace ProjectManagement.AspNetMvc.PL.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRoleService _roleService;

        public AdminController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

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
        public ActionResult NewRole(NewRoleViewModel newRoleViewModel)
        {
            _roleService.CreateByName(newRoleViewModel.Name);

            ModelState.AddModelError("", "New role was added successful");
            return View();
        }

        [HttpGet]
        public ActionResult RemoveRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RemoveRole(NewRoleViewModel newRoleViewModel)
        {
            _roleService.DeleteByName(newRoleViewModel.Name);
            return View();
        }
    }
}
