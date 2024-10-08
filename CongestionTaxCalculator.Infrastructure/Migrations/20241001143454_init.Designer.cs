﻿// <auto-generated />
using System;
using CongestionTaxCalculator.Infrastructure.DbContexts.Sql.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CongestionTaxCalculator.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241001143454_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entities.Receiption.TaxReceipt", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LicensePlateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ReceivedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TaxScopeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TaxStationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LicensePlateId");

                    b.HasIndex("TaxScopeId");

                    b.HasIndex("TaxStationId");

                    b.ToTable("TaxReceipts");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entities.Regions.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entities.Regions.TaxStation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StationName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("TaxStations");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entities.Tax.TaxRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaxDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TaxOn")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TaxRoles");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entities.Tax.TaxRoleRegion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TaxRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.HasIndex("TaxRoleId");

                    b.ToTable("TaxRoleRegions");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entities.Tax.TaxRoleVehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TaxRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TaxRoleId");

                    b.HasIndex("VehicleId");

                    b.ToTable("TaxRoleVehicles");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entities.Tax.TaxScope", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TaxRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TaxRoleId");

                    b.ToTable("TaxScopes");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entities.Vehicles.LicensePlate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VehicleOwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleOwnerNationalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LicensePlates");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entities.Vehicles.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entities.Receiption.TaxReceipt", b =>
                {
                    b.HasOne("CongestionTaxCalculator.Domain.Entities.Vehicles.LicensePlate", "LicensePlate")
                        .WithMany("TaxReceipts")
                        .HasForeignKey("LicensePlateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CongestionTaxCalculator.Domain.Entities.Tax.TaxScope", "TaxScope")
                        .WithMany("TaxReceipts")
                        .HasForeignKey("TaxScopeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CongestionTaxCalculator.Domain.Entities.Regions.TaxStation", "TaxStation")
                        .WithMany("TaxReceipts")
                        .HasForeignKey("TaxStationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("LicensePlate");

                    b.Navigation("TaxScope");

                    b.Navigation("TaxStation");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entities.Regions.TaxStation", b =>
                {
                    b.HasOne("CongestionTaxCalculator.Domain.Entities.Regions.Region", "Region")
                        .WithMany("TaxStations")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entities.Tax.TaxRole", b =>
                {
                    b.OwnsOne("CongestionTaxCalculator.Domain.Entities.Tax.ValueObjects.TaxAmount", "MaximumAmount", b1 =>
                        {
                            b1.Property<Guid>("TaxRoleId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("MyProperty")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("TaxRoleId");

                            b1.ToTable("TaxRoles");

                            b1.WithOwner()
                                .HasForeignKey("TaxRoleId");
                        });

                    b.OwnsOne("CongestionTaxCalculator.Domain.Entities.Tax.ValueObjects.TaxAmount", "MinimumAmount", b1 =>
                        {
                            b1.Property<Guid>("TaxRoleId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("MyProperty")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("TaxRoleId");

                            b1.ToTable("TaxRoles");

                            b1.WithOwner()
                                .HasForeignKey("TaxRoleId");
                        });

                    b.Navigation("MaximumAmount")
                        .IsRequired();

                    b.Navigation("MinimumAmount")
                        .IsRequired();
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entities.Tax.TaxRoleRegion", b =>
                {
                    b.HasOne("CongestionTaxCalculator.Domain.Entities.Regions.Region", "Region")
                        .WithMany("TaxRoleRegions")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CongestionTaxCalculator.Domain.Entities.Tax.TaxRole", "TaxRole")
                        .WithMany("TaxRoleRegions")
                        .HasForeignKey("TaxRoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Region");

                    b.Navigation("TaxRole");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entities.Tax.TaxRoleVehicle", b =>
                {
                    b.HasOne("CongestionTaxCalculator.Domain.Entities.Tax.TaxRole", "TaxRole")
                        .WithMany("TaxRoleVehicles")
                        .HasForeignKey("TaxRoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CongestionTaxCalculator.Domain.Entities.Vehicles.Vehicle", "Vehicle")
                        .WithMany("TaxRoleVehicles")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TaxRole");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entities.Tax.TaxScope", b =>
                {
                    b.HasOne("CongestionTaxCalculator.Domain.Entities.Tax.TaxRole", "TaxRole")
                        .WithMany("TaxScopes")
                        .HasForeignKey("TaxRoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("CongestionTaxCalculator.Domain.Entities.Tax.ValueObjects.TaxAmount", "TaxAmount", b1 =>
                        {
                            b1.Property<Guid>("TaxScopeId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("MyProperty")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("TaxScopeId");

                            b1.ToTable("TaxScopes");

                            b1.WithOwner()
                                .HasForeignKey("TaxScopeId");
                        });

                    b.Navigation("TaxAmount")
                        .IsRequired();

                    b.Navigation("TaxRole");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entities.Regions.Region", b =>
                {
                    b.Navigation("TaxRoleRegions");

                    b.Navigation("TaxStations");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entities.Regions.TaxStation", b =>
                {
                    b.Navigation("TaxReceipts");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entities.Tax.TaxRole", b =>
                {
                    b.Navigation("TaxRoleRegions");

                    b.Navigation("TaxRoleVehicles");

                    b.Navigation("TaxScopes");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entities.Tax.TaxScope", b =>
                {
                    b.Navigation("TaxReceipts");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entities.Vehicles.LicensePlate", b =>
                {
                    b.Navigation("TaxReceipts");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Entities.Vehicles.Vehicle", b =>
                {
                    b.Navigation("TaxRoleVehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
