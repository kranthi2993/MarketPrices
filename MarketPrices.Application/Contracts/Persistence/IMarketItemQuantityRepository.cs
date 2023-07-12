using MarketPrices.Domain;
using MarketPrices.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrices.Application.Contracts.Persistence
{
    public interface IMarketItemQuantityRepository: IGenericRepository<MarketItemQuantity>
    {
        Task AddMarketItemQuantities(List<MarketItemQuantity> lstMarketItemQuantities);
        Task<List<MarketItem>> GetMarketItemQuantityDetails(string guid);
    }
}
