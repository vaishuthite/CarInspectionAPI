﻿// <auto-generated />
using System;
using CarInspectionAPI.DATA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarInspectionAPI.Migrations
{
    [DbContext(typeof(CarInspectionContext))]
    [Migration("20241002114945_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarInspectionAPI.Models.TechnicalTest", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestId"));

                    b.Property<string>("CarRegistrationNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfInspection")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsOperational")
                        .HasColumnType("bit");

                    b.Property<DateTime>("NextInspectionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TestId");

                    b.HasIndex("CarRegistrationNumber");

                    b.ToTable("TechnicalTests");
                });

            modelBuilder.Entity("CarInspectionAPI.Models.Vehicle", b =>
                {
                    b.Property<string>("CarRegistrationNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarRegistrationNumber");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("CarInspectionAPI.Models.TechnicalTest", b =>
                {
                    b.HasOne("CarInspectionAPI.Models.Vehicle", "Vehicle")
                        .WithMany("TechnicalTests")
                        .HasForeignKey("CarRegistrationNumber");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("CarInspectionAPI.Models.Vehicle", b =>
                {
                    b.Navigation("TechnicalTests");
                });
#pragma warning restore 612, 618
        }
    }
}
