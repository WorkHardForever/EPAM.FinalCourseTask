using System.Web.Mvc;

namespace ProjectManagement.AspNetMvc.PL.Controllers
{
    public class RecievedTasksController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}