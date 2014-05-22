using MVC_Bootstrap.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Bootstrap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeModel model = new HomeModel();
            model.SelectedDate = DateTime.Now;
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostData(HomeModel thedata)
        {
            Debug.WriteLine("PostData");
            if (thedata != null)
            {
                Debug.WriteLine(thedata.SelectedDate.ToString());
                thedata.Message = "Helo " + thedata.SelectedDate.ToString();
            }
            return Json(thedata);
        }
    }
}
