﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace OnlyShare.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230303145624_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlyShare.Database.Models.WeatherForecast", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TemperatureC")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WeatherForecasts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7a73aefe-3140-4ff1-b984-e7075bbda300"),
                            Date = new DateTime(2021, 3, 3, 15, 56, 24, 189, DateTimeKind.Local).AddTicks(7987),
                            Summary = "Weather 1",
                            TemperatureC = 30
                        },
                        new
                        {
                            Id = new Guid("86c2428c-8d82-433d-a047-70a96a35baee"),
                            Date = new DateTime(2022, 3, 3, 15, 56, 24, 189, DateTimeKind.Local).AddTicks(8129),
                            Summary = "Weather 2",
                            TemperatureC = 35
                        },
                        new
                        {
                            Id = new Guid("e1dfa72c-d41f-4e15-be5c-3eea7f44f395"),
                            Date = new DateTime(2023, 3, 3, 15, 56, 24, 189, DateTimeKind.Local).AddTicks(8158),
                            Summary = "Weather 3",
                            TemperatureC = 40
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
