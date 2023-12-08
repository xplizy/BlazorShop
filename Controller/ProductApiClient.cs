using BlazorShop.Interface;
using BlazorShop.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorShop.Controller
{
    public class ProductApiClient : IProductApiClient
    {
        private readonly HttpClient httpClient;

        public ProductApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.httpClient.BaseAddress = new Uri("http://localhost:5000"); // Set the BaseAddress
        }

        public async Task<List<Products>> GetProducts()
        {
            return await httpClient.GetFromJsonAsync<List<Products>>("api/products");
        }

        public async Task AddProduct(Products product)
        {
            await httpClient.PostAsJsonAsync("api/products", product);
        }

        public async Task UpdateProduct(Products product)
        {
            await httpClient.PutAsJsonAsync($"api/products/{product.Id}", product);
        }

        public async Task DeleteProduct(string productId)
        {
            await httpClient.DeleteAsync($"api/products/{productId}");
        }
    }
}