﻿// <auto-generated />
using System;
using Anamnese.API.ORM.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Anamnese.API.Migrations
{
    [DbContext(typeof(AnamneseDbContext))]
    partial class AnamneseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Anamnese.API.ORM.Entity.PacientModel", b =>
                {
                    b.Property<int>("PacientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("Birth")
                        .HasColumnType("date");

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

                    b.Property<int>("ProfissionalId")
                        .HasColumnType("int");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PacientId");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("Pacient");
                });

            modelBuilder.Entity("Anamnese.API.ORM.Entity.ProfissionalModel", b =>
                {
                    b.Property<int>("ProfissionalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("ProfissionalId");

                    b.ToTable("Profissional");
                });

            modelBuilder.Entity("Anamnese.API.ORM.Entity.ReferralModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("MedicalSpeciality")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PacientId")
                        .HasColumnType("int");

                    b.Property<string>("PacientName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ReferralDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("PacientId");

                    b.ToTable("Referral");
                });

            modelBuilder.Entity("Anamnese.API.ORM.Entity.ReportModel", b =>
                {
                    b.Property<int>("ReportId")
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

                    b.Property<string>("PacientName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhysicalActivity")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ReportDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Smoker")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("ReportId");

                    b.HasIndex("PacientId")
                        .IsUnique();

                    b.ToTable("Report");
                });

            modelBuilder.Entity("Anamnese.API.ORM.Entity.PacientModel", b =>
                {
                    b.HasOne("Anamnese.API.ORM.Entity.ProfissionalModel", "Profissional")
                        .WithMany()
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("Anamnese.API.ORM.Entity.ReferralModel", b =>
                {
                    b.HasOne("Anamnese.API.ORM.Entity.PacientModel", "Pacient")
                        .WithMany("Referrals")
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacient");
                });

            modelBuilder.Entity("Anamnese.API.ORM.Entity.ReportModel", b =>
                {
                    b.HasOne("Anamnese.API.ORM.Entity.PacientModel", "Pacient")
                        .WithOne("Report")
                        .HasForeignKey("Anamnese.API.ORM.Entity.ReportModel", "PacientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacient");
                });

            modelBuilder.Entity("Anamnese.API.ORM.Entity.PacientModel", b =>
                {
                    b.Navigation("Referrals");

                    b.Navigation("Report")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
