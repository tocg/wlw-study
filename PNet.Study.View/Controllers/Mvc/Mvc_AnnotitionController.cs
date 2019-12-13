using PNet.Study.View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PNet.Study.View.Controllers.Mvc
{
    public class Mvc_AnnotitionController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DataAnnotation(UserRegistModel userModel)
        {
            if (ModelState.IsValid) { }
            return View("Index");
        }

        public ActionResult CoreCode()
        {
            return View();
        }
    }
}