using Dryva.Devices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Devices.Repositories.Commands
{
    public class DevicesDbContext : DbContext
    {
        public DevicesDbContext(DbContextOptions<DevicesDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Device>(entity =>
            {
                entity.Property(p => p.SerialNumber).HasMaxLength(20).IsRequired();
                entity.HasIndex(p => p.SerialNumber).IsUnique();
                entity.HasIndex(p => p.Terminal).IsUnique();
                entity.Property(p => p.Class).HasMaxLength(20);
            });
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceTrail> DeviceTrails { get; set; }
        public DbSet<EntryTransitLog> EntryTransitLogs { get; set; }
        public DbSet<ExitTransitLog> ExitTransitLogs { get; set; }
        public DbSet<Route> Routes { get; set; }
    }
}
