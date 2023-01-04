using MicroService.Sourcing.Entities;

using MongoDB.Driver;

namespace MicroService.Sourcing.Data.Interface
{
    public interface ISourcingContext
    {
        //Mongo db de açtığımız bir kapıdır. Burada collectionlara erişmek istiyoruz.
        IMongoCollection<Auction> Auctions { get; }
        IMongoCollection<Bid> Bids { get; }
    }
}
