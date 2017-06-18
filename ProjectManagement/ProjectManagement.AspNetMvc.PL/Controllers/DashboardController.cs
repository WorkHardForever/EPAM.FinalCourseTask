using System.Web.Mvc;

namespace ProjectManagement.AspNetMvc.PL.Controllers
{
    [Authorize(Roles = "Default")]
    public class DashboardController : Controller
    {
        [HttpGet]
        public ActionResult GivenTasks()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ReceivedTasks()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Statistics()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult LeftColumnDashboardPartial()
        {
            return PartialView();
        }
    }
}