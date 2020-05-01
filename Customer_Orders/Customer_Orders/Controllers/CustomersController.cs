using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer_Orders.Models;
using Microsoft.AspNetCore.Mvc;

namespace Customer_Orders.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            var customer = new Customer
            {
                Email = "siparas@sheridancollege.ca",
                Name = "Paras"
            };

            var customers = new List<Customer> {customer, customer, customer};
            return View(customers);
        }

        public IActionResult CustomerForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Customer customer)
        {
            return Json(customer);
        }

    }
}