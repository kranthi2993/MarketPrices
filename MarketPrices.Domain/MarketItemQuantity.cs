using MarketPrices.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrices.Domain
{
    public class MarketItemQuantity:BaseEntity
    {
        public int PurchasedMarketItemId { get; set; }
        public int PurchasedQuantity { get; set; }
        public string Guid { get; set; } = string.Empty;
    }
}
