using MongoDB.Bson.Serialization.Attributes;
using BlazorShop.DataAccessLayer;
using BlazorShop.Interface;
namespace BlazorShop.Models
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string FileName { get; set; }
    }
}