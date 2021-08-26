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
    public class CustomerController : Controller
    {
        private readonly CustomerSalesDBContext db;
        CustomerSalesManager customerSalesManager = null;

        public CustomerController(CustomerSalesDBContext context)
        {
            db = context;
            customerSalesManager = new CustomerSalesManager(db);
        }
        public IActionResult Index()
        {
            var customerList = customerSalesManager.GetCustomers();
            return View(customerList);
        }

        public IActionResult Add(int id = 0)
        {
            CustomerViewModel model = new CustomerViewModel();
            if (id != 0)
            {
                model = customerSalesManager.GetCustomerById(id);
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                if (customerViewModel.Id == 0)
                {
                    customerSalesManager.AddCustomer(customerViewModel);
                }
                else
                {
                    customerSalesManager.UpdateCustomer(customerViewModel);
                }
                return RedirectToAction("Index", "Customer");
            }
            return View(customerViewModel);
        }

        public IActionResult Delete(int? id)
        {
            var isDeleted = customerSalesManager.DeleteCustomer(id ?? 0);
            if (!isDeleted)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
