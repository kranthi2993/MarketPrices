using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrices.Application.Features.MarketItem.Queries.GetMarketItems
{
    public class GetMarketItemsListQuery:IRequest<List<MarketItemListDto>>
    {
    }
}
