using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorShop.Models;

namespace BlazorShop.Interface
{
    public interface IProducts
    {
        Task<List<Products>> GetAllProducts();
        Task AddProduct(Products product);
        void DeleteProducts(string productsId);
        Task UpdateProducts(Products products);
    }
}