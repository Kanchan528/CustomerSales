using CustomerSales.Manager;
using CustomerSales.Models;
using CustomerSales.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSales.Controllers
{
    public class SalesController : Controller
    {
        private readonly CustomerSalesDBContext db;
        CustomerSalesManager customerSalesManager = null;

        public SalesController(CustomerSalesDBContext context)
        {
            db = context;
            customerSalesManager = new CustomerSalesManager(db);
        }
        public IActionResult Index()
        {
            List<SalesViewModel> vm = customerSalesManager.GetSales();
            return View(vm);
        }
        private void ViewBagForItems()
        {
            var items = customerSalesManager.GetItem();
            ViewBag.Items = new SelectList(items, "Id", "ItemName");
        }

        private void ViewBagForCustomer()
        {
            var customer = customerSalesManager.GetCustomers();
            ViewBag.Customer = new SelectList(customer, "Id", "CustomerName");
        }
        public IActionResult Add(int masterId = 0)
        {
            ViewBagForItems();
            ViewBagForCustomer();
            SalesViewModel vm = customerSalesManager.GetSalesById(masterId);
            if (vm == null)
            {
                vm = new SalesViewModel()
                {
                    Master = new SalesMasterViewModel(),
                    Details = new List<SalesDetailViewModel>(),
                };
            };
            return View(vm);
        }
        [HttpPost]
        public JsonResult SalesPost(SalesViewModel vm)
        {
            ViewBagForCustomer();
            ViewBagForItems();
            customerSalesManager.AddSalesAndDetails(vm);
            return Json(true);
        }
        public IActionResult Delete(int masterId = 0)
        {
            return View();
        }
        public JsonResult GetItem(int id)
        {
            var item = customerSalesManager.GetItemById(id);
            return Json(new
            {
                Price = item.ItemRate,
                Quantity = item.ItemQuantity
            });
        }

        public JsonResult GetCustomer(int id)
        {
            var customer = customerSalesManager.GetCustomerById(id);
            return Json(new
            {
                Name = customer.CustomerName

            });
        }
    }
}
