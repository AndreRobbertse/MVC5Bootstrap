using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MVC_Bootstrap.Controllers
{
    public class WidgetController : Controller
    {

        private RFAEntities db = new RFAEntities();

        //
        // GET: /Widget/
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult SearchClients(string term)
        {
            var result = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrEmpty(term))
            {
                Thread.Sleep(2000);

                var clients = db.Clients.Where(t => t.Surname.Contains(term)).Take(100).ToList();
                foreach (var c in clients)
                {
                    result.Add(new KeyValuePair<string, string>(c.ClientID.ToString(), string.Format("{0} {1}", c.Firstname, c.Surname)));
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}