using Dryva.Security.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Security.Repositories.Commands
{
    public class SecurityDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Device>(entity =>
            {
                entity.Property(p => p.SerialNumber).HasMaxLength(20).IsRequired();
                entity.HasIndex(p => p.SerialNumber).IsUnique();
                entity.HasIndex(p => p.Terminal).IsUnique();
                entity.Property(p => p.Class).HasMaxLength(20);
            });
        }
    }
}
