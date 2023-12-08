using BlazorShop.Models;

namespace BlazorShop.Interface
{
    public interface IProductApiClient
    {
        Task<List<Products>> GetProducts();
        Task AddProduct(Products product);
        Task UpdateProduct(Products product);
        Task DeleteProduct(string productId);
    }
}
