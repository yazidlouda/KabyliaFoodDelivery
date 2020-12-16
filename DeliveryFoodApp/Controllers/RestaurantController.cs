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



        public async Task<IEnumerable<SelectListItem>> GetRestaurantsAsync()
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
        public async Task<ActionResult> Create()
        {
            var service = CreateRestaurantService();

            ViewBag.SyncOrAsync = "Asynchronous";
            ViewBag.RestaurantId = await GetRestaurantsAsync();

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RestaurantCreate note)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.RestaurantId = await GetRestaurantsAsync();
                return View(note);

            }

            var service = CreateRestaurantService();

            if (await service.CreateRestaurantAsync(note))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "Note could not be created.");
            ViewBag.RestaurantId = await GetRestaurantsAsync();

            return View(note);
        }



        public async Task<ActionResult> Edit(int id)
        {
            var service = CreateRestaurantService();
            var detail = await service.GetRestaurantByIdAsync(id);
            var model =
                new RestaurantEdit
                {
                   Name=detail.Name,
                   Phone = detail.Phone,
                  Address = detail.Address,
                  Email = detail.Email,
                  OpeningTime=detail.OpeningTime,
                  ClosingTime=detail.ClosingTime,
                  Area=detail.Area,
                  Review=detail.Review
                };

            ViewBag.RestaurantId = await GetRestaurantsAsync();

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
                ViewBag.CategoryID = await GetRestaurantsAsync();

                return View(note);
            }
            var service = CreateRestaurantService();
            if (await service.UpdateRestaurantAsync(note))
            {
                TempData["SaveResult"] = "Restaurant was successfully updated.";
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = await GetRestaurantsAsync();
            ModelState.AddModelError("", "Restaurant could not be updated.");
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
            TempData["SaveResult"] = "Your note was successfully deleted.";

            return RedirectToAction("Index");
        }

    }
}