﻿// <auto-generated />
using System;
using HotelAPI.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelAPI.Migrations
{
    [DbContext(typeof(Hotel_Context))]
    [Migration("20230329091243_billroom_new")]
    partial class billroom_new
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Hotel.BillRoom", b =>
                {
                    b.Property<int>("BillRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("cunstomerCustomerId")
                        .HasColumnType("int");

                    b.HasKey("BillRoomId");

                    b.HasIndex("RoomId");

                    b.HasIndex("cunstomerCustomerId");

                    b.ToTable("Billsroom");
                });

            modelBuilder.Entity("Hotel.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Alter")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NachName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("VorName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Hotel.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IstGebucht")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Kategorie")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Preis")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Quadrahtmeter")
                        .HasColumnType("int");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Hotel.BillRoom", b =>
                {
                    b.HasOne("Hotel.Room", "room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hotel.Customer", "cunstomer")
                        .WithMany()
                        .HasForeignKey("cunstomerCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cunstomer");

                    b.Navigation("room");
                });
#pragma warning restore 612, 618
        }
    }
}
