﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherTracker.Data;

#nullable disable

namespace WeatherTracker.Migrations
{
    [DbContext(typeof(WeatherTrackerDbContext))]
    [Migration("20221017122317_AddIconId")]
    partial class AddIconId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("WeatherTracker.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserCities");
                });

            modelBuilder.Entity("WeatherTracker.Models.WeatherData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<double>("Humidity")
                        .HasColumnType("REAL");

                    b.Property<string>("IconId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Temperature")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("WeatherDataSets");
                });

            modelBuilder.Entity("WeatherTracker.Models.WeatherData", b =>
                {
                    b.HasOne("WeatherTracker.Models.City", null)
                        .WithMany("WeatherData")
                        .HasForeignKey("CityId");
                });

            modelBuilder.Entity("WeatherTracker.Models.City", b =>
                {
                    b.Navigation("WeatherData");
                });
#pragma warning restore 612, 618
        }
    }
}
