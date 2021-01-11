using Kabylia.Models.Review;
using Kabylia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DeliveryFoodApp.Controllers
{
    public class ReviewController : Controller
    {
        private ReviewService CreateReviewService()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService();
            return service;
        }


        public async Task<ActionResult> Index()
        {
            var service = CreateReviewService();
            var model = await service.GetReviewAsync();
            return View(model);
        }
       
        public async Task<ActionResult> Details(int id)
        {

            var svc = CreateReviewService();
            var model = await svc.GetReviewByIdAsync(id);

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
        public async Task<IEnumerable<SelectListItem>> GetReviewAsync()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var catService = new ReviewService();
            var categoryList = await catService.GetReviewAsync();

            var catSelectList = categoryList.Select(
                                        e =>
                                            new SelectListItem
                                            {
                                                Value = e.ReviewId.ToString(),
                                                Text = e.Reviews
                                            }
                                        ).ToList();

            return catSelectList;
        }

        public async Task<ActionResult> Create()
        {
            var service = CreateReviewService();

            ViewBag.SyncOrAsync = "Asynchronous";
            ViewBag.RestaurantId = await GetRestaurantAsync();
            ViewBag.CustomerId = await GetCustomerAsync();

            return View();
        }
      


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ReviewCreate note)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.RestaurantId = await GetReviewAsync();
                ViewBag.CustomerId = await GetCustomerAsync();

                return View(note);

            }

            var service = CreateReviewService();

            if (await service.CreateReviewAsync(note))
            {
                TempData["SaveResult"] = "Review was created.";
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "Review could not be created.");
            ViewBag.RestaurantId = await GetRestaurantAsync();
            ViewBag.CustomerId = await GetCustomerAsync();


            return View(note);
        }



        public async Task<ActionResult> Edit(int id)
        {
            var service = CreateReviewService();
            var detail = await service.GetReviewByIdAsync(id);
            var model =
                new ReviewEdit
                {
                    ReviewId = detail.ReviewId,
                    Reviews = detail.Reviews,
                    CustomerName = detail.CustomerName,
                    RestaurantName = detail.RestaurantName,

                };

            ViewBag.RestaurantId = await GetRestaurantAsync();
            ViewBag.CustomerId = await GetCustomerAsync();


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ReviewEdit note)
        {
            if (!ModelState.IsValid) return View(note);
            if (note.ReviewId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                ViewBag.RestaurantId = await GetRestaurantAsync();
                ViewBag.CustomerId = await GetCustomerAsync();


                return View(note);
            }
            var service = CreateReviewService();
            if (await service.UpdateReviewAsync(note))
            {
                TempData["SaveResult"] = "Review was successfully updated.";
                return RedirectToAction("Index");
            }
            ViewBag.RestaurantId = await GetRestaurantAsync();
            ViewBag.CustomerId = await GetCustomerAsync();

            ModelState.AddModelError("", "Menu could not be updated.");
            return View(note);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var service = CreateReviewService();
            var detail = await service.GetReviewByIdAsync(id);
            return View(detail);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteReview(int id)
        {
            var service = CreateReviewService();
            await service.DeleteReviewAsync(id);
            TempData["SaveResult"] = "Your note was successfully deleted.";

            return RedirectToAction("Index");
        }
    }
}