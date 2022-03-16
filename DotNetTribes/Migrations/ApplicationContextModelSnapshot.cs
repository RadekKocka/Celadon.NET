﻿using System;
using DotNetTribes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotNetTribes.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotNetTribes.Models.Building", b =>
                {
                    b.Property<long>("BuildingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("KingdomId")
                        .HasColumnType("int");

                    b.HasKey("BuildingId");

                    b.HasIndex("KingdomId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("DotNetTribes.Models.Kingdom", b =>
                {
                    b.Property<int>("KingdomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KingdomId");

                    b.ToTable("Kingdoms");
                });

            modelBuilder.Entity("DotNetTribes.Models.Resource", b =>
                {
                    b.Property<int>("ResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");


                    b.Property<int>("CreatedAt")
                        .HasColumnType("int");

                    b.Property<int>("Generation")
                        .HasColumnType("int");


                    b.Property<int>("KingdomId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ResourceId");

                    b.HasIndex("KingdomId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("DotNetTribes.Models.Troop", b =>
                {
                    b.Property<long>("TroopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("KingdomId")
                        .HasColumnType("int");

                    b.HasKey("TroopId");

                    b.HasIndex("KingdomId");

                    b.ToTable("Troops");
                });

            modelBuilder.Entity("DotNetTribes.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KingdomId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("KingdomId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DotNetTribes.Models.Building", b =>
                {
                    b.HasOne("DotNetTribes.Models.Kingdom", null)
                        .WithMany("Buildings")
                        .HasForeignKey("KingdomId");
                });

            modelBuilder.Entity("DotNetTribes.Models.Resource", b =>
                {
                    b.HasOne("DotNetTribes.Models.Kingdom", "Kingdom")
                        .WithMany("Resources")
                        .HasForeignKey("KingdomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kingdom");
                });

            modelBuilder.Entity("DotNetTribes.Models.Troop", b =>
                {
                    b.HasOne("DotNetTribes.Models.Kingdom", null)
                        .WithMany("Troops")
                        .HasForeignKey("KingdomId");
                });

            modelBuilder.Entity("DotNetTribes.Models.User", b =>
                {
                    b.HasOne("DotNetTribes.Models.Kingdom", "Kingdom")
                        .WithOne("User")
                        .HasForeignKey("DotNetTribes.Models.User", "KingdomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kingdom");
                });

            modelBuilder.Entity("DotNetTribes.Models.Kingdom", b =>
                {
                    b.Navigation("Buildings");

                    b.Navigation("Resources");

                    b.Navigation("Troops");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
