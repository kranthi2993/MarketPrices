using MarketPrices.Application.Features.MarketItem.Queries.GetMarketItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrices.Application.Features.MarketItem.Queries.GetMarketItemOffers
{
    public class CheckoutMarketItemListDto:MarketItemListDto
    {
        public string OfferName { get; set; } = string.Empty;
        public double DiscountPrice { get; set; } = 0;
    }
}
