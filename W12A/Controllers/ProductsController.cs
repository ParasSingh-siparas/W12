using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using W12A.Models;

namespace W12A.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Hello()
        {
            return Content("Hello sir");
        }

        public IActionResult GoToGoogle()
        {
            return Redirect("http://www.google.com");
        }

        public IActionResult RedirToAction()
        {
            return RedirectToAction("Index");
        }

        public IActionResult RedirToHome()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult GetProductsJson()
        {
            var product = new Product
            {
                Id = 12223,
                Price = 30,
                Title = "TP"
            };
            return Json(product);
        }

        public IActionResult GetProductsJsonArr()
        {
            var product = new Product
            {
                Id = 12223,
                Price = 30,
                Title = "TP"
            };
            var products = new List<Product>
            {
                product,
                product,
                product
            };
            return Json(product);
        }

        public IActionResult Error()
        {
            return NotFound();
        }

        public IActionResult NewProduct()
        {
            return View();
        }

        public IActionResult SaveProduct(string productTitle)
        {
            return Content(Request.Form[productTitle]);
            //return Content(Request.Form["ProductTitle"]);
        }

    }
}