using Kabylia.Models.Area;
using Kabylia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DeliveryFoodApp.Controllers
{
    public class AreaController : Controller
    {
        private AreaService CreateAreaService()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AreaService();
            return service;
        }


        public async Task<ActionResult> Index()
        {
            var service = CreateAreaService();
            var model = await service.GetAreaAsync();
            return View(model);
        }



        public async Task<ActionResult> Details(int id)
        {

            var svc = CreateAreaService();
            var model = await svc.GetAreaByIdAsync(id);

            return View(model);
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
            var service = CreateAreaService();

            ViewBag.SyncOrAsync = "Asynchronous";
            ViewBag.AreaId = await GetAreaAsync();

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AreaCreate note)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.AreaId = await GetAreaAsync();
                return View(note);

            }

            var service = CreateAreaService();

            if (await service.CreateAreaAsync(note))
            {
                
                TempData["SaveResult"] = "Area was created.";
               
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Area could not be created.");
            ViewBag.AreaId = await GetAreaAsync();

            return View(note);
        }



        public async Task<ActionResult> Edit(int id)
        {
            var service = CreateAreaService();
            var detail = await service.GetAreaByIdAsync(id);
            var model =
                new AreaEdit
                {
                    AreaId = detail.AreaId,
                    AreaName = detail.AreaName,


                };



            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, AreaEdit note)
        {
            if (!ModelState.IsValid) return View(note);
            if (note.AreaId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");


                return View(note);
            }
            var service = CreateAreaService();
            if (await service.UpdateAreaAsync(note))
            {
                TempData["SaveResult"] = "Area was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Area could not be updated.");
            return View(note);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var service = CreateAreaService();
            var detail = await service.GetAreaByIdAsync(id);
            return View(detail);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteArea(int id)
        {
            var service = CreateAreaService();
            await service.DeleteAreaAsync(id);
            TempData["SaveResult"] = "Your note was successfully deleted.";

            return RedirectToAction("Index");
        }

    }
}