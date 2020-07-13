using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace bai01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.x = 120;
            ViewBag.y = 123;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Something() {
            ViewBag.Name = "Hoang";
            Hashtable aHastable = new Hashtable();
            aHastable.Add("Name", "Hoang");
            aHastable.Add("Age", 18);
            ViewBag.Person = aHastable;
            this.ViewData["Ten"] = "Hoananannana";
            return View();
        }
    }
}