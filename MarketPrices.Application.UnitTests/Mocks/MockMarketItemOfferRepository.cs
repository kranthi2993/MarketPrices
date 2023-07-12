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
    public class MockMarketItemOfferRepository
    {
        public static Mock<IMarketItemOfferRepository> GetMarketItemOffers() {
            var marketOffers = new List<MarketItemOffer>()
            {
                new MarketItemOffer()
                {
                    Id = 1,
                    PurchasedMarketItemId = 3,
                    PurchasedQuantity = 1,
                    DiscountPrice = 11.230,
                    Limit  =0,
                    Offer = new Offer()
                    {
                        Id=1,
                        Name = "BOGO"
                    },
                    OfferedMarketItemId = 3,
                    OfferedPrice = 0,
                    OfferedQuantity = 2,
                    OfferId = 1,

                },
                 new MarketItemOffer()
                {
                    Id = 2,
                    PurchasedMarketItemId = 2,
                    PurchasedQuantity = 3,
                    DiscountPrice = 1,
                    Limit  =0,
                    Offer = new Offer()
                    {
                          Id = 2,
                          Name = "APPL",
                    },
                    OfferedMarketItemId = 2,
                    OfferedPrice = 4.5,
                    OfferedQuantity = 3,
                    OfferId = 2

                },
                 new MarketItemOffer()
                {
                    Id = 3,
                    PurchasedMarketItemId = 1,
                    PurchasedQuantity = 1,
                    DiscountPrice = 4.750,
                    Limit  = 1,
                    Offer = new Offer()
                    {
                        Id = 3,
                        Name = "CHMK",
                    },
                    OfferedMarketItemId = 4,
                    OfferedPrice = 0,
                    OfferedQuantity = 1,
                    OfferId = 3

                },
                  new MarketItemOffer()
                {
                    Id = 4,
                    PurchasedMarketItemId = 5,
                    PurchasedQuantity = 1,
                    DiscountPrice = 3,
                    Limit  = 0,
                    Offer = new Offer()
                    {
                         Id = 4,
                         Name = "APOM",
                    },
                    OfferedMarketItemId = 2,
                    OfferedPrice = 3,
                    OfferedQuantity = 1,
                    OfferId = 4

                }
            };

            var marketitemOfferRepo = new Mock<IMarketItemOfferRepository>();
            marketitemOfferRepo.Setup(x => x.GetMarketItemOfferWithDetails()).ReturnsAsync(marketOffers);
            return marketitemOfferRepo;
        }
    }
}
