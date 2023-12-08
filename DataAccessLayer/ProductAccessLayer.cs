
using Amazon.Runtime.Internal;
using BlazorShop.Interface;
using BlazorShop.Models;
using MongoDB.Driver;
using Syncfusion.Blazor.Kanban.Internal;
using BlazorShop.DataAccessLayer;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;



namespace BlazorShop.DataAccessLayer
{
    public class ProductAccessLayer : IProducts
    {
        private MongoClient mongoClient = null;
        private IMongoDatabase mongoDataBase = null;
        private IMongoCollection<Products> productsTable = null;

        public ProductAccessLayer()
        {
            mongoClient = new MongoClient();
            mongoDataBase = mongoClient.GetDatabase("StoreDB");
            productsTable = mongoDataBase.GetCollection<Products>("Products");
        }

        public async Task AddProduct(Products product)
        {
            try
            {
                await productsTable.InsertOneAsync(product);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async void DeleteProducts(string productsId)
        {
            try
            {
                await productsTable.DeleteOneAsync(x => x.Id == productsId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Products>> GetAllProducts()
        {
            try
            {
                var products = productsTable.Find(FilterDefinition<Products>.Empty).ToListAsync();
                return await products;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateProducts(Products products)
        {
            try
            {
                await productsTable.ReplaceOneAsync(x => x.Id == products.Id, products);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
