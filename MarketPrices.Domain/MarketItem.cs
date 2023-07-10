using MarketPrices.Domain.Common;

namespace MarketPrices.Domain
{
    public class MarketItem : BaseEntity
    {
        public string ProductCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Quantity { get; set; } = 0;

    }
}