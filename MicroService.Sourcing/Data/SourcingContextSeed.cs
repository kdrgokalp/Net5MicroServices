using MicroService.Sourcing.Entities;

using MongoDB.Driver;

using System;
using System.Collections.Generic;

namespace MicroService.Sourcing.Data
{
    public class SourcingContextSeed
    {
        public static void SeedData(IMongoCollection<Auction> auctionCollection)
        {
            bool exist = auctionCollection.Find(p => true).Any();
            if (!exist)
            {
                auctionCollection.InsertManyAsync(GetPreConfigureAuctions());
            }
        }

        private static IEnumerable<Auction> GetPreConfigureAuctions()
        {
            return new List<Auction>()
            {
                new Auction()
                {
                    Name = "Auction 1",
                    CreatedAt = DateTime.Now,
                    FinishedAt = DateTime.Now,
                    Quantity = 10,
                    Status = Status.Active,
                    StartedAt = DateTime.Now,
                    ProductId = "6317b70b5e2bbfd803799d09",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text " +
                    "ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    IncludedSellers = new List<string>()
                    {
                        "seller1@test.com",
                        "seller1@test.com",
                        "seller1@test.com"
                    }
                },
                new Auction()
                {
                    Name = "Auction 2",
                    CreatedAt = DateTime.Now,
                    FinishedAt = DateTime.Now,
                    Quantity = 10,
                    Status = Status.Active,
                    StartedAt = DateTime.Now,
                    ProductId = "6317b70b5e2bbfd803799d09",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text " +
                    "ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    IncludedSellers = new List<string>()
                    {
                        "seller1@test.com",
                        "seller1@test.com",
                        "seller1@test.com"
                    }
                },
                new Auction()
                {
                    Name = "Auction 3",
                    CreatedAt = DateTime.Now,
                    FinishedAt = DateTime.Now,
                    Quantity = 10,
                    Status = Status.Active,
                    StartedAt = DateTime.Now,
                    ProductId = "6317b70b5e2bbfd803799d09",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text " +
                    "ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    IncludedSellers = new List<string>()
                    {
                        "seller1@test.com",
                        "seller1@test.com",
                        "seller1@test.com"
                    }
                },
            };
        }
    }
}
