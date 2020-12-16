using DeliveryFoodApp.Models;
using Kabylia.Data;
using Kabylia.Models.Customer;
using Kabylia.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DeliveryFoodApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
      
        
           // private readonly ApplicationDbContext _db = new ApplicationDbContext();
            private CustomerService CreateCustomerService()
            {
               // var userId = Guid.Parse(User.Identity.GetUserId());
                var service = new CustomerService();
                return service;
            }


            public async Task<ActionResult> Index()
            {
                var service = CreateCustomerService();
                var model = await service.GetCustomersAsync();
                return View(model);
            }



            public async Task<ActionResult> Details(int id)
            {

                var svc = CreateCustomerService();
                var model = await svc.GetCustomerByIdAsync(id);

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
                var service = CreateCustomerService();

                ViewBag.SyncOrAsync = "Asynchronous";
                ViewBag.CategoryID = await GetRestaurantsAsync();

                return View();
            }



            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Create(CustomerCreate note)
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.CategoryID = await GetRestaurantsAsync();
                    return View(note);

                }

                var service = CreateCustomerService();

                if (await service.CreateCustomerAsync(note))
                {
                    TempData["SaveResult"] = "Your note was created.";
                    return RedirectToAction("Index");

                }

                ModelState.AddModelError("", "Note could not be created.");
                ViewBag.CategoryID = await GetRestaurantsAsync();

                return View(note);
            }



            public async Task<ActionResult> Edit(int id)
            {
                var service = CreateCustomerService();
                var detail = await service.GetCustomerByIdAsync(id);
                var model =
                    new CustomerEdit
                    {
                        FirstName = detail.FirstName,
                        LastName = detail.LastName,
                        Username = detail.Username,
                        Phone = detail.Phone,
                        Address = detail.Address,
                        Email= detail.Email,
                        ContactPreference=detail.ContactPreference,
                        MembershipLevel=detail.MembershipLevel
                    };

                ViewBag.CategoryID = await GetRestaurantsAsync();

                return View(model);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Edit(int id, CustomerEdit note)
            {
                if (!ModelState.IsValid) return View(note);
                if (note.CustomerId != id)
                {
                    ModelState.AddModelError("", "ID Mismatch");
                    ViewBag.CategoryID = await GetRestaurantsAsync();

                    return View(note);
                }
                var service = CreateCustomerService();
                if (await service.UpdateCustomerAsync(note))
                {
                    TempData["SaveResult"] = "Your note was successfully updated.";
                    return RedirectToAction("Index");
                }
                ViewBag.CategoryID = await GetRestaurantsAsync();
                ModelState.AddModelError("", "Your note could not be updated.");
                return View(note);
            }

            public async Task<ActionResult> Delete(int id)
            {
                var service = CreateCustomerService();
                var detail = await service.GetCustomerByIdAsync(id);
                return View(detail);
            }


            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> DeleteCustomer(int id)
            {
                var service = CreateCustomerService();
                await service.DeleteCustomerAsync(id);
                TempData["SaveResult"] = "Your note was successfully deleted.";

                return RedirectToAction("Index");
            }
        

    }
}