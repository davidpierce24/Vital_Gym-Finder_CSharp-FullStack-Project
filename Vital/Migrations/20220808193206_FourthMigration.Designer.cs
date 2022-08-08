﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vital.Models;

#nullable disable

namespace Vital.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20220808193206_FourthMigration")]
    partial class FourthMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Vital.Models.Equipment", b =>
                {
                    b.Property<int>("EquipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EquipmentAmount")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EquipmentName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("GymId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("EquipmentId");

                    b.HasIndex("GymId");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("Vital.Models.Gym", b =>
                {
                    b.Property<int>("GymId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Address2")
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("GymName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("GymId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Gyms");
                });

            modelBuilder.Entity("Vital.Models.Hour", b =>
                {
                    b.Property<int>("HourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FridayClose")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FridayOpen")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("GymId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("MondayClose")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("MondayOpen")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("SaturdayClose")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("SaturdayOpen")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("SundayClose")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("SundayOpen")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ThursdayClose")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ThursdayOpen")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("TuesdayClose")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("TuesdayOpen")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("WednesdayClose")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("WednesdayOpen")
                        .HasColumnType("datetime(6)");

                    b.HasKey("HourId");

                    b.HasIndex("GymId");

                    b.ToTable("Hours");
                });

            modelBuilder.Entity("Vital.Models.Owner", b =>
                {
                    b.Property<int>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("OwnerId");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("Vital.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Vital.Models.Equipment", b =>
                {
                    b.HasOne("Vital.Models.Gym", "Gym")
                        .WithMany("GymEquipment")
                        .HasForeignKey("GymId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gym");
                });

            modelBuilder.Entity("Vital.Models.Gym", b =>
                {
                    b.HasOne("Vital.Models.Owner", "Owner")
                        .WithMany("GymsOwned")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Vital.Models.Hour", b =>
                {
                    b.HasOne("Vital.Models.Gym", "Gym")
                        .WithMany("GymHours")
                        .HasForeignKey("GymId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gym");
                });

            modelBuilder.Entity("Vital.Models.Gym", b =>
                {
                    b.Navigation("GymEquipment");

                    b.Navigation("GymHours");
                });

            modelBuilder.Entity("Vital.Models.Owner", b =>
                {
                    b.Navigation("GymsOwned");
                });
#pragma warning restore 612, 618
        }
    }
}
