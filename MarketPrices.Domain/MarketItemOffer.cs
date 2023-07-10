using MarketPrices.Domain.Common;

namespace MarketPrices.Domain
{
    public class MarketItemOffer: BaseEntity
    {
        public int PurchasedMarketItemId { get; set; }
        public int PurchasedQuantity { get; set; }
        public int OfferedMarketItemId { get; set; }
        public double OfferedPrice { get; set; }
        public int OfferedQuantity { get; set; }
        public double DiscountPrice { get; set; }
        public int Limit { get; set; }
        public int OfferId { get; set; }
        public Offer? Offer { get; set; }

    }
}
