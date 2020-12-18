using Kabylia.Models.DeliveryDriver;
using Kabylia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DeliveryFoodApp.Controllers
{
    public class DeliveryDriverController : Controller
    {
        private DeliveryDriverService CreateDeliveryDriverService()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DeliveryDriverService();
            return service;
        }


        public async Task<ActionResult> Index()
        {
            var service = CreateDeliveryDriverService();
            var model = await service.GetDeliveryDriversAsync();
            return View(model);
        }



        public async Task<ActionResult> Details(int id)
        {

            var svc = CreateDeliveryDriverService();
            var model = await svc.GetDeliveryDriverByIdAsync(id);

            return View(model);
        }



        public async Task<IEnumerable<SelectListItem>> GetDeliveryDriversAsync()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var catService = new DeliveryDriverService();
            var categoryList = await catService.GetDeliveryDriversAsync();

            var catSelectList = categoryList.Select(
                                        e =>
                                            new SelectListItem
                                            {
                                                Value = e.DriverId.ToString(),
                                                Text = e.FirstName
                                            }
                                        ).ToList();

            return catSelectList;
        }
        public async Task<ActionResult> Create()
        {
            var service = CreateDeliveryDriverService();

            ViewBag.SyncOrAsync = "Asynchronous";
            ViewBag.RestaurantId = await GetDeliveryDriversAsync();

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DeliveryDriverCreate note)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.RestaurantId = await GetDeliveryDriversAsync();
                return View(note);

            }

            var service = CreateDeliveryDriverService();

            if (await service.CreateDeliveryDriverAsync(note))
            {
                TempData["SaveResult"] = " DeliveryDriver was created.";
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "DeliveryDriver could not be created.");
            ViewBag.RestaurantId = await GetDeliveryDriversAsync();

            return View(note);
        }



        public async Task<ActionResult> Edit(int id)
        {
            var service = CreateDeliveryDriverService();
            var detail = await service.GetDeliveryDriverByIdAsync(id);
            var model =
                new DeliveryDriverEdit
                {
                    DriverId=detail.DriverId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Username = detail.Username,
                    Email = detail.Email,
                    PhoneNumber = detail.PhoneNumber,
                    IsActive = detail.IsActive,
                   
                };

            //ViewBag.RestaurantId = await GetDeliveryDriversAsync();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, DeliveryDriverEdit note)
        {
            if (!ModelState.IsValid) return View(note);
            if (note.DriverId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
               // ViewBag.CategoryID = await GetDeliveryDriversAsync();

                return View(note);
            }
            var service = CreateDeliveryDriverService();
            if (await service.UpdateDeliveryDriverAsync(note))
            {
                TempData["SaveResult"] = "DeliveryDriver informations successfully updated.";
                return RedirectToAction("Index");
            }
            //ViewBag.CategoryID = await GetDeliveryDriversAsync();
            ModelState.AddModelError("", "DeliveryDriver could not be updated.");
            return View(note);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var service = CreateDeliveryDriverService();
            var detail = await service.GetDeliveryDriverByIdAsync(id);
            return View(detail);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteDeliveryDriver(int id)
        {
            var service = CreateDeliveryDriverService();
            await service.DeleteDeliveryDriverAsync(id);
            TempData["SaveResult"] = "DeliveryDriver was successfully deleted.";

            return RedirectToAction("Index");
        }

    }
}