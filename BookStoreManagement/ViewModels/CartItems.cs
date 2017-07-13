using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreManagement.ViewModels
{
    public class CartItems
    {
        private int id;
        private int quantity;
        public CartItems(int _id, int _quantity)
        {
            id = _id;
            quantity = _quantity;
        }
        public int ISBN
        {
            get { return id; }
            set { id = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

    }
}