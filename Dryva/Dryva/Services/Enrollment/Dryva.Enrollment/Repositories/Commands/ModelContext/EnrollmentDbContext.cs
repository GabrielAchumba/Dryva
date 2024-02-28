using Dryva.Enrollment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Repositories.Commands
{
    public class EnrollmentDbContext : DbContext
    {
        public EnrollmentDbContext(DbContextOptions<EnrollmentDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>(entity =>
            {
                entity.Property(p => p.Title).HasMaxLength(10);
                entity.Property(p => p.Surname).HasMaxLength(50).IsRequired();
                entity.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
                entity.Property(p => p.OtherName).HasMaxLength(50);
                entity.Property(p => p.Gender).HasMaxLength(8);

                entity.Property(p => p.Address).HasMaxLength(255);
                entity.Property(p => p.ResidentialCity).HasMaxLength(50);
                entity.Property(p => p.ResidentialState).HasMaxLength(50);
                entity.Property(p => p.Email).HasMaxLength(80);
                entity.Property(p => p.PhoneNumber).HasMaxLength(30);

                entity.Property(p => p.BloodGroup).HasMaxLength(10);
                entity.Property(p => p.Genotype).HasMaxLength(10);
                entity.Property(p => p.MaritalStatus).HasMaxLength(10);
                entity.Property(p => p.LGAOfOrigin).HasMaxLength(50);
                entity.Property(p => p.StateOfOrigin).HasMaxLength(50);
                entity.Property(p => p.Country).HasMaxLength(50);
            });

            builder.Entity<Driver>(entity =>
            {
                entity.Property(p => p.Title).HasMaxLength(10);
                entity.Property(p => p.Surname).HasMaxLength(50).IsRequired();
                entity.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
                entity.Property(p => p.OtherName).HasMaxLength(50);
                entity.Property(p => p.Gender).HasMaxLength(8);

                entity.Property(p => p.Address).HasMaxLength(255);
                entity.Property(p => p.ResidentialCity).HasMaxLength(50);
                entity.Property(p => p.ResidentialState).HasMaxLength(50);
                entity.Property(p => p.Email).HasMaxLength(80);
                entity.Property(p => p.PhoneNumber).HasMaxLength(30);

                entity.Property(p => p.BloodGroup).HasMaxLength(10);
                entity.Property(p => p.Genotype).HasMaxLength(10);
                entity.Property(p => p.MaritalStatus).HasMaxLength(10);
                entity.Property(p => p.LGAOfOrigin).HasMaxLength(50);
                entity.Property(p => p.StateOfOrigin).HasMaxLength(50);
                entity.Property(p => p.Country).HasMaxLength(50);

                entity.Property(p => p.MakeAndModel).HasMaxLength(50);
                entity.Property(p => p.ChassisNumber).HasMaxLength(50);
                entity.Property(p => p.EngineNumber).HasMaxLength(50);
                entity.Property(p => p.PlateNumber).HasMaxLength(50);

                entity.Property(p => p.OwnerSurname).HasMaxLength(50);
                entity.Property(p => p.OwnerFirstName).HasMaxLength(50);
                entity.Property(p => p.OwnerAddress).HasMaxLength(255);
                entity.Property(p => p.OwnerEmail).HasMaxLength(80);
                entity.Property(p => p.OwnerPhoneNumber).HasMaxLength(30);

                entity.Property(p => p.NOKNames).HasMaxLength(80);
                entity.Property(p => p.NOKAddress).HasMaxLength(255);
                entity.Property(p => p.NOKPhoneNumber).HasMaxLength(30);
                entity.Property(p => p.NOKRelationship).HasMaxLength(40);

                entity.Property(p => p.AccountNumber).HasMaxLength(20);
            });

            builder.Entity<RTPS>(entity =>
            {
                entity.Property(p => p.Title).HasMaxLength(10);
                entity.Property(p => p.Surname).HasMaxLength(50).IsRequired();
                entity.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
                entity.Property(p => p.OtherName).HasMaxLength(50);
                entity.Property(p => p.Gender).HasMaxLength(8);
                entity.Property(p => p.Email).HasMaxLength(80);
                entity.Property(p => p.PhoneNumber).HasMaxLength(30);
            });

            builder.Entity<Shareholder>(entity =>
            {
                entity.Property(p => p.Title).HasMaxLength(10);
                entity.Property(p => p.Surname).HasMaxLength(50).IsRequired();
                entity.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
                entity.Property(p => p.OtherName).HasMaxLength(50);
                entity.Property(p => p.Gender).HasMaxLength(8);
                entity.Property(p => p.Email).HasMaxLength(80);
                entity.Property(p => p.PhoneNumber).HasMaxLength(30);
            });

        }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<RTPS> RTPs { get; set; }
        public DbSet<Shareholder> Shareholders { get; set; }
        public DbSet<CaptureSession> CaptureSessions { get; set; }
        public DbSet<Lga> Lgas { get; set; }
        public DbSet<State> States { get; set; }
    }
}
