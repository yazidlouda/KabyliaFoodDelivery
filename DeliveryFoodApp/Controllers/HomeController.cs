using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GoogleMap.Models;
using Kabylia.Models.Customer;
using Kabylia.Models.Menu;
using Kabylia.Models.Order;
using Kabylia.Services;

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
        private OrderService CreateOrderService()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new OrderService();
            return service;
        }


        public async Task<ActionResult> Index1()
        {
            var service = CreateOrderService();
            var model = await service.GetOrdersAsync();
            return View(model);
        }



        public async Task<ActionResult> Details(int id)
        {

            var svc = CreateOrderService();
            var model = await svc.GetOrderByIdAsync(id);

            return View(model);
        }
        public async Task<IEnumerable<SelectListItem>> GetCustomerAsync()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var catService = new CustomerService();
            var categoryList = await catService.GetCustomersAsync();

            var catSelectList = categoryList.Select(
                                        e =>
                                            new SelectListItem
                                            {
                                                Value = e.CustomerId.ToString(),
                                                Text = e.FirstName+" "+e.LastName
                                            }
                                        ).ToList();

            return catSelectList;
        }


        public async Task<IEnumerable<SelectListItem>> GetOrdersAsync()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var catService = new OrderService();
            var categoryList = await catService.GetOrdersAsync();

            var catSelectList = categoryList.Select(
                                        e =>
                                            new SelectListItem
                                            {
                                                Value = e.OrderId.ToString(),
                                                Text = e.CustomerName
                                            }
                                        ).ToList();

            return catSelectList;
        }
        public async Task<ActionResult> Create()
        {
            var service = CreateOrderService();

            ViewBag.SyncOrAsync = "Asynchronous";
            ViewBag.CategoryID = await GetOrdersAsync();
            ViewBag.CategoryID = await GetCustomerAsync();

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(OrderCreate note)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CategoryID = await GetOrdersAsync();
                return View(note);

            }

            var service = CreateOrderService();

            if (await service.CreateOrderAsync(note))
            {
                TempData["SaveResult"] = "Your Order was created.";
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "Note could not be created.");
            ViewBag.CategoryID = await GetOrdersAsync();

            return View(note);
        }



        public async Task<ActionResult> Edit(int id)
        {
            var service = CreateOrderService();
            var detail = await service.GetOrderByIdAsync(id);
            var model =
                new OrderEdit
                {
                    OrderId = detail.OrderId,
                    //Menu = detail.Menu,
                   // Price = detail.Price,
                    DeliveryCharge = detail.DeliveryCharge,
                    CustomerName = detail.CustomerName,
                    RestaurantName = detail.RestaurantName,

                };

            //ViewBag.CategoryID = await GetOrdersAsync();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, OrderEdit note)
        {
            if (!ModelState.IsValid) return View(note);
            if (note.OrderId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                //ViewBag.CategoryID = await GetOrdersAsync();

                return View(note);
            }
            var service = CreateOrderService();
            if (await service.UpdateOrderAsync(note))
            {
                TempData["SaveResult"] = "Order was successfully updated.";
                return RedirectToAction("Index");
            }
            //ViewBag.CategoryID = await GetOrdersAsync();
            ModelState.AddModelError("", "Order could not be updated.");
            return View(note);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var service = CreateOrderService();
            var detail = await service.GetOrderByIdAsync(id);
            return View(detail);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var service = CreateOrderService();
            await service.DeleteOrderAsync(id);
            TempData["SaveResult"] = "Your note was successfully deleted.";

            return RedirectToAction("Index");
        }

    }
}