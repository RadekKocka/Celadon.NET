﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VaccineTask;

namespace VaccineTask.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220304114241_entities")]
    partial class entities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VaccineTask.Models.Applicant", b =>
                {
                    b.Property<int>("ApplicantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SocialSecurityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Type")
                        .HasColumnType("datetime2");

                    b.HasKey("ApplicantId");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("VaccineTask.Models.Application", b =>
                {
                    b.Property<int>("ApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplicantId")
                        .HasColumnType("int");

                    b.Property<string>("ApplicantName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfApplication")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfVaccineApplication")
                        .HasColumnType("datetime2");

                    b.Property<int>("HospitalId")
                        .HasColumnType("int");

                    b.Property<string>("HospitalName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VaccineId")
                        .HasColumnType("int");

                    b.Property<string>("VaccineName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicationId");

                    b.HasIndex("ApplicantId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("VaccineTask.Models.Hospital", b =>
                {
                    b.Property<int>("HospitalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Budget")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HospitalId");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("VaccineTask.Models.HospitalVaccine", b =>
                {
                    b.Property<int>("HospitalId")
                        .HasColumnType("int");

                    b.Property<int>("VaccineId")
                        .HasColumnType("int");

                    b.Property<string>("HospitalName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfVaccines")
                        .HasColumnType("int");

                    b.Property<string>("VaccineName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HospitalId", "VaccineId");

                    b.ToTable("HospitalVaccine");
                });

            modelBuilder.Entity("VaccineTask.Models.Vaccine", b =>
                {
                    b.Property<int>("VaccineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("VaccineId");

                    b.ToTable("Vaccines");
                });

            modelBuilder.Entity("VaccineTask.Models.VaccineOrder", b =>
                {
                    b.Property<int>("VaccineOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HospitalId")
                        .HasColumnType("int");

                    b.Property<string>("HospitalName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfVaccinesBeingOrdered")
                        .HasColumnType("int");

                    b.Property<int>("TotalPriceOfVaccines")
                        .HasColumnType("int");

                    b.Property<int>("VaccineId")
                        .HasColumnType("int");

                    b.Property<string>("VaccineName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VaccineOrderId");

                    b.HasIndex("HospitalId");

                    b.ToTable("VaccineOrders");
                });

            modelBuilder.Entity("VaccineTask.Models.Application", b =>
                {
                    b.HasOne("VaccineTask.Models.Applicant", null)
                        .WithMany("Applications")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VaccineTask.Models.VaccineOrder", b =>
                {
                    b.HasOne("VaccineTask.Models.Hospital", null)
                        .WithMany("VaccineOrders")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
