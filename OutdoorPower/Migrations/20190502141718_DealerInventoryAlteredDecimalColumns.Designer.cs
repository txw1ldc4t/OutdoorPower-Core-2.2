﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OutdoorPower.Models;

namespace OutdoorPower.Migrations
{
    [DbContext(typeof(OutdoorPowerContext))]
    [Migration("20190502141718_DealerInventoryAlteredDecimalColumns")]
    partial class DealerInventoryAlteredDecimalColumns
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OutdoorPower.Models.Dealer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(150);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("Website")
                        .HasMaxLength(500);

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Dealers");
                });

            modelBuilder.Entity("OutdoorPower.Models.DealerEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("DealerEmployeeLoginCredentialsId");

                    b.Property<int>("DealerEmployeeTypeId");

                    b.Property<int>("DealerId");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("DealerEmployees");
                });

            modelBuilder.Entity("OutdoorPower.Models.DealerEmployeeLoginCredential", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int>("DealerEmployeeId");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("OutdoorPower.Models.DealerInventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("Condition");

                    b.Property<DateTime>("DatePosted");

                    b.Property<int>("DealerId");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("EngineBrand")
                        .HasMaxLength(150);

                    b.Property<string>("EngineHorsePower")
                        .HasMaxLength(30);

                    b.Property<int>("EngineHours");

                    b.Property<short>("Fuel");

                    b.Property<bool>("OPTPublic");

                    b.Property<decimal>("Price")
                        .HasColumnName("decimal(18,2)");

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

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(20);

                    b.Property<string>("Title")
                        .HasMaxLength(300);

                    b.Property<string>("Warranty")
                        .HasMaxLength(300);

                    b.Property<decimal>("WholeSalePrice")
                        .HasColumnName("decimal(18,2)");

                    b.Property<int>("Year");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("DealerId");

                    b.HasIndex("QInventoryMakeId");

                    b.HasIndex("QInventoryModelId");

                    b.HasIndex("QInventoryModelOptionId");

                    b.HasIndex("QInventoryTypeId");

                    b.ToTable("DealerInventories");
                });

            modelBuilder.Entity("OutdoorPower.Models.DealerInventoryImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DealerInventoryId");

                    b.Property<string>("Path");

                    b.Property<string>("WebPath");

                    b.HasKey("Id");

                    b.HasIndex("DealerInventoryId");

                    b.ToTable("DealerInventoryImages");
                });

            modelBuilder.Entity("OutdoorPower.Models.Engine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Battery")
                        .HasMaxLength(20);

                    b.Property<string>("BatteryCharging")
                        .HasMaxLength(20);

                    b.Property<string>("BatteryChargingOutput")
                        .HasMaxLength(20);

                    b.Property<string>("Belts")
                        .HasMaxLength(100);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Carburetor")
                        .HasMaxLength(100);

                    b.Property<string>("Cooling")
                        .HasMaxLength(20);

                    b.Property<string>("Cylinders")
                        .HasMaxLength(60);

                    b.Property<string>("Displacement")
                        .HasMaxLength(10);

                    b.Property<string>("EngineModel")
                        .HasMaxLength(50);

                    b.Property<string>("Fuel")
                        .HasMaxLength(20);

                    b.Property<string>("FuelPump")
                        .HasMaxLength(100);

                    b.Property<string>("Fuses")
                        .HasMaxLength(40);

                    b.Property<string>("Governor")
                        .HasMaxLength(100);

                    b.Property<string>("IdleSpeed")
                        .HasMaxLength(20);

                    b.Property<string>("ModelNumber")
                        .HasMaxLength(30);

                    b.Property<string>("OilPump")
                        .HasMaxLength(70);

                    b.Property<string>("Power")
                        .HasMaxLength(30);

                    b.Property<string>("Starter")
                        .HasMaxLength(75);

                    b.HasKey("Id");

                    b.ToTable("Engines");
                });

            modelBuilder.Entity("OutdoorPower.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ContactMe");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Feedbacks");
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

                    b.ToTable("QInventoryMakes");
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

                    b.ToTable("QInventoryModels");
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

                    b.ToTable("QInventoryModelOptions");
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

                    b.ToTable("QInventoryTypes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("OutdoorPower.Models.DealerEmployeeLoginCredential")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("OutdoorPower.Models.DealerEmployeeLoginCredential")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OutdoorPower.Models.DealerEmployeeLoginCredential")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("OutdoorPower.Models.DealerEmployeeLoginCredential")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OutdoorPower.Models.DealerInventory", b =>
                {
                    b.HasOne("OutdoorPower.Models.Dealer", "DealerInfo")
                        .WithMany()
                        .HasForeignKey("DealerId")
                        .OnDelete(DeleteBehavior.Cascade);

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

            modelBuilder.Entity("OutdoorPower.Models.DealerInventoryImage", b =>
                {
                    b.HasOne("OutdoorPower.Models.DealerInventory", "DealerInventoryObject")
                        .WithMany("Images")
                        .HasForeignKey("DealerInventoryId")
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
