using MarketPrices.Application.Contracts.Persistence;
using MarketPrices.Application.Features.MarketItem.Queries.GetMarketItems;
using MarketPrices.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrices.Application.Features.MarketItem.Commands.CreateMarketItemQuantity
{
    public class CreateMarketItemQuantityCommandHandler : IRequestHandler<CreateMarketItemQuantityCommand, string>
    {
        private readonly IMarketItemQuantityRepository _marketItemQuantityRepository;
        public CreateMarketItemQuantityCommandHandler(IMarketItemQuantityRepository marketItemQuantityRepository)
        {
            _marketItemQuantityRepository = marketItemQuantityRepository;
        }
        public async Task<string> Handle(CreateMarketItemQuantityCommand request, CancellationToken cancellationToken)
        {
            var objMarketitem = request.lstMarketitem;

            if (objMarketitem == null) { 
            throw new ArgumentNullException(nameof(objMarketitem));
            }
            var lstMarketItemQuantity = new List<MarketItemQuantity>();

            foreach (var item in objMarketitem)
            {

                lstMarketItemQuantity.AddRange(new List<MarketItemQuantity>(){
                    new MarketItemQuantity
                    {
                      PurchasedMarketItemId = item.Id,
                      PurchasedQuantity = item.Quantity
                    }});
            }
            string guid = Guid.NewGuid().ToString();
            lstMarketItemQuantity.Select(x => { x.Guid = guid; return x; }).ToList();
            await _marketItemQuantityRepository.AddMarketItemQuantities(lstMarketItemQuantity);

            //return Task.FromResult(guid);
            return guid;
        }
    }
}
