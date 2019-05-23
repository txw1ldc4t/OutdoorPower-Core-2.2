﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OutdoorPower.Models.Metrics;

namespace OutdoorPower.Migrations.Metrics
{
    [DbContext(typeof(MetricsContext))]
    partial class MetricsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OutdoorPower.Models.Metrics.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(200);

                    b.Property<string>("City")
                        .HasMaxLength(100);

                    b.Property<string>("Email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(20);

                    b.Property<int>("InventoryId");

                    b.Property<string>("LastName")
                        .HasMaxLength(30);

                    b.Property<string>("MiddleInitial")
                        .HasMaxLength(1);

                    b.Property<int>("OPInventoryId");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(25);

                    b.Property<short>("PhoneType");

                    b.Property<string>("State")
                        .HasMaxLength(2);

                    b.Property<string>("Zip")
                        .HasMaxLength(5);

                    b.HasKey("Id");

                    b.HasIndex("InventoryId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("OutdoorPower.Models.Metrics.DailyRevenue", b =>
                {
                    b.Property<int>("Day")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Revenue");

                    b.HasKey("Day");

                    b.ToTable("DailyRevenues");
                });

            modelBuilder.Entity("OutdoorPower.Models.Metrics.DealerMetric", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DealerId");

                    b.HasKey("Id");

                    b.ToTable("DealerMetrics");
                });

            modelBuilder.Entity("OutdoorPower.Models.Metrics.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short?>("Condition");

                    b.Property<DateTime>("DatePosted");

                    b.Property<DateTime?>("DateSold");

                    b.Property<int?>("DealerEmployeeId");

                    b.Property<int>("DealerId");

                    b.Property<string>("EngineBrand")
                        .HasMaxLength(150);

                    b.Property<string>("EngineHorsePower")
                        .HasMaxLength(30);

                    b.Property<int?>("EngineHours");

                    b.Property<short?>("Fuel");

                    b.Property<int>("OPInventoryId");

                    b.Property<decimal>("Price");

                    b.Property<decimal?>("PriceSold");

                    b.Property<int?>("QInventoryMakeId");

                    b.Property<string>("QInventoryMakeOther")
                        .HasMaxLength(150);

                    b.Property<int?>("QInventoryModelId");

                    b.Property<int?>("QInventoryModelOptionId");

                    b.Property<string>("QInventoryModelOptionOther")
                        .HasMaxLength(100);

                    b.Property<string>("QInventoryModelOther")
                        .HasMaxLength(100);

                    b.Property<int>("QInventoryTypeId");

                    b.Property<int?>("SalesType");

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(20);

                    b.Property<decimal?>("WholeSalePrice");

                    b.Property<int?>("Year");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("QInventoryMakeId");

                    b.HasIndex("QInventoryModelId");

                    b.HasIndex("QInventoryModelOptionId");

                    b.HasIndex("QInventoryTypeId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("OutdoorPower.Models.Metrics.MonthlyMetric", b =>
                {
                    b.Property<int>("Week")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Total");

                    b.HasKey("Week");

                    b.ToTable("MonthlyMetrics");
                });

            modelBuilder.Entity("OutdoorPower.Models.Metrics.MonthlyRevenue", b =>
                {
                    b.Property<int>("Month")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Revenue");

                    b.HasKey("Month");

                    b.ToTable("MonthlyRevenues");
                });

            modelBuilder.Entity("OutdoorPower.Models.Metrics.UnitsSold", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand");

                    b.Property<int>("Units");

                    b.HasKey("Id");

                    b.ToTable("UnitsSoldSet");
                });

            modelBuilder.Entity("OutdoorPower.Models.Metrics.YearlyMetric", b =>
                {
                    b.Property<int>("Month")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Total");

                    b.HasKey("Month");

                    b.ToTable("YearlyMetrics");
                });

            modelBuilder.Entity("OutdoorPower.Models.QInventoryMake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Display");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("QInventoryMake");
                });

            modelBuilder.Entity("OutdoorPower.Models.QInventoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Commercial");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int>("QInventoryMakeId");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("QInventoryMakeId");

                    b.HasIndex("TypeId");

                    b.ToTable("QInventoryModel");
                });

            modelBuilder.Entity("OutdoorPower.Models.QInventoryModelOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int>("QInventoryModelId");

                    b.HasKey("Id");

                    b.ToTable("QInventoryModelOption");
                });

            modelBuilder.Entity("OutdoorPower.Models.QInventoryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("QInventoryType");
                });

            modelBuilder.Entity("OutdoorPower.Models.Metrics.Customer", b =>
                {
                    b.HasOne("OutdoorPower.Models.Metrics.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OutdoorPower.Models.Metrics.Inventory", b =>
                {
                    b.HasOne("OutdoorPower.Models.QInventoryMake", "Make")
                        .WithMany()
                        .HasForeignKey("QInventoryMakeId");

                    b.HasOne("OutdoorPower.Models.QInventoryModel", "Model")
                        .WithMany()
                        .HasForeignKey("QInventoryModelId");

                    b.HasOne("OutdoorPower.Models.QInventoryModelOption", "ModelOption")
                        .WithMany()
                        .HasForeignKey("QInventoryModelOptionId");

                    b.HasOne("OutdoorPower.Models.QInventoryType", "Type")
                        .WithMany()
                        .HasForeignKey("QInventoryTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OutdoorPower.Models.QInventoryModel", b =>
                {
                    b.HasOne("OutdoorPower.Models.QInventoryMake", "Make")
                        .WithMany()
                        .HasForeignKey("QInventoryMakeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OutdoorPower.Models.QInventoryType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
