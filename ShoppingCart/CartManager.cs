using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    //Gereksinimler
    //Sepete ürün eklenebilmelidir
    //Sepetten ürün çıkarılabilmelidir


    public class CartManager
    {
        private readonly List<CartItem> _cartItems;

        public CartManager()
        {
            _cartItems = new List<CartItem>();
        }

        //bir testten geçemiyordur

        //public void Add(CartItem cartItem)
        //{
        //    _cartItems.Add(cartItem);
        //}

        public void Add(CartItem cartItem)
        {
            var addedCartItem = _cartItems.FirstOrDefault(i => i.Product.Id == cartItem.Product.Id);
            if (addedCartItem == null)
            {
                _cartItems.Add(cartItem);

            }
            else
            {
                addedCartItem.Quantity += cartItem.Quantity;
            }
        }

        public void Remove(int id)
        {
            var product = _cartItems.FirstOrDefault(i => i.Product.Id == id);
            _cartItems.Remove(product);
        }

        public List<CartItem> CartItems
        {
            get
            {
                return _cartItems;
            }
        }

        public void Clear()
        {
            _cartItems.Clear();
        }

        public decimal TotalPrice
        {
            get
            {
                return _cartItems.Sum(i => i.Quantity * i.Product.UnitPrice);
            }
        }

        public int TotalQuantity
        {
            get { return _cartItems.Sum(i => i.Quantity); }
        }

        public int TotalItems
        {
            get { return _cartItems.Count; }
        }
    }
}
