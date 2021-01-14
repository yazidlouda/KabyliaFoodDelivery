using Kabylia.Models.Order;
using Kabylia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DeliveryFoodApp.Controllers
{
    public class OrderController : Controller
    {
        private OrderService CreateOrderService()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new OrderService();
            return service;
        }


        public async Task<ActionResult> Index()
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
        public async Task<IEnumerable<SelectListItem>> GetRestaurantAsync()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var catService = new RestaurantService();
            var categoryList = await catService.GetRestaurantsAsync();

            var catSelectList = categoryList.Select(
                                        e =>
                                            new SelectListItem
                                            {
                                                Value = e.RestaurantId.ToString(),
                                                Text = e.Name
                                            }
                                        ).ToList();

            return catSelectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetMenuAsync()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var catService = new MenuService();
            var categoryList = await catService.GetMenuAsync();
            ViewBag.SyncOrAsync = "Asynchronous";

            ViewBag.RestaurantId = await GetRestaurantAsync();

            var catSelectList = categoryList.Select(
                                        e =>
                                            new SelectListItem
                                            {
                                                Value = e.RestaurantId.ToString(),
                                                Text = e.Name
                                            }
                                        ).ToList();

            return catSelectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetDriverAsync()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var catService = new DeliveryDriverService();
            var categoryList = await catService.GetDeliveryDriversAsync();

            var catSelectList = categoryList.Select(
                                        e =>
                                            new SelectListItem
                                            {
                                                Value = e.DriverId.ToString(),
                                                Text = e.FirstName + " " + e.LastName
                                            }
                                        ).ToList();

            return catSelectList;
        }
        public async Task<ActionResult> Create()
        {
            var service = CreateOrderService();

            ViewBag.SyncOrAsync = "Asynchronous";
            ViewBag.CustomerId = await GetCustomerAsync();
            ViewBag.RestaurantId = await GetRestaurantAsync();
            ViewBag.DriverId = await GetDriverAsync();
            ViewBag.MenuId = await GetMenuAsync();

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(OrderCreate note)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CustomerId = await GetCustomerAsync();
                ViewBag.RestaurantId = await GetRestaurantAsync();
                ViewBag.DriverId = await GetDriverAsync();
                ViewBag.MenuId = await GetMenuAsync();

                return View(note);

            }

            var service = CreateOrderService();

            if (await service.CreateOrderAsync(note))
            {
                TempData["SaveResult"] = " Order was created.";
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "Order could not be created.");
            ViewBag.CustomerId = await GetCustomerAsync();
            ViewBag.RestaurantId = await GetRestaurantAsync();
            ViewBag.DriverId = await GetDriverAsync();
            ViewBag.MenuId = await GetMenuAsync();

            return View(note);
        }



        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.SyncOrAsync = "Asynchronous";
            ViewBag.CustomerId = await GetCustomerAsync();
            ViewBag.RestaurantId = await GetRestaurantAsync();
            ViewBag.DriverId = await GetDriverAsync();
            ViewBag.MenuId = await GetMenuAsync();

            var service = CreateOrderService();
            var detail = await service.GetOrderByIdAsync(id);
            var model =
                new OrderEdit
                {
                    OrderId=detail.OrderId,
                    //Menu = detail.Menu,
                    //Price = detail.Price,
                    DeliveryCharge = detail.DeliveryCharge,
                    CustomerName = detail.CustomerName,
                    RestaurantName = detail.RestaurantName,
                    RestaurantLatitude=detail.RestaurantLatitude,
                    RestaurantLongitude=detail.RestaurantLongitude,
                    CustomerLatitude = detail.CustomerLatitude,
                    CustomerLongitude = detail.CustomerLongitude,
                    DriverLatitude = detail.DriverLatitude,
                    DriverLongitude = detail.DriverLongitude
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
                ViewBag.CustomerId = await GetCustomerAsync();
                ViewBag.RestaurantId = await GetRestaurantAsync();
                ViewBag.DriverId = await GetDriverAsync();
                ViewBag.MenuId = await GetMenuAsync();

                return View(note);
            }
            var service = CreateOrderService();
            if (await service.UpdateOrderAsync(note))
            {
                TempData["SaveResult"] = "Order successfully updated.";
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = await GetCustomerAsync();
            ViewBag.RestaurantId = await GetRestaurantAsync();
            ViewBag.DriverId = await GetDriverAsync();
            ViewBag.MenuId = await GetMenuAsync();

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
            TempData["SaveResult"] = "Order was successfully deleted.";

            return RedirectToAction("Index");
        }


    }
}
