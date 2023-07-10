using MarketPrices.Domain;
using MarketPrices.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrices.Persistence.DBContext
{
    public class MarketDBContext : DbContext
    {
        public MarketDBContext(DbContextOptions<MarketDBContext> options) : base(options)
        {
            
        }
        public DbSet<MarketItem> MarketItems { get; set; }
        public DbSet<MarketItemOffer> MarketItemOffers { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<MarketItemQuantity> MarketItemQuantity { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MarketItem>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18, 3)");
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<MarketItemOffer>(entity =>
            {
                entity.Property(e => e.OfferedPrice).HasColumnType("decimal(18, 3)");
                entity.Property(e => e.DiscountPrice).HasColumnType("decimal(18, 3)");
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MarketDBContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = base.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
