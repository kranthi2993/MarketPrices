using MarketPrices.Application.Contracts.Persistence;
using MarketPrices.Domain;
using MarketPrices.Domain.Common;
using MarketPrices.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;


namespace MarketPrices.Persistence.Repositories
{
    public class MarketItemQuantityRepository : GenericRepository<MarketItemQuantity>, IMarketItemQuantityRepository
    {
        public MarketItemQuantityRepository(MarketDBContext context) : base(context)
        {
            context.MarketItems.ToList();
        }

        public async Task AddMarketItemQuantities(List<MarketItemQuantity> lstMarketItemQuantities)
        {
            await _context.AddRangeAsync(lstMarketItemQuantities);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MarketItem>> GetMarketItemQuantityDetails(string Guid)
        {
            List<MarketItem> marketItemDetails = await _context.MarketItems.ToListAsync();
            var marketItemQuantity = await GetAsync();

            var marketItemQuantityDetails = (from a in marketItemQuantity
                                             join b in marketItemDetails
                                      on a.PurchasedMarketItemId equals b.Id
                                             where a.Guid == Guid
                                             select new { left = a, right = b }).Select(Res =>
                                             {
                                                 Res.right.Quantity = Res.left.PurchasedQuantity;
                                                 return Res.right;
                                             }).ToList();

            return marketItemQuantityDetails;
        }


    }
}
