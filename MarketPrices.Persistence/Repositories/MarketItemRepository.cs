using MarketPrices.Application.Contracts.Persistence;
using MarketPrices.Domain;
using MarketPrices.Persistence.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrices.Persistence.Repositories
{
    public class MarketItemRepository : GenericRepository<MarketItem>, IMarketItemRepository
    {
        public MarketItemRepository(MarketDBContext context) : base(context)
        {
        }

    }
}
