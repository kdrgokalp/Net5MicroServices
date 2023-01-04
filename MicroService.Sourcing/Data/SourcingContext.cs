using MicroService.Sourcing.Data.Interface;
using MicroService.Sourcing.Entities;
using MicroService.Sourcing.Settings;

using MongoDB.Driver;

namespace MicroService.Sourcing.Data
{
    public class SourcingContext : ISourcingContext
    {
        //Sourcingcontext içerisinde encapculed edip farklı katmanlarda connection ile uğraşmadan erişebiliceğiz.
        public SourcingContext(ISourcingDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            //Collectionlara erişmemiz gerekiyor.
            Auctions = database.GetCollection<Auction>(nameof(Auction));
            Bids = database.GetCollection<Bid>(nameof(Bid));

            SourcingContextSeed.SeedData(Auctions);
        }
        public IMongoCollection<Auction> Auctions { get; }

        public IMongoCollection<Bid> Bids { get; }
    }
}
