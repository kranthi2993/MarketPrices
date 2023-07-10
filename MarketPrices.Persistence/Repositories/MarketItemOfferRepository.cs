using MarketPrices.Application.Contracts.Persistence;
using MarketPrices.Domain;
using MarketPrices.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrices.Persistence.Repositories
{
    public class MarketItemOfferRepository:GenericRepository<MarketItemOffer>, IMarketItemOfferRepository
    {
        public MarketItemOfferRepository(MarketDBContext context) : base(context)
        {
            context.MarketItemOffers.FromSql($"sp_GetMarketOfferItems").ToList();
            context.Offers.ToList();
        }

        public async Task<List<MarketItemOffer>> GetMarketItemOfferWithDetails()
        {
            var marketItemOffers = await _context.MarketItemOffers
                .Include(q => q.Offer)
                .ToListAsync();
            
            return marketItemOffers;
        }
    }
}
