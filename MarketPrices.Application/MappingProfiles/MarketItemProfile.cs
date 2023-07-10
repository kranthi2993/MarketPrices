using AutoMapper;
using MarketPrices.Application.Features.MarketItem.Queries.GetMarketItems;
using MarketPrices.Domain;

namespace MarketPrices.Application.MappingProfiles
{
    public class MarketItemProfile : Profile
    {
        public MarketItemProfile()
        {
            CreateMap<MarketItemListDto, MarketItem>().ReverseMap();
        }       
    }
}
