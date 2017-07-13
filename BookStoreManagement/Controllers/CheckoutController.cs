using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreManagement.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOut(Product product)
        {
            return View();
        }
    }
}