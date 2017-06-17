using System.Web.Mvc;

namespace ProjectManagement.AspNetMvc.PL.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = "Main";

            return View();
        }

        //[HttpGet]
        //[Authorize(Roles = "Default")]
        //public ActionResult Dashboard()
        //{
        //    ViewBag.Message = "Dashboard";

        //    return View();
        //}
    }
}