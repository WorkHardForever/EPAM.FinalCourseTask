﻿using System.Web.Mvc;

namespace ProjectManagement.AspNetMvc.PL.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}