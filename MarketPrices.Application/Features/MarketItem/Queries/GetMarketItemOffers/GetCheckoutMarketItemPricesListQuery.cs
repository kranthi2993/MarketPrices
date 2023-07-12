using MarketPrices.Application.Features.MarketItem.Queries.GetMarketItems;
using MarketPrices.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrices.Application.Features.MarketItem.Queries.GetMarketItemOffers
{
    public class GetCheckoutMarketItemPricesListQuery : IRequest<List<CheckoutMarketItemListDto>>
    {
        public string guid { get; set; } = string.Empty;
    }
}
