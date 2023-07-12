using MarketPrices.Application.Contracts.Persistence;
using MarketPrices.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrices.Application.UnitTests.Mocks
{
    public class MockMarketItemQuantityRepository
    {
        public static Mock<IMarketItemQuantityRepository> GetMarketItemQuantityDetails()
        {
            var marketItemsWithQuantities = new List<MarketItem>
            {
                new MarketItem
                {
                    Id = 1,
                    ProductCode = "CH1",
                    Name = "Chai",
                    Price =3.110,
                    Quantity =1
                },
                 new MarketItem
                {
                    Id = 2,
                    ProductCode = "AP1",
                    Name = "Apples",
                    Price = 6.000,
                    Quantity =1
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
            var marketItemQuantityRepo = new Mock<IMarketItemQuantityRepository>();
            marketItemQuantityRepo.Setup(x => x.GetMarketItemQuantityDetails(It.IsAny<string>())).ReturnsAsync(marketItemsWithQuantities);
            return marketItemQuantityRepo;
        }
    }
}
