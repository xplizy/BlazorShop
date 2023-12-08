using BlazorShop.Models;
using BlazorShop.DataAccessLayer;
using BlazorShop.Interface;

namespace BlazorShop.Models
{
    public class CartItem
    {
        public Products Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }

    public class CartService : ICartService
    {
        private List<CartItem> cartItems = new List<CartItem>();

        public List<CartItem> CartItems => cartItems;
        public double TotalPrice => cartItems.Sum(item => item.Price * item.Quantity);

        public void AddToCart(Products product, int quantity)
        {
            var existingItem = cartItems.FirstOrDefault(item => item.Product.Id == product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                var newCartItem = new CartItem { Product = product, Quantity = quantity, Price = product.Price };
                cartItems.Add(newCartItem);
            }
        }

        public void RemoveFromCart(Products product)
        {
            var itemToRemove = cartItems.FirstOrDefault(item => item.Product.Id == product.Id);

            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
            }
        }

        public void ClearCart()
        {
            cartItems.Clear();
        }


        public async Task CompletePurchase()
        {
            // Logic for completing the purchase, e.g., saving the cart items to a database
            // Note: This method can be made async if you need to perform asynchronous operations

            //await SomeDatabaseService.SaveCartItems(cartItems);
            ClearCart();
        }
    }
}