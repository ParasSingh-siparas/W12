using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer_Orders.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Customer_Orders.Controllers
{
    public class CustomersController : Controller
    {
        private Database _dbContext;
        public CustomersController()
        {
            _dbContext = new Database();
        }
        public IActionResult Index()
        {
            return View(_dbContext.Customers.ToList());
        }

        public IActionResult CustomerForm()
        {
            return View();
        }

        public IActionResult CreateOrder(int id)
        {
            ViewBag.CustomerId = id;
            return View("OrderForm");
        }

        

        public IActionResult Delete(int id)
        {
            var customer = _dbContext.Customers.Find(id);
            if (customer == null)
                return NotFound();

            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var customer = _dbContext.Customers.Find(id);
            if (customer == null)
                return NotFound();

            return View("CustomerForm");
        }

        public IActionResult Orders(int id)
        {
            var customer = _dbContext.Customers.Include(c=>c.Orders).SingleOrDefault(c=>c.Id == id);
            if (customer == null)
                return NotFound();

            return View(customer.Orders);
        }

        [HttpPost]
        public IActionResult Save(Customer customer)
        {
            if(customer.Id == null)
            {
                _dbContext.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _dbContext.Customers.Find(customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Email = customer.Email;
            }

            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SaveOrder(Order order, int customerId)
        {
            var customer = _dbContext.Customers.Find(customerId);
            if (customer == null)
                return NotFound();

            order.Customer = customer;
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}