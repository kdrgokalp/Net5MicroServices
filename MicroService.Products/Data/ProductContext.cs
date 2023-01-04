using MicroService.Products.Data.Interfaces;
using MicroService.Products.Entities;
using MicroService.Products.Settings;

using MongoDB.Driver;

namespace MicroService.Products.Data
{
    public class ProductContext : IProductContext
    {
        public ProductContext(IProductDatabaseSettings productDatabaseSettings)
        {
            var client = new MongoClient(productDatabaseSettings.ConnectionString);
            var database = client.GetDatabase(productDatabaseSettings.DatabaseName);
            Products = database.GetCollection<Product>(productDatabaseSettings.CollectionName);

            ProductContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
