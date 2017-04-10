using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMain.Controllers
{
    public class HomeController : BaseController
    {
        protected bool IsEnglish
        {
            get
            {
                var obj = this.RouteData.Values["lang"];
                return (obj != null && Convert.ToString(obj).StartsWith("en"));
            }
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult SchoolIntro()
        {
            return View();
        }

    }
}