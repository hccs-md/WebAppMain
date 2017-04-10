using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMain.Controllers
{
    public class SchoolController : Controller
    {
        // GET: School
        public ActionResult Index()
        {
            return RedirectToRoute("About");
        }

        public ActionResult ClassesIntro()
        {
            return View();
        }

        public ActionResult Team()
        {
            return View();
        }

        public ActionResult Policies()
        {
            return View();
        }

        public ActionResult Activities()
        {
            return View();
        }

        public ActionResult Forms()
        {
            return View();
        }

        public ActionResult Clubs()
        {
            return View();
        }

        public ActionResult Events()
        {
            return View();
        }

        public ActionResult Pta()
        {
            return View();
        }
    }
}