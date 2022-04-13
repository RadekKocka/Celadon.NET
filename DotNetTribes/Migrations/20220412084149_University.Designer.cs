﻿// <auto-generated />
using System;
using DotNetTribes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotNetTribes.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220412084149_University")]
    partial class University
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotNetTribes.Models.Battle", b =>
                {
                    b.Property<int>("BattleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ArriveAt")
                        .HasColumnType("bigint");

                    b.Property<int>("AttackerId")
                        .HasColumnType("int");

                    b.Property<int>("DefenderId")
                        .HasColumnType("int");

                    b.Property<long>("FightStart")
                        .HasColumnType("bigint");

                    b.Property<int>("FoodStolen")
                        .HasColumnType("int");

                    b.Property<int>("GoldStolen")
                        .HasColumnType("int");

                    b.Property<int>("LostTroopsAttacker")
                        .HasColumnType("int");

                    b.Property<int>("LostTroopsDefender")
                        .HasColumnType("int");

                    b.Property<long>("ReturnAt")
                        .HasColumnType("bigint");

                    b.Property<int>("WinnerId")
                        .HasColumnType("int");

                    b.HasKey("BattleId");

                    b.ToTable("Battles");
                });

            modelBuilder.Entity("DotNetTribes.Models.Building", b =>
                {
                    b.Property<int>("BuildingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Finished_at")
                        .HasColumnType("bigint");

                    b.Property<int>("Hp")
                        .HasColumnType("int");

                    b.Property<int>("KingdomId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<long>("Started_at")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("BuildingId");

                    b.HasIndex("KingdomId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("DotNetTribes.Models.BuildingUpgrade", b =>
                {
                    b.Property<int>("BuildingUpgradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("FinishedAt")
                        .HasColumnType("bigint");

                    b.Property<int>("KingdomId")
                        .HasColumnType("int");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<long>("StartedAt")
                        .HasColumnType("bigint");

                    b.HasKey("BuildingUpgradeId");

                    b.HasIndex("KingdomId");

                    b.ToTable("BuildingUpgrade");
                });

            modelBuilder.Entity("DotNetTribes.Models.GameRules", b =>
                {
                    b.Property<int>("GameRulesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AcademyHP")
                        .HasColumnType("int");

                    b.Property<int>("AcademyLevelNCost")
                        .HasColumnType("int");

                    b.Property<int>("AcademyLevelNDuration")
                        .HasColumnType("int");

                    b.Property<int>("AcademyLevelOneCost")
                        .HasColumnType("int");

                    b.Property<int>("AcademyLevelOneDuration")
                        .HasColumnType("int");

                    b.Property<int>("AllTroopsAtkBonusCost")
                        .HasColumnType("int");

                    b.Property<int>("AllTroopsAtkBonusDuration")
                        .HasColumnType("int");

                    b.Property<int>("AllTroopsDefBonusCost")
                        .HasColumnType("int");

                    b.Property<int>("AllTroopsDefBonusDuration")
                        .HasColumnType("int");

                    b.Property<int>("BlacksmithHp")
                        .HasColumnType("int");

                    b.Property<int>("BlacksmithLevelOneCost")
                        .HasColumnType("int");

                    b.Property<int>("BlacksmithLevelOneDuration")
                        .HasColumnType("int");

                    b.Property<int>("BuildingBuildSpeedCost")
                        .HasColumnType("int");

                    b.Property<int>("BuildingBuildSpeedDuration")
                        .HasColumnType("int");

                    b.Property<int>("CostTroopRanger")
                        .HasColumnType("int");

                    b.Property<int>("CostTroopScout")
                        .HasColumnType("int");

                    b.Property<int>("FarmAllLevelsCost")
                        .HasColumnType("int");

                    b.Property<int>("FarmAllLevelsDuration")
                        .HasColumnType("int");

                    b.Property<int>("FarmAllLevelsFoodGeneration")
                        .HasColumnType("int");

                    b.Property<int>("FarmHP")
                        .HasColumnType("int");

                    b.Property<int>("FarmProduceBonusCost")
                        .HasColumnType("int");

                    b.Property<int>("FarmProduceBonusDuration")
                        .HasColumnType("int");

                    b.Property<int>("IronMineCost")
                        .HasColumnType("int");

                    b.Property<int>("IronMineDuration")
                        .HasColumnType("int");

                    b.Property<int>("IronMineGeneration")
                        .HasColumnType("int");

                    b.Property<int>("IronMineHP")
                        .HasColumnType("int");

                    b.Property<int>("MapBoundariesX")
                        .HasColumnType("int");

                    b.Property<int>("MapBoundariesY")
                        .HasColumnType("int");

                    b.Property<int>("MarketplaceAllLevelsCost")
                        .HasColumnType("int");

                    b.Property<int>("MarketplaceAllLevelsDuration")
                        .HasColumnType("int");

                    b.Property<int>("MarketplaceHP")
                        .HasColumnType("int");

                    b.Property<int>("MarketplaceLevelOneCost")
                        .HasColumnType("int");

                    b.Property<int>("MarketplaceLevelOneDuration")
                        .HasColumnType("int");

                    b.Property<int>("MarketplaceMaxResources")
                        .HasColumnType("int");

                    b.Property<int>("MineALlLevelsGoldGeneration")
                        .HasColumnType("int");

                    b.Property<int>("MineAllLevelsCost")
                        .HasColumnType("int");

                    b.Property<int>("MineAllLevesDuration")
                        .HasColumnType("int");

                    b.Property<int>("MineHP")
                        .HasColumnType("int");

                    b.Property<int>("MineProduceBonusCost")
                        .HasColumnType("int");

                    b.Property<int>("MineProduceBonusDuration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StartingFood")
                        .HasColumnType("int");

                    b.Property<int>("StartingGold")
                        .HasColumnType("int");

                    b.Property<int>("StorageLimit")
                        .HasColumnType("int");

                    b.Property<int>("TimeUpgradeTroopRanger")
                        .HasColumnType("int");

                    b.Property<int>("TimeUpgradeTroopScout")
                        .HasColumnType("int");

                    b.Property<int>("TownhallAllLevelsCost")
                        .HasColumnType("int");

                    b.Property<int>("TownhallHP")
                        .HasColumnType("int");

                    b.Property<int>("TownhallLevelNDuration")
                        .HasColumnType("int");

                    b.Property<int>("TownhallLevelOneDuration")
                        .HasColumnType("int");

                    b.Property<int>("TrainingTimeTroopRanger")
                        .HasColumnType("int");

                    b.Property<int>("TrainingTimeTroopScout")
                        .HasColumnType("int");

                    b.Property<int>("TroopAllLevelsCost")
                        .HasColumnType("int");

                    b.Property<int>("TroopAllLevelsDuration")
                        .HasColumnType("int");

                    b.Property<int>("TroopAttack")
                        .HasColumnType("int");

                    b.Property<int>("TroopCapacity")
                        .HasColumnType("int");

                    b.Property<int>("TroopDefense")
                        .HasColumnType("int");

                    b.Property<int>("TroopFoodConsumption")
                        .HasColumnType("int");

                    b.Property<int>("TroopHP")
                        .HasColumnType("int");

                    b.Property<int>("TroopRangerHp")
                        .HasColumnType("int");

                    b.Property<int>("TroopScoutHp")
                        .HasColumnType("int");

                    b.Property<int>("TroopsTrainSpeedCost")
                        .HasColumnType("int");

                    b.Property<int>("TroopsTrainSpeedDuration")
                        .HasColumnType("int");

                    b.Property<int>("UniversityAllLevelCost")
                        .HasColumnType("int");

                    b.Property<int>("UniversityAllLevelDuration")
                        .HasColumnType("int");

                    b.Property<int>("UniversityHP")
                        .HasColumnType("int");

                    b.Property<int>("UpgradeForSpecialTroopScout")
                        .HasColumnType("int");

                    b.Property<int>("UpgradeForTroopRanger")
                        .HasColumnType("int");

                    b.HasKey("GameRulesId");

                    b.ToTable("GameRules");

                    b.HasData(
                        new
                        {
                            GameRulesId = 1,
                            AcademyHP = 150,
                            AcademyLevelNCost = 100,
                            AcademyLevelNDuration = 60,
                            AcademyLevelOneCost = 150,
                            AcademyLevelOneDuration = 90,
                            AllTroopsAtkBonusCost = 10,
                            AllTroopsAtkBonusDuration = 10,
                            AllTroopsDefBonusCost = 10,
                            AllTroopsDefBonusDuration = 10,
                            BlacksmithHp = 150,
                            BlacksmithLevelOneCost = 500,
                            BlacksmithLevelOneDuration = 600,
                            BuildingBuildSpeedCost = 10,
                            BuildingBuildSpeedDuration = 10,
                            CostTroopRanger = 50,
                            CostTroopScout = 100,
                            FarmAllLevelsCost = 100,
                            FarmAllLevelsDuration = 60,
                            FarmAllLevelsFoodGeneration = 5,
                            FarmHP = 100,
                            FarmProduceBonusCost = 10,
                            FarmProduceBonusDuration = 10,
                            IronMineCost = 100,
                            IronMineDuration = 60,
                            IronMineGeneration = 5,
                            IronMineHP = 100,
                            MapBoundariesX = 101,
                            MapBoundariesY = 101,
                            MarketplaceAllLevelsCost = 100,
                            MarketplaceAllLevelsDuration = 10,
                            MarketplaceHP = 100,
                            MarketplaceLevelOneCost = 1,
                            MarketplaceLevelOneDuration = 1,
                            MarketplaceMaxResources = 75,
                            MineALlLevelsGoldGeneration = 5,
                            MineAllLevelsCost = 100,
                            MineAllLevesDuration = 60,
                            MineHP = 100,
                            MineProduceBonusCost = 10,
                            MineProduceBonusDuration = 10,
                            Name = "Production",
                            StartingFood = 500,
                            StartingGold = 500,
                            StorageLimit = 100,
                            TimeUpgradeTroopRanger = 43200,
                            TimeUpgradeTroopScout = 72000,
                            TownhallAllLevelsCost = 200,
                            TownhallHP = 200,
                            TownhallLevelNDuration = 60,
                            TownhallLevelOneDuration = 120,
                            TrainingTimeTroopRanger = 200,
                            TrainingTimeTroopScout = 300,
                            TroopAllLevelsCost = 25,
                            TroopAllLevelsDuration = 30,
                            TroopAttack = 10,
                            TroopCapacity = 2,
                            TroopDefense = 5,
                            TroopFoodConsumption = 2,
                            TroopHP = 20,
                            TroopRangerHp = 10,
                            TroopScoutHp = 1,
                            TroopsTrainSpeedCost = 10,
                            TroopsTrainSpeedDuration = 10,
                            UniversityAllLevelCost = 300,
                            UniversityAllLevelDuration = 10,
                            UniversityHP = 200,
                            UpgradeForSpecialTroopScout = 1000,
                            UpgradeForTroopRanger = 2000
                        });
                });

            modelBuilder.Entity("DotNetTribes.Models.Kingdom", b =>
                {
                    b.Property<int>("KingdomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KingdomX")
                        .HasColumnType("int");

                    b.Property<int>("KingdomY")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KingdomId");

                    b.ToTable("Kingdoms");
                });

            modelBuilder.Entity("DotNetTribes.Models.Offer", b =>
                {
                    b.Property<int>("OfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BuyerKingdomId")
                        .HasColumnType("int");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<long>("ExpireAt")
                        .HasColumnType("bigint");

                    b.Property<int>("PayingAmount")
                        .HasColumnType("int");

                    b.Property<string>("PayingType")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("ResourceReturned")
                        .HasColumnType("bit");

                    b.Property<int>("SellerKingdomId")
                        .HasColumnType("int");

                    b.Property<int>("SellingAmount")
                        .HasColumnType("int");

                    b.Property<string>("SellingType")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("OfferId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("DotNetTribes.Models.Resource", b =>
                {
                    b.Property<int>("ResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("Generation")
                        .HasColumnType("int");

                    b.Property<int>("KingdomId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<long>("UpdatedAt")
                        .HasColumnType("bigint");

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

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<bool>("ConsumingFood")
                        .HasColumnType("bit");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<long>("FinishedAt")
                        .HasColumnType("bigint");

                    b.Property<int>("KingdomId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("StartedAt")
                        .HasColumnType("bigint");

                    b.Property<long>("UpdatedAt")
                        .HasColumnType("bigint");

                    b.HasKey("TroopId");

                    b.HasIndex("KingdomId");

                    b.ToTable("Troops");
                });

            modelBuilder.Entity("DotNetTribes.Models.UniversityUpgrade", b =>
                {
                    b.Property<long>("UniversityUpgradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AddedToKingdom")
                        .HasColumnType("bit");

                    b.Property<double>("EffectStrength")
                        .HasColumnType("float");

                    b.Property<long>("FinishedAt")
                        .HasColumnType("bigint");

                    b.Property<int>("KingdomId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<long>("StartedAt")
                        .HasColumnType("bigint");

                    b.Property<string>("UpgradeType")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("UniversityUpgradeId");

                    b.HasIndex("KingdomId");

                    b.ToTable("UniversityUpgrades");
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
                        .HasForeignKey("KingdomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DotNetTribes.Models.BuildingUpgrade", b =>
                {
                    b.HasOne("DotNetTribes.Models.Kingdom", null)
                        .WithMany("BuildingUpgrade")
                        .HasForeignKey("KingdomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                        .HasForeignKey("KingdomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DotNetTribes.Models.UniversityUpgrade", b =>
                {
                    b.HasOne("DotNetTribes.Models.Kingdom", null)
                        .WithMany("Upgrades")
                        .HasForeignKey("KingdomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

                    b.Navigation("BuildingUpgrade");

                    b.Navigation("Resources");

                    b.Navigation("Troops");

                    b.Navigation("Upgrades");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
