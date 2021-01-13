using Kabylia.Models.Menu;
using Kabylia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DeliveryFoodApp.Controllers
{
    public class MenuController : Controller
    {
        private MenuService CreateMenuService()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MenuService();
            return service;
        }


        public async Task<ActionResult> Index()
        {
            var service = CreateMenuService();
            var model = await service.GetMenuAsync();
            return View(model);
        }
        public async Task<ActionResult> BigMac()
        {
            var service = CreateMenuService();
            var model = await service.GetMenuAsync();
            return View(model);
        }
        public async Task<ActionResult> Nuggets()
        {
            var service = CreateMenuService();
            var model = await service.GetMenuAsync();
            return View(model);
        }
        public async Task<ActionResult> IcedCoffe()
        {
            var service = CreateMenuService();
            var model = await service.GetMenuAsync();
            return View(model);
        }
        public async Task<ActionResult> Fries()
        {
            var service = CreateMenuService();
            var model = await service.GetMenuAsync();
            return View(model);
        }
        public async Task<ActionResult> Mcgriddle()
        {
            var service = CreateMenuService();
            var model = await service.GetMenuAsync();
            return View(model);
        }
        public async Task<ActionResult> QuarterPounder()
        {
            var service = CreateMenuService();
            var model = await service.GetMenuAsync();
            return View(model);
        }
        public async Task<ActionResult> ChickenQuasadilla()
        {
            var service = CreateMenuService();
            var model = await service.GetMenuAsync();
            return View(model);
        }
        public async Task<ActionResult> Layer()
        {
            var service = CreateMenuService();
            var model = await service.GetMenuAsync();
            return View(model);
        }
        public async Task<ActionResult> ChickenBowl()
        {
            var service = CreateMenuService();
            var model = await service.GetMenuAsync();
            return View(model);
        }
        public async Task<ActionResult> CrunchyTaco()
        {
            var service = CreateMenuService();
            var model = await service.GetMenuAsync();
            return View(model);
        }
        public async Task<ActionResult> Quesarito()
        {
            var service = CreateMenuService();
            var model = await service.GetMenuAsync();
            return View(model);
        }
        public async Task<ActionResult> NachoFries()
        {
            var service = CreateMenuService();
            var model = await service.GetMenuAsync();
            return View(model);
        }
        public async Task<ActionResult> CaramelFrapuccino()
        {
            var service = CreateMenuService();
            var model = await service.GetMenuAsync();
            return View(model);
        }
        public async Task<ActionResult> MenuSelectable()
        {
            var service = CreateMenuService();
            var model = await service.GetSelectableMenuAsync();
            return View(model);
        }

        public async Task<ActionResult> Details(int id)
        {

            var svc = CreateMenuService();
            var model = await svc.GetMenuByIdAsync(id);

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
       
        public async Task<ActionResult> Create()
        {
            var service = CreateMenuService();

            ViewBag.SyncOrAsync = "Asynchronous";
            ViewBag.RestaurantId = await GetRestaurantAsync();

            return View();
        }
        public async Task<ActionResult> CreateMenuSelectable()
        {
            var service = CreateMenuService();

            ViewBag.SyncOrAsync = "Asynchronous";
            ViewBag.RestaurantId = await GetRestaurantAsync();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MenuCreate note)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.RestaurantId = await GetRestaurantAsync();

                return View(note);

            }

            var service = CreateMenuService();

            if (await service.CreateMenuAsync(note))
            {
                TempData["SaveResult"] = "Your Menu was created.";
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "Menu could not be created.");
            ViewBag.RestaurantId = await GetRestaurantAsync();


            return View(note);
        }



        public async Task<ActionResult> Edit(int id)
        {
            var service = CreateMenuService();
            var detail = await service.GetMenuByIdAsync(id);
            var model =
                new MenuEdit
                {
                    MenuId = detail.MenuId,
                    Name = detail.Name,
                    Description = detail.Description,
                    Price = detail.Price,
                  
                };

            ViewBag.RestaurantId = await GetRestaurantAsync();


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MenuEdit note)
        {
            if (!ModelState.IsValid) return View(note);
            if (note.MenuId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                ViewBag.RestaurantId = await GetRestaurantAsync();


                return View(note);
            }
            var service = CreateMenuService();
            if (await service.UpdateMenuAsync(note))
            {
                TempData["SaveResult"] = "Menu was successfully updated.";
                return RedirectToAction("Index");
            }
            ViewBag.RestaurantId = await GetRestaurantAsync();

            ModelState.AddModelError("", "Menu could not be updated.");
            return View(note);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var service = CreateMenuService();
            var detail = await service.GetMenuByIdAsync(id);
            return View(detail);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteMenu(int id)
        {
            var service = CreateMenuService();
            await service.DeleteMenuAsync(id);
            TempData["SaveResult"] = "Your note was successfully deleted.";

            return RedirectToAction("Index");
        }

    }
}