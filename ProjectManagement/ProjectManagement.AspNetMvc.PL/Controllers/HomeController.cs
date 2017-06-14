using System.Web.Mvc;

namespace ProjectManagement.AspNetMvc.PL.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult OwnTasks()
        {
            //ViewBag.Message = "OwnTasks";

            return View();
        }

        [HttpGet]
        public ActionResult ManageTasks()
        {
            //ViewBag.Message = "ManageTasks";

            return View();
        }

        [HttpGet]
        public ActionResult WorkStatus()
        {
            //ViewBag.Message = "WorkStatus";

            return View();
        }
    }
}