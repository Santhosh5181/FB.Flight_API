﻿// <auto-generated />
using System;
using FB.Flight_API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FB.Flight_API.Migrations
{
    [DbContext(typeof(FlightDBContext))]
    [Migration("20231121192338_ss")]
    partial class ss
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FB.Flight_API.Entities.Flight", b =>
                {
                    b.Property<int>("FlightNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AirLine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("From_Place")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Intrument_Used")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MealType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfRows")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("ScheduledDays")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("To_Place")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalBusinessClassSeats")
                        .HasColumnType("int");

                    b.Property<int>("TotalNonBusinessClassSeats")
                        .HasColumnType("int");

                    b.HasKey("FlightNumber");

                    b.ToTable("Flight");
                });
#pragma warning restore 612, 618
        }
    }
}
