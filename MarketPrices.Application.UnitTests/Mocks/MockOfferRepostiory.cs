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
    public class MockOfferRepostiory
    {
        public static Mock<IOfferRepository> GetMockOfferRepostiory()
        {
            var Offers = new List<Offer>()
            {
                new Offer
                {
                    Id = 1,
                    Name = "BOGO",
                },
                new Offer
                {
                    Id = 2,
                    Name = "APPL",
                },
                new Offer
                {
                    Id = 3,
                    Name = "CHMK",
                },
                new Offer
                {
                    Id = 4,
                    Name = "APOM",
                },

            };

            var offerRepo = new Mock<IOfferRepository>();
            offerRepo.Setup(x => x.GetAsync()).ReturnsAsync(Offers);
            return offerRepo;
        }
    }
}
