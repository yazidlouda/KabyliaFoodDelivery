using Kabylia.Models.Transaction;
using Kabylia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DeliveryFoodApp.Controllers
{
    public class TransactionController : Controller
    {
        private TransactionService CreateTransactionService()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransactionService();
            return service;
        }


        public async Task<ActionResult> Index()
        {
            var service = CreateTransactionService();
            var model = await service.GetTransactionsAsync();
            return View(model);
        }



        public async Task<ActionResult> Details(int id)
        {

            var svc = CreateTransactionService();
            var model = await svc.GetTransactionByIdAsync(id);

            return View(model);
        }



        public async Task<IEnumerable<SelectListItem>> GetTransactionsAsync()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var catService = new TransactionService();
            var categoryList = await catService.GetTransactionsAsync();

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
            var service = CreateTransactionService();

            ViewBag.SyncOrAsync = "Asynchronous";
            ViewBag.CategoryID = await GetTransactionsAsync();

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TransactionCreate note)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CategoryID = await GetTransactionsAsync();
                return View(note);

            }

            var service = CreateTransactionService();

            if (await service.CreateTransactionAsync(note))
            {
                TempData["SaveResult"] = "Transaction was created.";
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "Transaction could not be created.");
            ViewBag.CategoryID = await GetTransactionsAsync();

            return View(note);
        }



        public async Task<ActionResult> Edit(int id)
        {
            var service = CreateTransactionService();
            var detail = await service.GetTransactionByIdAsync(id);
            var model =
                new TransactionEdit
                {
                    TransactionId= detail.TransactionId,
                    OrderId = detail.OrderId,
                    Amount = detail.Amount,
                    CustomerId = detail.CustomerId,
                    RestaurantId = detail.RestaurantId,
                    CustomerName = detail.CustomerName,
                    RestaurantName = detail.RestaurantName,

                };

            //ViewBag.CategoryID = await GetOrdersAsync();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, TransactionEdit note)
        {
            if (!ModelState.IsValid) return View(note);
            if (note.OrderId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                //ViewBag.CategoryID = await GetOrdersAsync();

                return View(note);
            }
            var service = CreateTransactionService();
            if (await service.UpdateTransactionAsync(note))
            {
                TempData["SaveResult"] = "Transaction was successfully updated.";
                return RedirectToAction("Index");
            }
            //ViewBag.CategoryID = await GetOrdersAsync();
            ModelState.AddModelError("", "Transaction could not be updated.");
            return View(note);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var service = CreateTransactionService();
            var detail = await service.GetTransactionByIdAsync(id);
            return View(detail);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteTransaction(int id)
        {
            var service = CreateTransactionService();
            await service.DeleteTransactionAsync(id);
            TempData["SaveResult"] = "Transaction was successfully deleted.";

            return RedirectToAction("Index");
        }
    }
}