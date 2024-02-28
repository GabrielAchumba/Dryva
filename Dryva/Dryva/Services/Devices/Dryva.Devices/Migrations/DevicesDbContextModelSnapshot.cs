﻿// <auto-generated />
using System;
using Dryva.Devices.Repositories.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dryva.Devices.Migrations
{
    [DbContext(typeof(DevicesDbContext))]
    partial class DevicesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dryva.Devices.Models.Device", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activated")
                        .HasColumnType("bit");

                    b.Property<string>("Class")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<float?>("Course")
                        .HasColumnType("real");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EW")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateTime?>("GpsModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<Guid?>("MapAxisId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("NS")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<Guid>("RouteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Speed")
                        .HasColumnType("real");

                    b.Property<int>("Terminal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SerialNumber")
                        .IsUnique();

                    b.HasIndex("Terminal")
                        .IsUnique();

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("Dryva.Devices.Models.DeviceTrail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float?>("Course")
                        .HasColumnType("real");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("EW")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateTime>("GpsModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("NS")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<float?>("Speed")
                        .HasColumnType("real");

                    b.Property<int>("Terminal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DeviceTrails");
                });

            modelBuilder.Entity("Dryva.Devices.Models.EntryTransitLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("Csn")
                        .HasColumnType("bigint");

                    b.Property<string>("EW")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<long>("LogId")
                        .HasColumnType("bigint");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("NS")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("RechargeCode")
                        .HasColumnType("int");

                    b.Property<int>("Terminal")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("UnitsLeft")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EntryTransitLogs");
                });

            modelBuilder.Entity("Dryva.Devices.Models.ExitTransitLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("Csn")
                        .HasColumnType("bigint");

                    b.Property<string>("LatNS")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<long>("LogId")
                        .HasColumnType("bigint");

                    b.Property<string>("LongEW")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("RechargeCode")
                        .HasColumnType("int");

                    b.Property<int>("Terminal")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("UnitsLeft")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ExitTransitLogs");
                });

            modelBuilder.Entity("Dryva.Devices.Models.Route", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Routes");
                });
#pragma warning restore 612, 618
        }
    }
}