using CustomerSales.Manager;
using CustomerSales.Models;
using CustomerSales.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSales.Controllers
{
    public class ItemController : Controller
    {

        private readonly CustomerSalesDBContext db;
        CustomerSalesManager customerSalesManager = null;

        public ItemController(CustomerSalesDBContext context)
        {
            db = context;
            customerSalesManager = new CustomerSalesManager(db);
        }
        public IActionResult Index()
        {
            var itemList = customerSalesManager.GetItem();
            return View(itemList);
        }

        public IActionResult Add(int id = 0)
        {
            ItemViewModel model = new ItemViewModel();
            if (id != 0)
            {
                model = customerSalesManager.GetItemById(id);
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(ItemViewModel itemViewModel)
        {
            if (ModelState.IsValid)
            {
                if (itemViewModel.Id == 0)
                {
                    customerSalesManager.AddItem(itemViewModel);
                }
                else
                {
                    customerSalesManager.UpdateItem(itemViewModel);
                }
                return RedirectToAction("Index", "Item");
            }
            return View(itemViewModel);
        }

        public IActionResult Delete(int? id)
        {
            var isDeleted = customerSalesManager.DeleteItem(id ?? 0);
            if (!isDeleted)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
