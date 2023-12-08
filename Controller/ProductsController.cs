using BlazorShop.DataAccessLayer;
using BlazorShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Syncfusion.Blazor.PivotView;
using System.Security.Cryptography.X509Certificates;
using BlazorShop.DataAccessLayer;
using BlazorShop.Interface;

namespace BlazorShop.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        ProductAccessLayer objProducts = new ProductAccessLayer();
        [HttpGet]
        public async Task<object> Get()
        {
            var data = objProducts.GetAllProducts().Result.ToList();
            var queryString = Request.Query;
            if (queryString.Keys.Contains("$inlinecount"))
            {
                StringValues Skip;
                StringValues Take;
                int skip = (queryString.TryGetValue("$skip", out Skip)) ? Convert.ToInt32(Skip[0]) : 0;
                int top = (queryString.TryGetValue("$top", out Take)) ? Convert.ToInt32(Take[0]) : data.Count();
                var count = data.Count();
                return new { Items = data.Skip(skip).Take(top), Count = count };
            }
            else
            {
                return data;
            }

        }
        [HttpPost]
        public void Post([FromBody] Products products)
        {
            objProducts.AddProduct(products);
        }
        [HttpPost]
        public void Put([FromBody] Products products)
        {
            objProducts.UpdateProducts(products);
        }
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            objProducts.DeleteProducts(id);
        }
    }
}
