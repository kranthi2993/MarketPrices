using MarketPrices.Application.Features.MarketItem.Commands.CreateMarketItemQuantity;
using MarketPrices.Application.Features.MarketItem.Queries.GetMarketItemOffers;
using MarketPrices.Application.Features.MarketItem.Queries.GetMarketItems;
using MediatR;
using MediatR.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace MarketPrices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketItemsController:ControllerBase
    {
        private readonly IMediator _mediator;

        public MarketItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetMarketItems")]
        public async Task<List<MarketItemListDto>> GetMarketItems()
        {
            var marketItems = await _mediator.Send(new GetMarketItemsListQuery());
            return marketItems;
        }

        [HttpGet]
        [Route("GetCheckoutItems")]
        public async Task<List<CheckoutMarketItemListDto>> GetCheckoutItems(string Guid)
        { 
            var marketItemsCheckoutList = await _mediator.Send(new GetMarketItemOffersListQuery { Guid = Guid });
            return marketItemsCheckoutList;
        }

        [HttpPost]
        [Route("PostMarketItems")]
        public async Task<ActionResult> Post(List<MarketItemListDto> lstMarketItemList)
        {
            var response = await _mediator.Send(new CreateMarketItemQuantityCommand { lstMarketitem = lstMarketItemList });
            return CreatedAtAction(nameof(GetCheckoutItems), new { id = response });
           // return Ok(1);
        }

    }
}
