using MarketPrices.Application.Contracts.Persistence;
using MarketPrices.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarketPrices.Application.UnitTests.Mocks
{
    public class MockMarketItemQuantityRepository
    {
        public static Mock<IMarketItemQuantityRepository> GetMarketItemQuantityDetailsTest1()
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
                    Quantity =1
                },
                  new MarketItem
                 {
                    Id = 4,
                    ProductCode = "MK1",
                    Name = "Milk",
                    Price = 4.750,
                    Quantity =1
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

        public static Mock<IMarketItemQuantityRepository> GetMarketItemQuantityDetailsTest2()
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
                    Quantity =3
                },
                  new MarketItem
                 {
                    Id = 4,
                    ProductCode = "MK1",
                    Name = "Milk",
                    Price = 4.750,
                    Quantity =1
                }

            };
            var marketItemQuantityRepo = new Mock<IMarketItemQuantityRepository>();
            marketItemQuantityRepo.Setup(x => x.GetMarketItemQuantityDetails(It.IsAny<string>())).ReturnsAsync(marketItemsWithQuantities);
            return marketItemQuantityRepo;
        }
        public static Mock<IMarketItemQuantityRepository> GetMarketItemQuantityDetailsTest3()
        {
            var marketItemsWithQuantities = new List<MarketItem>
            {
               
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
                    Id = 4,
                    ProductCode = "MK1",
                    Name = "Milk",
                    Price = 4.750,
                    Quantity =1
                }

            };
            var marketItemQuantityRepo = new Mock<IMarketItemQuantityRepository>();
            marketItemQuantityRepo.Setup(x => x.GetMarketItemQuantityDetails(It.IsAny<string>())).ReturnsAsync(marketItemsWithQuantities);
            return marketItemQuantityRepo;
        }
        public static Mock<IMarketItemQuantityRepository> GetMarketItemQuantityDetailsTest4()
        {
            var marketItemsWithQuantities = new List<MarketItem>
            {
                new MarketItem
                {
                    Id = 3,
                    ProductCode = "CF1",
                    Name = "Coffee",
                    Price = 11.230,
                    Quantity =1
                }

            };
            var marketItemQuantityRepo = new Mock<IMarketItemQuantityRepository>();
            marketItemQuantityRepo.Setup(x => x.GetMarketItemQuantityDetails(It.IsAny<string>())).ReturnsAsync(marketItemsWithQuantities);
            return marketItemQuantityRepo;
        }

        public static Mock<IMarketItemQuantityRepository> GetMarketItemQuantityDetailsTest5()
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
                    Quantity =3
                }

            };
            var marketItemQuantityRepo = new Mock<IMarketItemQuantityRepository>();
            marketItemQuantityRepo.Setup(x => x.GetMarketItemQuantityDetails(It.IsAny<string>())).ReturnsAsync(marketItemsWithQuantities);
            return marketItemQuantityRepo;
        }

    }
}
