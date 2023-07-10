using MarketPrices.Application.Features.MarketItem.Queries.GetMarketItems;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrices.Application.Features.MarketItem.Commands.CreateMarketItemQuantity
{
    public class CreateMarketItemQuantityCommand : IRequest<string>
    {
      public List<MarketItemListDto>? lstMarketitem { get; set; }
    }
}
