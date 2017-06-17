using System.Web.Mvc;

namespace ProjectManagement.AspNetMvc.PL.Controllers
{
    public class GivenTasksController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}