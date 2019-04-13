﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartHousing.API.Database.Context;

namespace smart_housing_aspnet.Migrations
{
    [DbContext(typeof(SmartHousingContext))]
    partial class SmartHousingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SmartHousing.API.Bal.Models.Electricity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<int>("Tarriff_id");

                    b.HasKey("Id");

                    b.ToTable("Electricity");
                });

            modelBuilder.Entity("SmartHousing.API.Bal.Models.ElectricityTariff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("High_Tarrif");

                    b.Property<double>("Low_Tarrif");

                    b.Property<string>("Name");

                    b.Property<double>("One_Tarrif");

                    b.Property<double>("Supply_Fee");

                    b.HasKey("Id");

                    b.ToTable("ElectricityTariff");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            High_Tarrif = 0.0,
                            Low_Tarrif = 0.0,
                            Name = "Plavi",
                            One_Tarrif = 0.22,
                            Supply_Fee = 10.0
                        });
                });

            modelBuilder.Entity("SmartHousing.API.Bal.Models.Utilities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Entry_id");

                    b.Property<int>("UtilityType");

                    b.HasKey("Id");

                    b.ToTable("Utilities");
                });

            modelBuilder.Entity("SmartHousing.API.Bal.Models.Water", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<int>("Tarriff_id");

                    b.HasKey("Id");

                    b.ToTable("Water");
                });

            modelBuilder.Entity("SmartHousing.API.Bal.Models.WaterTariff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<double>("Tariff");

                    b.HasKey("Id");

                    b.ToTable("WaterTariff");
                });
#pragma warning restore 612, 618
        }
    }
}
