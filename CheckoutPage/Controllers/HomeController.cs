using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckoutPage.Models;

namespace CheckoutPage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult ProductPage()
        {
            var product = new ProductModel() { Name = "coin", RetailPrice = "1" };
            return View(product);
        }

    }
}