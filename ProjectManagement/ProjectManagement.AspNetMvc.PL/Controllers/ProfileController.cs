using System.Web.Mvc;

namespace ProjectManagement.AspNetMvc.PL.Controllers
{
    public class ProfileController : Controller
    {
        [HttpGet]
        public ActionResult Info()
        {
            return View();
        }

        [HttpPut]
        public ActionResult Edit()
        {
            // TODO edit
            return View();
        }
    }
}