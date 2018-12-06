using System;
using Stripe;
using System.Collections.Generic;
using System.Configuration;
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
            var product = new ProductModel() { Name = "coin", RetailPrice = 100 };
            return View(product);
        }


        public ActionResult StripePay()
        {
            ViewBag.StripePublishKey = ConfigurationManager.AppSettings["PublishableKey"];

            var product = new ProductModel() { Name = "coin", RetailPrice = 100 };
            return View(product);
        }

        public ActionResult Charge(string stripeEmail, string stripeToken, int RetailPrice)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 100,//cent
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });
            //save this info in a database customer
            //pass the customer 

            return View();
        }


        public ActionResult Error()
        {
            return View();
        }
    }
}