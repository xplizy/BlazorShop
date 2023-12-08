using BlazorShop.Models;
using BlazorShop.DataAccessLayer;
using BlazorShop.Interface;
namespace BlazorShop.Interface;

public interface ICartService
{
    List<CartItem> CartItems { get; }
    double TotalPrice { get; }

    void AddToCart(Products product, int quantity);
    void RemoveFromCart(Products product);
    void ClearCart();
    Task CompletePurchase(); // add async if necessary
}