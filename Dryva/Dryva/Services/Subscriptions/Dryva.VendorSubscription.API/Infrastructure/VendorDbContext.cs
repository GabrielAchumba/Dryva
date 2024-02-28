using Dryva.VendorSubscription.API.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Dryva.VendorSubscription.API.Infrastructure
{
    public class VendorDbContext : DbContext
    {

        public VendorDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Application.Models.VendorSubscription>(entity =>
            {
                entity.HasKey(x => x.SubscriptionId);
                entity.Property(x => x.SubscriptionId);
                entity.Property(x => x.VendorId).IsRequired();
                entity.Property(x => x.CreatedOn).IsRequired();
                entity.Property(x => x.ModifiedOn).IsRequired();
                entity.Property(x => x.RechargeCode).IsRequired();
                entity.Property(x => x.Amount).IsRequired().HasColumnType("decimal(8,4)");
                entity.Property(x => x.DepleteAmount).IsRequired().HasColumnType("decimal(8,4)");
                entity.Property(x => x.TransactionCode).IsRequired();
                entity.Property(x => x.IsActive).IsRequired();
            });

            // build customer recharge model
            modelBuilder.Entity<CustomerSubscription>(entity =>
            {
                entity.HasKey(x => x.SubscriptionId);
                entity.Property(x => x.SubscriptionId).IsRequired();
                entity.Property(x => x.VendorId).IsRequired();
                entity.Property(x => x.CreatedOn).IsRequired();
                entity.Property(x => x.Amount).IsRequired().HasColumnType("decimal(8,4)");
                entity.Property(x => x.CustomerId).IsRequired();
                entity.Property(x => x.CardSerialNumber).IsRequired();
            });
        }

        public DbSet<Application.Models.VendorSubscription> VendorSubscription { get; set; }

        public DbSet<CustomerSubscription> CustomerSubscription { get; set; }
    }
}
