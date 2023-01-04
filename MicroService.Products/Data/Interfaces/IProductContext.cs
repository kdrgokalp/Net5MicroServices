using MicroService.Products.Entities;

using MongoDB.Driver;

namespace MicroService.Products.Data.Interfaces
{
    public interface IProductContext
    {
        //Mongo clinet bağlanmamız gerekiyor.
        IMongoCollection<Product> Products { get; }

    }
}
