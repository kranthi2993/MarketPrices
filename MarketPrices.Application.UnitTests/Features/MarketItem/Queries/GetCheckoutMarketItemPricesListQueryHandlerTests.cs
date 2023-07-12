using AutoMapper;
using MarketPrices.Application.Contracts.Logging;
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
    public class GetCheckoutMarketItemPricesListQueryHandlerTests
    {
        private readonly Mock<IMarketItemOfferRepository> _mockMarketItemOfferRepo;
        private readonly Mock<IMarketItemQuantityRepository> _mockMarketitemQuantityRepo;
        private IMapper _mapper;

        public GetCheckoutMarketItemPricesListQueryHandlerTests()
        {
            _mockMarketItemOfferRepo = MockMarketItemOfferRepository.GetMarketItemOffers();
            _mockMarketitemQuantityRepo = MockMarketItemQuantityRepository.GetMarketItemQuantityDetails();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MarketItemProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetCheckoutMarketItemPricesListTest()
        {
            var handler = new GetCheckoutMarketItemPricesListQueryHandler(_mockMarketItemOfferRepo.Object, _mockMarketitemQuantityRepo.Object, _mapper);

            var result = await handler.Handle(new GetCheckoutMarketItemPricesListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CheckoutMarketItemListDto>>();
            result.Count.ShouldBe(3);
        }
    }
}
