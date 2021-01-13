using Kabylia.Models.Restaurant;
using Kabylia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DeliveryFoodApp.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        private RestaurantService CreateRestaurantService()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RestaurantService();
            return service;
        }


        public async Task<ActionResult> Index()
        {
            var service = CreateRestaurantService();
            var model = await service.GetRestaurantsAsync();
            return View(model);
        }



        public async Task<ActionResult> Details(int id)
        {

            var svc = CreateRestaurantService();
            var model = await svc.GetRestaurantByIdAsync(id);

            return View(model);
        }
        public async Task<ActionResult> McDonalds(int id)
        {

            var svc = CreateRestaurantService();
            var model = await svc.GetRestaurantByIdAsync(id);

            return View(model);
        }
        public async Task<ActionResult> Buffalo(int id)
        {

            var svc = CreateRestaurantService();
            var model = await svc.GetRestaurantByIdAsync(id);

            return View(model);
        }
        public async Task<ActionResult> Taco(int id)
        {

            var svc = CreateRestaurantService();
            var model = await svc.GetRestaurantByIdAsync(id);

            return View(model);
        }
        public async Task<ActionResult> Starbucks(int id)
        {

            var svc = CreateRestaurantService();
            var model = await svc.GetRestaurantByIdAsync(id);

            return View(model);
        }
        public async Task<ActionResult> Dunkin(int id)
        {

            var svc = CreateRestaurantService();
            var model = await svc.GetRestaurantByIdAsync(id);

            return View(model);
        }
        public async Task<ActionResult> Texas(int id)
        {

            var svc = CreateRestaurantService();
            var model = await svc.GetRestaurantByIdAsync(id);

            return View(model);
        }
        public async Task<ActionResult> Chick(int id)
        {

            var svc = CreateRestaurantService();
            var model = await svc.GetRestaurantByIdAsync(id);

            return View(model);
        }
        public async Task<ActionResult> MenuDetails(int id)
        {

            var svc = CreateRestaurantService();
            var model = await svc.GetRestaurantByIdAsync(id);

            return View(model);
        }


        public async Task<IEnumerable<SelectListItem>> GetMenuAsync()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var catService = new MenuService();
            var categoryList = await catService.GetMenuAsync();

            var catSelectList = categoryList.Select(
                                        e =>
                                            new SelectListItem
                                            {
                                                Value = e.MenuId.ToString(),
                                                Text = e.Name
                                            }
                                        ).ToList();

            return catSelectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetAreaAsync()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var catService = new AreaService();
            var categoryList = await catService.GetAreaAsync();

            var catSelectList = categoryList.Select(
                                        e =>
                                            new SelectListItem
                                            {
                                                Value = e.AreaId.ToString(),
                                                Text = e.AreaName
                                            }
                                        ).ToList();

            return catSelectList;
        }
        public async Task<ActionResult> Create()
        {
            var service = CreateRestaurantService();

            ViewBag.SyncOrAsync = "Asynchronous";
            ViewBag.MenuId = await GetMenuAsync();
            ViewBag.AreaId = await GetAreaAsync();

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RestaurantCreate note)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.AreaId = await GetAreaAsync();

                ViewBag.MenuId = await GetMenuAsync();
                return View(note);

            }

            var service = CreateRestaurantService();

            if (await service.CreateRestaurantAsync(note))
            {
                TempData["SaveResult"] = "Restaurant created.";
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "Restaurant could not be created.");
            ViewBag.AreaId = await GetAreaAsync();
            ViewBag.MenuId = await GetMenuAsync();

            return View(note);
        }



        public async Task<ActionResult> Edit(int id)
        {
            var service = CreateRestaurantService();
            var detail = await service.GetRestaurantByIdAsync(id);
            var model =
                new RestaurantEdit
                {
                  RestaurantId=detail.RestaurantId,
                  Name=detail.Name,
                  Phone = detail.Phone,
                  Address = detail.Address,
                  Email = detail.Email,
                  OpeningTime=detail.OpeningTime,
                  ClosingTime=detail.ClosingTime,
                  AreaId=detail.AreaId,
                  //Review=detail.Review,
                  Latitude=detail.Latitude,
                  Longitude=detail.Longitude
                };
            ViewBag.SyncOrAsync = "Asynchronous";
            ViewBag.AreaId = await GetAreaAsync();

            ViewBag.MenutId = await GetMenuAsync();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, RestaurantEdit note)
        {
            if (!ModelState.IsValid) return View(note);
            if (note.RestaurantId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                ViewBag.MenuId = await GetMenuAsync();
                ViewBag.AreaId = await GetAreaAsync();

                return View(note);
            }
            var service = CreateRestaurantService();
            if (await service.UpdateRestaurantAsync(note))
            {
                TempData["SaveResult"] = "Restaurant informations successfully updated.";
                return RedirectToAction("Index");
            }
            ViewBag.MenuId = await GetMenuAsync();
            ViewBag.AreaId = await GetAreaAsync();

            ModelState.AddModelError("", "Restaurant informations could not be updated.");
            return View(note);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var service = CreateRestaurantService();
            var detail = await service.GetRestaurantByIdAsync(id);
            return View(detail);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteRestaurant(int id)
        {
            var service = CreateRestaurantService();
            await service.DeleteRestaurantAsync(id);
            TempData["SaveResult"] = "Restaurant was successfully deleted.";

            return RedirectToAction("Index");
        }

    }
}