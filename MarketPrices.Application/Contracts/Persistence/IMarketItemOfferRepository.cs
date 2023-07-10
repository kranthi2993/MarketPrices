using MarketPrices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrices.Application.Contracts.Persistence
{
    public interface IMarketItemOfferRepository:IGenericRepository<MarketItemOffer>
    {
        Task<List<MarketItemOffer>> GetMarketItemOfferWithDetails();
    }
}
