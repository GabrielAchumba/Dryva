using CustomerSubscription.API.Application.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CustomerSubscription.API.Infrastructure
{
    public class SubscriptionDbContext : DbContext, IDisposable
    {
        public SubscriptionDbContext(DbContextOptions<SubscriptionDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.Property(p => p.SubscriptionId);
                entity.Property(p => p.Amount).HasColumnType("decimal(18,4)");
                entity.Property(p => p.CardSerialNumber);
                entity.Property(p => p.DepleteAmount);
                entity.Property(p => p.IsActive);
                entity.Property(p => p.CreatedOn);
                entity.Property(p => p.ModifiedOn);
                entity.Property(p => p.RechargeCode);
                entity.Property(p => p.TransactionCode);

                entity.Property(p => p.VendorId);

                entity.Property(p => p.CustomerId);
            });

        }

        public DbSet<Subscription> Subscriptions { get; set; }
    }
}
