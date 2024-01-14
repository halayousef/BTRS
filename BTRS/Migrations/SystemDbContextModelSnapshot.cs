﻿// <auto-generated />
using System;
using BTRS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTRS.Migrations
{
    [DbContext(typeof(SystemDbContext))]
    partial class SystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BTRS.Models.Administrators", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("full_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("userName")
                        .IsUnique();

                    b.ToTable("administrators");
                });

            modelBuilder.Entity("BTRS.Models.Bus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("administratorID")
                        .HasColumnType("int");

                    b.Property<string>("captain_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numOfSeats")
                        .HasColumnType("int");

                    b.Property<int>("tripID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("administratorID");

                    b.HasIndex("tripID");

                    b.ToTable("Bus");
                });

            modelBuilder.Entity("BTRS.Models.Passenger_Trip", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("passengerID")
                        .HasColumnType("int");

                    b.Property<int>("tripID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("passengerID");

                    b.HasIndex("tripID");

                    b.ToTable("passenger_Trip");
                });

            modelBuilder.Entity("BTRS.Models.Passengers", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("email_address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("username")
                        .IsUnique();

                    b.ToTable("passengers");
                });

            modelBuilder.Entity("BTRS.Models.Trip", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("administorID")
                        .HasColumnType("int");

                    b.Property<int>("bus_number")
                        .HasColumnType("int");

                    b.Property<string>("destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("end_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("start_date")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("administorID");

                    b.ToTable("trip");
                });

            modelBuilder.Entity("BTRS.Models.Bus", b =>
                {
                    b.HasOne("BTRS.Models.Administrators", "administrators")
                        .WithMany("bus")
                        .HasForeignKey("administratorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTRS.Models.Trip", "trip")
                        .WithMany("bus")
                        .HasForeignKey("tripID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("administrators");

                    b.Navigation("trip");
                });

            modelBuilder.Entity("BTRS.Models.Passenger_Trip", b =>
                {
                    b.HasOne("BTRS.Models.Passengers", "passenger")
                        .WithMany("passenger_trip")
                        .HasForeignKey("passengerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTRS.Models.Trip", "trip")
                        .WithMany("passenger_trip")
                        .HasForeignKey("tripID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("passenger");

                    b.Navigation("trip");
                });

            modelBuilder.Entity("BTRS.Models.Trip", b =>
                {
                    b.HasOne("BTRS.Models.Administrators", "administrators")
                        .WithMany("trip")
                        .HasForeignKey("administorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("administrators");
                });

            modelBuilder.Entity("BTRS.Models.Administrators", b =>
                {
                    b.Navigation("bus");

                    b.Navigation("trip");
                });

            modelBuilder.Entity("BTRS.Models.Passengers", b =>
                {
                    b.Navigation("passenger_trip");
                });

            modelBuilder.Entity("BTRS.Models.Trip", b =>
                {
                    b.Navigation("bus");

                    b.Navigation("passenger_trip");
                });
#pragma warning restore 612, 618
        }
    }
}