using MicroService.Sourcing.Data.Interface;
using MicroService.Sourcing.Entities;
using MicroService.Sourcing.Repositories.Interfaces;

using MongoDB.Driver;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.Sourcing.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly ISourcingContext _context;

        public BidRepository(ISourcingContext context)
        {
            this._context = context;
        }
        public async Task<List<Bid>> GetBidsByAuctionId(string id)
        {
            FilterDefinition<Bid> filter = Builders<Bid>.Filter.Eq(p => p.AuctionId, id);
            List<Bid> bids = await _context.Bids.Find(filter).ToListAsync();
            bids = bids.OrderByDescending(p => p.CreatedAt)
                       .GroupBy(p => p.SellerUserName)
                       .Select(p => new Bid
                       {
                           AuctionId = p.FirstOrDefault().AuctionId,
                           Price = p.FirstOrDefault().Price,
                           SellerUserName = p.FirstOrDefault().SellerUserName,
                           ProductId = p.FirstOrDefault().ProductId,
                           CreatedAt = p.FirstOrDefault().CreatedAt,
                           Id = p.FirstOrDefault().Id
                       }).ToList();
            return bids;
        }

        public async Task<List<Bid>> GetAllBidsByAuctionId(string id)
        {
            FilterDefinition<Bid> filter = Builders<Bid>.Filter.Eq(p => p.AuctionId, id);

            List<Bid> bids = await _context
                          .Bids
                          .Find(filter)
                          .ToListAsync();

            bids = bids.OrderByDescending(a => a.CreatedAt)
                                   .Select(a => new Bid
                                   {
                                       AuctionId = a.AuctionId,
                                       Price = a.Price,
                                       CreatedAt = a.CreatedAt,
                                       SellerUserName = a.SellerUserName,
                                       ProductId = a.ProductId,
                                       Id = a.Id
                                   })
                                   .ToList();

            return bids;
        }

        public async Task<Bid> GetWinnerBid(string id)
        {
            List<Bid> bids = await GetBidsByAuctionId(id);
            return bids.OrderByDescending(p => p.Price).FirstOrDefault();
        }

        public async Task SendBid(Bid bid)
        {
            await _context.Bids.InsertOneAsync(bid);
        }
    }
}
