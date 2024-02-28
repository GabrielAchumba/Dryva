using Dryva.Maps.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Maps.Repositories.Commands
{
    public class MapsDbContext : DbContext
    {
        public MapsDbContext(DbContextOptions<MapsDbContext> options)
            : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MapAxis>(entity =>
            {
                entity.Property(p => p.Name).HasMaxLength(50).IsRequired();
                entity.Property(p => p.Code).HasMaxLength(128);
                entity.Property(p => p.ParentCode).HasMaxLength(128);
                entity.Property(p => p.Description).HasMaxLength(255);
            });
        }

        public DbSet<MapAxis> MapAxes { get; set; }
    }
}
