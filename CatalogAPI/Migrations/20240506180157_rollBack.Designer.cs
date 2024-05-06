﻿// <auto-generated />
using System;
using CatalogAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AnamneseAPI.Migrations
{
    [DbContext(typeof(MySQLContext))]
    [Migration("20240506180157_rollBack")]
    partial class rollBack
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AnamneseAPI.Models.ReportModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AlcoholConsumption")
                        .HasColumnType("int");

                    b.Property<bool>("CardiovascularIssues")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CurrentMedications")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Diabetes")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("EmergencyContactName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EmergencyContactPhone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("FamilyHistoryCardiovascularIssues")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("FamilyHistoryDiabetes")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("MedicalHistory")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Observations")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PacientId")
                        .HasColumnType("int");

                    b.Property<string>("PhysicalActivity")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ReportDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Smoker")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("PacientId");

                    b.ToTable("ReportModel");
                });

            modelBuilder.Entity("CatalogAPI.Models.DoctorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("CatalogAPI.Models.PacientModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Birth")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ReportId")
                        .HasColumnType("int");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Pacient");
                });

            modelBuilder.Entity("AnamneseAPI.Models.ReportModel", b =>
                {
                    b.HasOne("CatalogAPI.Models.PacientModel", "Pacient")
                        .WithMany("Patients")
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacient");
                });

            modelBuilder.Entity("CatalogAPI.Models.PacientModel", b =>
                {
                    b.HasOne("CatalogAPI.Models.DoctorModel", "Doctor")
                        .WithMany("Pacients")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("CatalogAPI.Models.DoctorModel", b =>
                {
                    b.Navigation("Pacients");
                });

            modelBuilder.Entity("CatalogAPI.Models.PacientModel", b =>
                {
                    b.Navigation("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}
