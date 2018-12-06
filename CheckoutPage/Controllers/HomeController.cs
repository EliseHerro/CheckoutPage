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
            var product = new ProductModel() { Name = "coin", RetailPrice = "1" };
            return View(product);
        }


        public ActionResult StripePay()
        {

            var stripePublishKey = ConfigurationManager.AppSettings["PublishableKey"];
   
   
            ViewBag.StripePublishKey = "pk_test_PcbswzmLnVWD8jEzByVBWoCE";
            return View();
        }

        public ActionResult Charge(string stripeEmail, string stripeToken)
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

            

            return View();
        }


        public ActionResult Error()
        {
            return View();
        }
    }
}