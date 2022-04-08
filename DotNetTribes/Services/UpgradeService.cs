using System.Linq;
using DotNetTribes.DTOs;
using DotNetTribes.Enums;
using DotNetTribes.Exceptions;
using DotNetTribes.Models;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;

namespace DotNetTribes.Services
{
    public class UpgradeService : IUpgradeService
    {
        private readonly ApplicationContext _applicationContext;
        private readonly IRulesService _rules;
        private readonly ITimeService _timeService;


        public UpgradeService(ApplicationContext applicationContext, IRulesService rules, ITimeService timeService)
        {
            _applicationContext = applicationContext;
            _rules = rules;
            _timeService = timeService;
        }

        public UniversityUpgrade BuyUniversityUpgrade(int kingdomId, UpgradeType upgradeType)
        {
            Kingdom kingdom = _applicationContext.Kingdoms
                .Include(k => k.Resources)
                .Include(k => k.Buildings)
                .Include(k => k.Upgrades)
                .Single(k => k.KingdomId == kingdomId);
            
            var hasUniversity = kingdom.Buildings.FirstOrDefault(b => b.Type == BuildingType.University);
            if (hasUniversity == null)
            {
                throw new UpgradeException("You don't have a University");
            }

            UniversityUpgrade theUpgrade = null;
            
            if (upgradeType == UpgradeType.BuildingBuildSpeed)
            {
                int currentLvl = 0;
                var currentLvlUpgrade = kingdom.Upgrades.FirstOrDefault(u => u.UpgradeType == upgradeType);
                if (currentLvlUpgrade != null)
                {
                    currentLvl = currentLvlUpgrade.Level + 1;
                }
                int resourcesNeeded = _rules.BuildingBuildSpeedPrice(currentLvl);
                long researchTime = _rules.BuildingBuildSpeedTime(currentLvl) - GetUniversityLevelTimeReduction(hasUniversity);
                theUpgrade = StartUpgrdingCheckResources(kingdom, hasUniversity, upgradeType, 0.05, resourcesNeeded, currentLvl, researchTime);
                

            }
            if (upgradeType == UpgradeType.FarmProduceBonus)
            {
                int currentLvl = 0;
                var currentLvlUpgrade = kingdom.Upgrades.FirstOrDefault(u => u.UpgradeType == upgradeType);
                if (currentLvlUpgrade != null)
                {
                    currentLvl = currentLvlUpgrade.Level + 1;
                }
                int resourcesNeeded = _rules.FarmProduceBonusPrice(currentLvl);
                long researchTime = _rules.FarmProduceBonusTime(currentLvl) - GetUniversityLevelTimeReduction(hasUniversity);
                theUpgrade = StartUpgrdingCheckResources(kingdom, hasUniversity, upgradeType, 0.05, resourcesNeeded, currentLvl, researchTime);
            }
            if (upgradeType == UpgradeType.MineProduceBonus)
            {
                int currentLvl = 0;
                var currentLvlUpgrade = kingdom.Upgrades.FirstOrDefault(u => u.UpgradeType == upgradeType);
                if (currentLvlUpgrade != null)
                {
                    currentLvl = currentLvlUpgrade.Level + 1;
                }
                int resourcesNeeded = _rules.MineProduceBonusPrice(currentLvl);
                long researchTime = _rules.MineProduceBonusTime(currentLvl) - GetUniversityLevelTimeReduction(hasUniversity);
                theUpgrade = StartUpgrdingCheckResources(kingdom, hasUniversity, upgradeType, 0.05, resourcesNeeded, currentLvl, researchTime);
            }
            if (upgradeType == UpgradeType.TroopsTrainSpeed)
            {
                int currentLvl = 0;
                var currentLvlUpgrade = kingdom.Upgrades.FirstOrDefault(u => u.UpgradeType == upgradeType);
                if (currentLvlUpgrade != null)
                {
                    currentLvl = currentLvlUpgrade.Level + 1;
                }
                int resourcesNeeded = _rules.TroopsTrainSpeedPrice(currentLvl);
                long researchTime = _rules.TroopsTrainSpeedTime(currentLvl) - GetUniversityLevelTimeReduction(hasUniversity);
                theUpgrade = StartUpgrdingCheckResources(kingdom, hasUniversity, upgradeType, 0.05, resourcesNeeded, currentLvl, researchTime);
            }
            if (upgradeType == UpgradeType.AllTroopsAtkBonus)
            {
                int currentLvl = 0;
                var currentLvlUpgrade = kingdom.Upgrades.FirstOrDefault(u => u.UpgradeType == upgradeType);
                if (currentLvlUpgrade != null)
                {
                    currentLvl = currentLvlUpgrade.Level + 1;
                }
                int resourcesNeeded = _rules.AllTroopsAtkBonusPrice(currentLvl);
                long researchTime = _rules.AllTroopsAtkBonusTime(currentLvl) - GetUniversityLevelTimeReduction(hasUniversity);
                theUpgrade = StartUpgrdingCheckResources(kingdom, hasUniversity, upgradeType, 0.05, resourcesNeeded, currentLvl, researchTime);
            }
            if (upgradeType == UpgradeType.AllTroopsDefBonus)
            {
                int currentLvl = 0;
                var currentLvlUpgrade = kingdom.Upgrades.FirstOrDefault(u => u.UpgradeType == upgradeType);
                if (currentLvlUpgrade != null)
                {
                    currentLvl = currentLvlUpgrade.Level + 1;
                }
                int resourcesNeeded = _rules.AllTroopsDefBonusPrice(currentLvl);
                long researchTime = _rules.AllTroopsDefBonusTime(currentLvl) - GetUniversityLevelTimeReduction(hasUniversity);
                theUpgrade = StartUpgrdingCheckResources(kingdom, hasUniversity, upgradeType, 0.05, resourcesNeeded, currentLvl, researchTime);
            }

            _applicationContext.SaveChanges();
            return theUpgrade;
        }

        private UniversityUpgrade StartUpgrdingCheckResources(Kingdom kingdom, Building hasUniversity, UpgradeType upgradeType, double affectStrength, int resourcesNeeded, int upgradeTotLvl, long researchTime)
        {
            if (upgradeTotLvl == 0)
            {
                bool enoughResources = CheckResourcesForUpgrade(upgradeTotLvl, kingdom, resourcesNeeded);
                return new UniversityUpgrade()
                {
                    UpgradeType = upgradeType,
                    AffectStrength = affectStrength,
                    Level = 0,
                    KingdomId = kingdom.KingdomId,
                    StartedAt = _timeService.GetCurrentSeconds(),
                    FinishedAt = _timeService.GetCurrentSeconds() + researchTime,
                    AddedToKingdom = false
                };
            }
            if (upgradeTotLvl is < 6 and > 0)
            {
                bool enoughResources = CheckResourcesForUpgrade(upgradeTotLvl, kingdom, resourcesNeeded);
                var existingUpgrade = kingdom.Upgrades.FirstOrDefault(u => u.UpgradeType == upgradeType);
                existingUpgrade.StartedAt = _timeService.GetCurrentSeconds();
                existingUpgrade.FinishedAt = _timeService.GetCurrentSeconds() + researchTime;
                existingUpgrade.AddedToKingdom = false;
                return existingUpgrade;
            }
            else
            {
                throw new UpgradeException($"You have max level of {upgradeType}");
            }
        }

        private bool CheckResourcesForUpgrade(int upgradeToLvl, Kingdom kingdom, int resourcesNeeded)
        {
            if (kingdom.Resources.FirstOrDefault(r => r.Type == ResourceType.Food)!.Amount > resourcesNeeded && 
                kingdom.Resources.FirstOrDefault(r => r.Type == ResourceType.Gold)!.Amount > resourcesNeeded)
            {
                Resource food = kingdom.Resources.FirstOrDefault(r => r.Type == ResourceType.Food);
                food.Amount -= resourcesNeeded;
                Resource gold = kingdom.Resources.FirstOrDefault(r => r.Type == ResourceType.Gold);
                gold.Amount -= resourcesNeeded;
            }
            else
            {
                throw new UpgradeException("Not enough resources");
            }

            return true;
        }

        private long GetUniversityLevelTimeReduction(Building hasUniversity)
        {
            if (hasUniversity.Level == 1)
            {
                return 0;
            }
            return hasUniversity.Level * 1; //have to change after testing
        }
    }
}