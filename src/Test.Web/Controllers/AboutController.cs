﻿using System.Web.Mvc;

namespace Test.Web.Controllers
{
    public class AboutController : TestControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}