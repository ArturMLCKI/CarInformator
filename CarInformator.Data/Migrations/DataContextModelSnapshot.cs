﻿// <auto-generated />
using System;
using Carinformator.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarInformator.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarCarInsuranceHistorian", b =>
                {
                    b.Property<int>("InsuranceHistoriansId")
                        .HasColumnType("int");

                    b.Property<int>("InsuredCarsCarId")
                        .HasColumnType("int");

                    b.HasKey("InsuranceHistoriansId", "InsuredCarsCarId");

                    b.HasIndex("InsuredCarsCarId");

                    b.ToTable("CarCarInsuranceHistorian");
                });

            modelBuilder.Entity("CarInformator.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Generation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarInformator.Models.Historian.CarInsuranceHistorian", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AccidentFree")
                        .HasColumnType("bit");

                    b.Property<string>("DescAccident")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Milage")
                        .HasColumnType("int");

                    b.Property<int>("PrevOwner")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Car Insurances");
                });

            modelBuilder.Entity("CarInformator.Models.Historian.CarRepairHistorian", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("RepairedCarsCarId")
                        .HasColumnType("int");

                    b.Property<string>("RepiarDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RepiarName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("RepairedCarsCarId");

                    b.ToTable("CarRepairs");
                });

            modelBuilder.Entity("CarInformator.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int>("DrivingExp")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CarCarInsuranceHistorian", b =>
                {
                    b.HasOne("CarInformator.Models.Historian.CarInsuranceHistorian", null)
                        .WithMany()
                        .HasForeignKey("InsuranceHistoriansId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarInformator.Models.Car", null)
                        .WithMany()
                        .HasForeignKey("InsuredCarsCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarInformator.Models.Car", b =>
                {
                    b.HasOne("CarInformator.Models.User", "User")
                        .WithMany("Cars")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarInformator.Models.Historian.CarRepairHistorian", b =>
                {
                    b.HasOne("CarInformator.Models.Car", "Cars")
                        .WithMany("CarRepairs")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CarInformator.Models.Car", "RepairedCars")
                        .WithMany()
                        .HasForeignKey("RepairedCarsCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cars");

                    b.Navigation("RepairedCars");
                });

            modelBuilder.Entity("CarInformator.Models.Car", b =>
                {
                    b.Navigation("CarRepairs");
                });

            modelBuilder.Entity("CarInformator.Models.User", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
