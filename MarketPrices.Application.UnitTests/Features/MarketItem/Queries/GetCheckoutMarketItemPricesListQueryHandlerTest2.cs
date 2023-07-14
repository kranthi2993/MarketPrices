using AutoMapper;
using MarketPrices.Application.Contracts.Persistence;
using MarketPrices.Application.Features.MarketItem.Queries.GetMarketItemOffers;
using MarketPrices.Application.MappingProfiles;
using MarketPrices.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrices.Application.UnitTests.Features.MarketItem.Queries
{
    public class GetCheckoutMarketItemPricesListQueryHandlerTest2
    {
        private readonly Mock<IMarketItemOfferRepository> _mockMarketItemOfferRepo;
        private readonly Mock<IMarketItemQuantityRepository> _mockMarketitemQuantityRepo;
        private IMapper _mapper;

        public GetCheckoutMarketItemPricesListQueryHandlerTest2()
        {
            _mockMarketItemOfferRepo = MockMarketItemOfferRepository.GetMarketItemOffers();
            _mockMarketitemQuantityRepo = MockMarketItemQuantityRepository.GetMarketItemQuantityDetailsTest2();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MarketItemProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        //CH1, AP1, AP1, AP1, MK1
        [Fact]
        public async Task GetCheckoutMarketItemPricesListTest()
        {
            var handler = new GetCheckoutMarketItemPricesListQueryHandler(_mockMarketItemOfferRepo.Object, _mockMarketitemQuantityRepo.Object, _mapper);

            var result = await handler.Handle(new GetCheckoutMarketItemPricesListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CheckoutMarketItemListDto>>();
            Math.Round(result.Sum(x => x.Price), 2).ShouldBe(16.61);
        }

    }
}
