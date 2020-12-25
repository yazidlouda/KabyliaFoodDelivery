using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using GoogleMap.Models;

namespace DeliveryFoodApp.Controllers
{
    public class HomeController : Controller
    {
        TestDbEntities context = new TestDbEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.ListOfDropdown = context.google_map.ToList();
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //public JsonResult GetAllLocation()
        //{
        //    var data = context.google_map.ToList();
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult GetAllLocationById(int id)
        //{
        //    var data = context.google_map.Where(x => x.Id == id).SingleOrDefault();
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}
    }
}