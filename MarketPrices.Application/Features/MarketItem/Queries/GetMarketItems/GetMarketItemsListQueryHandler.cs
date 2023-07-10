using AutoMapper;
using MarketPrices.Application.Contracts.Logging;
using MarketPrices.Application.Contracts.Persistence;
using MarketPrices.Application.Exceptions;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrices.Application.Features.MarketItem.Queries.GetMarketItems
{
    public class GetMarketItemsListQueryHandler : IRequestHandler<GetMarketItemsListQuery, List<MarketItemListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMarketItemRepository _marketItemRepository;
        private readonly IAppLogger<GetMarketItemsListQueryHandler> _appLogger;
        public GetMarketItemsListQueryHandler(IMapper mapper, IMarketItemRepository marketItemRepository,
            IAppLogger<GetMarketItemsListQueryHandler> appLogger)
        {
            _mapper = mapper;
            _marketItemRepository = marketItemRepository;
            _appLogger = appLogger;
        }
        public async Task<List<MarketItemListDto>> Handle(GetMarketItemsListQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var marketItems = await _marketItemRepository.GetAsync();

            var marketItemsDTO = _mapper.Map<List<MarketItemListDto>>(marketItems);

            _appLogger.LogInformation("Market Items were retrieved successfully");

            return marketItemsDTO;
         
        }
    }
}
