using Kabylia.Models.Rating;
using Kabylia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DeliveryFoodApp.Controllers
{
    public class RatingController : Controller
    {
        private RatingService CreateRatingService()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RatingService();
            return service;
        }


        public async Task<ActionResult> Index()
        {
            var service = CreateRatingService();
            var model = await service.GetRatingAsync();
            return View(model);
        }
      
        public async Task<ActionResult> Details(int id)
        {

            var svc = CreateRatingService();
            var model = await svc.GetRatingByIdAsync(id);

            return View(model);
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
        public async Task<IEnumerable<SelectListItem>> GetDeliveryDriverAsync()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var catService = new DeliveryDriverService();
            var categoryList = await catService.GetDeliveryDriversAsync();

            var catSelectList = categoryList.Select(
                                        e =>
                                            new SelectListItem
                                            {
                                                Value = e.DriverId.ToString(),
                                                Text = e.FirstName=e.LastName
                                            }
                                        ).ToList();

            return catSelectList;
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
                                                Text = e.FirstName+e.LastName
                                            }
                                        ).ToList();

            return catSelectList;
        }

        public async Task<IEnumerable<SelectListItem>> GetRatingAsync()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var catService = new RatingService();
            var categoryList = await catService.GetRatingAsync();

            var catSelectList = categoryList.Select(
                                        e =>
                                            new SelectListItem
                                            {
                                                Value = e.RatingId.ToString(),
                                               
                                            }
                                        ).ToList();

            return catSelectList;
        }

        public async Task<ActionResult> Create()
        {
            var service = CreateRatingService();

            ViewBag.SyncOrAsync = "Asynchronous";
            ViewBag.RestaurantId = await GetRestaurantAsync();
            ViewBag.CustomerId = await GetCustomerAsync();
            ViewBag.DriverId = await GetDeliveryDriverAsync();

            return View();
        }
      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RatingCreate note)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.RestaurantId = await GetRestaurantAsync();
                ViewBag.CustomerId = await GetCustomerAsync();
                ViewBag.DriverId = await GetDeliveryDriverAsync();

                return View(note);

            }

            var service = CreateRatingService();

            if (await service.CreateRatingAsync(note))
            {
                TempData["SaveResult"] = "Your Menu was created.";
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "Menu could not be created.");
            ViewBag.RestaurantId = await GetRestaurantAsync();
            ViewBag.CustomerId = await GetCustomerAsync();
            ViewBag.DriverId = await GetDeliveryDriverAsync();


            return View(note);
        }



        public async Task<ActionResult> Edit(int id)
        {
            var service = CreateRatingService();
            var detail = await service.GetRatingByIdAsync(id);
            var model =
                new RatingEdit
                {
                    RatingId = detail.RatingId,
                    RestaurantRating = detail.RestaurantRating,
                    DeliveryDriverRating = detail.DeliveryDriverRating,
                   

                };

            ViewBag.RestaurantId = await GetRestaurantAsync();
            ViewBag.CustomerId = await GetCustomerAsync();
            ViewBag.DriverId = await GetDeliveryDriverAsync();


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, RatingEdit note)
        {
            if (!ModelState.IsValid) return View(note);
            if (note.RatingId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                ViewBag.RestaurantId = await GetRestaurantAsync();
                ViewBag.CustomerId = await GetCustomerAsync();
                ViewBag.DriverId = await GetDeliveryDriverAsync();


                return View(note);
            }
            var service = CreateRatingService();
            if (await service.UpdateRatingAsync(note))
            {
                TempData["SaveResult"] = "Menu was successfully updated.";
                return RedirectToAction("Index");
            }
            ViewBag.RestaurantId = await GetRestaurantAsync();
            ViewBag.CustomerId = await GetCustomerAsync();
            ViewBag.DriverId = await GetDeliveryDriverAsync();

            ModelState.AddModelError("", "Menu could not be updated.");
            return View(note);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var service = CreateRatingService();
            var detail = await service.GetRatingByIdAsync(id);
            return View(detail);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteRating(int id)
        {
            var service = CreateRatingService();
            await service.DeleteRatingAsync(id);
            TempData["SaveResult"] = "Your note was successfully deleted.";

            return RedirectToAction("Index");
        }
    }
}