using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using DMUViews.Models;

namespace DMUViews.Controllers
{
    public class HomeController : Controller
    {
        private DMUViews.Models.ApplicationDbContext _entities = new DMUViews.Models.ApplicationDbContext();
        
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
        public ActionResult Movie()
        {

            return View(_entities.Movies.ToList());
        }

    }
}