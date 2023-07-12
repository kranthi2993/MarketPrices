using MarketPrices.Application.Contracts.Persistence;
using MarketPrices.Domain;
using Moq;

namespace MarketPrices.Application.UnitTests.Mocks
{
    public class MockMarketItemRepository
    {
        public static Mock<IMarketItemRepository> GetMockMarketItemRepository()
        {
            var marketItems = new List<MarketItem>
            {
                new MarketItem
                {
                    Id = 1,
                    ProductCode = "CH1",
                    Name = "Chai",
                    Price =3.110,
                    Quantity =0
                },
                 new MarketItem
                {
                    Id = 2,
                    ProductCode = "AP1",
                    Name = "Apples",
                    Price = 6.000,
                    Quantity =0
                },
                 new MarketItem
                {
                    Id = 3,
                    ProductCode = "CF1",
                    Name = "Coffee",
                    Price = 11.230,
                    Quantity =0
                },
                  new MarketItem
                {
                    Id = 4,
                    ProductCode = "MK1",
                    Name = "Milk",
                    Price = 4.750,
                    Quantity =0
                },
                   new MarketItem
                {
                    Id = 5,
                    ProductCode = "OM1",
                    Name = "Oatmeal",
                    Price = 3.690,
                    Quantity =0
                }

            };
            var mockRepo = new Mock<IMarketItemRepository>();

            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(marketItems);

            return mockRepo;
        }
    }
}
