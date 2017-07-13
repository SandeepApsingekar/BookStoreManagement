using BookStoreManagement.ViewModels;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BookStoreManagement.Functions
{
    public class ShoppingCart
    {
        private List<CartItems> ItemsList = new List<CartItems>();
        private BookContext db = new BookContext();
        //This is used to add the items to the cart
        public void AddItem(int isbn, int quantity)
        {

            bool c = false;
            //To check whether that item is already there
            for (int i = 0; i < ItemsList.Count; i++)
            {
                if (ItemsList[i].ISBN == isbn)
                {
                    ItemsList[i].Quantity += quantity;
                    c = true;
                }
            }
                
            if (!c)
            {
                CartItems item = new CartItems(isbn, quantity);
                ItemsList.Add(item);
            }
        }

        //This is to add the price
        public double SumPrice(int? id)
        {
            var product = db.Product.Find(id);
            double price;
            double sum = 0;
            if (id == null)
            {
              new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (product == null)
            {
                new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            //Finds the items price
            for (int i = 0; i < ItemsList.Count; i++)
            {              
                id =  ItemsList[i].ISBN;
                price = Convert.ToDouble(product.ProductPrice);
                sum += price * ItemsList[i].Quantity;
            }
            return sum;

        }
        public List<CartItems> Items
        {
            get { return ItemsList; }
        }
    }
}