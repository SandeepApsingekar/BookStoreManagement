using BookStoreManagement.Functions;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BookStoreManagement.Controllers
{
    public class HomeController : Controller
    {
        private BookContext db = new BookContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        //Purchase Book
        public ActionResult Purchase(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            //TempData["ProductID"] = product.ProductID;
            //TempData["ProductName"] = product.ProductName;
            //TempData["ProductPrice"] = product.ProductPrice;
            return View(product);
        }


        [HttpPost]
        public ActionResult Cart(Product product)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();
                //product.ProductID = Convert.ToInt32(TempData["ProductID"]);
                //product.ProductName = (string)TempData["ProductName"];
                //product.ProductID = Convert.ToInt32(TempData["ProductID"]);
                int? id = product.ProductID;

                int quantities = product.Quantity;
                ShoppingCart cart = new ShoppingCart();
                Session["cart"] = cart;
                int value = Convert.ToInt32(id);
                int j = -1;
                if (cart != null)
                {
                    for (int i = 0; i < cart.Items.Count; i++)
                        if (cart.Items[i].ISBN == value)
                            j = i;
                }
                else
                {
                    cart = new ShoppingCart();
                }
                var books = db.Product.Find(id);
                int BooksQuantity = books.Quantity;
                if (j > -1)
                {
                    BooksQuantity += cart.Items[j].Quantity;
                }
                if (BooksQuantity < quantities)
                {
                    return Content("Sorry! We dont have so many items in stock!");
                }
                else
                {
                    //adds item to shopping cart
                    cart.AddItem(value, quantities);
                    return Content("Success");
                }
            }
            string result = "<b>Added the items to cart</b>";
            return View(result);

        }


        public ActionResult ViewCart(int? id)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            string total;
            int quan = 0;
            var product = new Product();

            if (cart == null)
            {
                return Content("Cart is null");
            }
            else
            {
                for (int i = 0; i < cart.Items.Count; i++)
                {
                    id = cart.Items[i].ISBN;
                    product= db.Product.Find(id);
                    quan = Convert.ToInt32(cart.Items[i].Quantity.ToString());
                    decimal amount = product.ProductPrice * quan;
                }
                total = cart.SumPrice(id).ToString();
            }
            ViewBag.ProductName = product.ProductName;
            ViewBag.Quantity = quan;
            ViewBag.Total = total;
            return View(product);
        }

        
    }
}