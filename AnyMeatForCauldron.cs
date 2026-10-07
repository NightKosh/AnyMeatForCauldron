using System.Collections.Generic;
using BepInEx;
using BepInEx.Configuration;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;

namespace AnyMeatForCauldron
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class AnyMeatForCauldron : BaseUnityPlugin
    {
        private const string PluginGuid = "nightkosh." + PluginName;
        private const string PluginName = "AnyMeatForCauldron";
        private const string PluginVersion = "1.0.0";
        private static ConfigEntry<bool> _modEnabled;
        private static ConfigEntry<bool> _boarJerkyEnabled;
        private static ConfigEntry<bool> _minceMeatSauceEnabled;
        private static ConfigEntry<bool> _sausagesEnabled;
        private static ConfigEntry<bool> _turnipStewEnabled;
        private static ConfigEntry<bool> _wolfJerkyEnabled;
        private static ConfigEntry<bool> _wolfMeatSkewerEnabled;
        private static ConfigEntry<bool> _seekerAspicEnabled;
        private static ConfigEntry<bool> _fierySvinstewEnabled;
        private static ConfigEntry<bool> _mashedMeatEnabled;
        
        private static ConfigEntry<bool> _loxPieUncookedEnabled;
        private static ConfigEntry<bool> _meatPlatterUncookedEnabled;
        private static ConfigEntry<bool> _misthareSupremeUncookedEnabled;
        private static ConfigEntry<bool> _honeyGlazedChickenUncookedEnabled;
        private static ConfigEntry<bool> _piquantPieUncookedEnabled;
        
        private static ConfigEntry<bool> _meadBasePoisonResistEnabled;

        public void Awake()
        {
            _modEnabled = Config.Bind("General", "ModEnabled", true, "Enable or disable the mod.");
            // Cauldron
            _boarJerkyEnabled = Config.Bind("General", "BoarJerky", true,
                "Enable or disable Cauldron lvl 1 alternative Boar Jerky recipe.");
            _minceMeatSauceEnabled = Config.Bind("General", "MinceMeatSauce", true,
                "Enable or disable Cauldron lvl 1 alternative Mince Meat Sauce recipe.");
            _sausagesEnabled = Config.Bind("General", "Sausages", true, 
                    "Enable or disable Cauldron lvl 2 alternative Sausages recipe.");
            _turnipStewEnabled = Config.Bind("General", "TurnipStew", true,
                "Enable or disable Cauldron lvl 2 alternative Turnip Stew recipe.");
            _wolfJerkyEnabled = Config.Bind("General", "Wolfjerky", true,
                "Enable or disable Cauldron lvl 3 alternative Wolf jerky recipe.");
            _wolfMeatSkewerEnabled = Config.Bind("General", "WolfMeatSkewer", true,
                "Enable or disable Cauldron lvl 3 alternative Wolf Skewer recipe.");
            _seekerAspicEnabled = Config.Bind("General", "SeekerAspic", true,
                "Enable or disable Cauldron lvl 5 alternative Seeker Aspic recipe.");
            _fierySvinstewEnabled = Config.Bind("General", "FierySvinstew", true,
                "Enable or disable Cauldron lvl 5 alternative Fiery Svinstew recipe.");
            _mashedMeatEnabled = Config.Bind("General", "MashedMeat", true,
                "Enable or disable Cauldron lvl 6 alternative Mashed Meat recipe.");
            
            // Food preparation table
            _loxPieUncookedEnabled = Config.Bind("General", "LoxPieUncooked", true,
                "Enable or disable Food preparation table alternative Unbaked Lox Pie recipe.");
            _meatPlatterUncookedEnabled = Config.Bind("General", "MeatPlatterUncooked", true,
                "Enable or disable Food preparation table alternative Uncooked meat platter recipe.");
            _misthareSupremeUncookedEnabled = Config.Bind("General", "MisthareSupremeUncooked", true,
                "Enable or disable Food preparation table alternative Uncooked misthare supreme recipe.");
            _honeyGlazedChickenUncookedEnabled = Config.Bind("General", "HoneyGlazedChickenUncooked", true,
                "Enable or disable Food preparation table alternative Uncooked honey glazed chicken recipe.");
            _piquantPieUncookedEnabled = Config.Bind("General", "PiquantPieUncooked", true,
                "Enable or disable Food preparation table alternative Uncooked Piquant Pie recipe.");
            
            // mead
            _meadBasePoisonResistEnabled = Config.Bind("General", "MeadBasePoisonResist", true,
                "Enable or disable mead alternative Poison Resist Mead recipe.");
            if (_modEnabled.Value)
            {
                AddRecipes();
            }
        }

        private void AddRecipes()
        {
            // Cauldron
            // lvl 1
            if (_boarJerkyEnabled.Value)
            {
                AddRecipe(CraftingStations.Cauldron, 1, "BoarJerky", 2,
                    new[]
                    {
                        new RequirementConfig("CookedMeat", 1, 0, false),
                        new RequirementConfig("Honey", 1, 0, false)
                    });
            }

            if (_minceMeatSauceEnabled.Value)
            {
                AddRecipe(CraftingStations.Cauldron, 1, "MinceMeatSauce", 1,
                    new[]
                    {
                        new RequirementConfig("CookedMeat", 1, 0, false),
                        new RequirementConfig("NeckTailGrilled", 1, 0, false),
                        new RequirementConfig("Carrot", 1, 0, false)
                    });
            }

            // lvl 2
            if (_sausagesEnabled.Value)
            {
                AddRecipe(CraftingStations.Cauldron, 2, "Sausages", 4,
                    new[]
                    {
                        new RequirementConfig("Entrails", 4, 0, false),
                        new RequirementConfig("CookedMeat", 1, 0, false),
                        new RequirementConfig("Thistle", 1, 0, false)
                    });
            }

            if (_turnipStewEnabled.Value)
            {
                AddRecipe(CraftingStations.Cauldron, 2, "TurnipStew", 1,
                    new[]
                    {
                        new RequirementConfig("CookedMeat", 1, 0, false),
                        new RequirementConfig("Turnip", 3, 0, false)
                    });
            }

            // lvl 3
            if (_wolfJerkyEnabled.Value)
            {
                AddRecipe(CraftingStations.Cauldron, 3, "WolfJerky", 2,
                    new[]
                    {
                        new RequirementConfig("CookedWolfMeat", 1, 0, false),
                        new RequirementConfig("Honey", 1, 0, false)
                    });
            }

            if (_wolfMeatSkewerEnabled.Value)
            {
                AddRecipe(CraftingStations.Cauldron, 3, "WolfMeatSkewer", 1,
                    new[]
                    {
                        new RequirementConfig("CookedWolfMeat", 1, 0, false),
                        new RequirementConfig("Onion", 1, 0, false),
                        new RequirementConfig("Mushroom", 2, 0, false)
                    });
            }

            // lvl 4
            // no recipes
            
            // lvl 5
            if (_seekerAspicEnabled.Value)
            {
                AddRecipe(CraftingStations.Cauldron, 5, "SeekerAspic", 2,
                    new[]
                    {
                        new RequirementConfig("CookedBugMeat", 2, 0, false),
                        new RequirementConfig("MushroomMagecap", 2, 0, false),
                        new RequirementConfig("RoyalJelly", 2, 0, false)
                    });
            }
            
            if (_fierySvinstewEnabled.Value)
            {
                AddRecipe(CraftingStations.Cauldron, 5, "FierySvinstew", 1,
                    new[]
                    {
                        new RequirementConfig("CookedAsksvinMeat", 1, 0, false),
                        new RequirementConfig("Vineberry", 2, 0, false),
                        new RequirementConfig("MushroomSmokePuff", 1, 0, false)
                    });
            }
            
            // lvl 6
            if (_mashedMeatEnabled.Value)
            {
                AddRecipe(CraftingStations.Cauldron, 6, "MashedMeat", 1,
                    new[]
                    {
                        new RequirementConfig("CookedAsksvinMeat", 1, 0, false),
                        new RequirementConfig("CookedVoltureMeat", 1, 0, false),
                        new RequirementConfig("Fiddleheadfern", 1, 0, false)
                    });
            }

            // Food preparation table
            if (_loxPieUncookedEnabled.Value)
            {
                AddRecipe(CraftingStations.FoodPreparationTable, 1, "LoxPieUncooked", 1,
                    new[]
                    {
                        new RequirementConfig("Cloudberry", 2, 0, false),
                        new RequirementConfig("CookedLoxMeat", 2, 0, false),
                        new RequirementConfig("BarleyFlour", 4, 0, false)
                    });
            }
            
            if (_meatPlatterUncookedEnabled.Value)
            {
                AddRecipe(CraftingStations.FoodPreparationTable, 1, "MeatPlatterUncooked", 1,
                    new[]
                    {
                        new RequirementConfig("CookedBugMeat", 1, 0, false),
                        new RequirementConfig("CookedLoxMeat", 1, 0, false),
                        new RequirementConfig("CookedHareMeat", 1, 0, false)
                    });
            }
            
            if (_misthareSupremeUncookedEnabled.Value)
            {
                AddRecipe(CraftingStations.FoodPreparationTable, 1, "MisthareSupremeUncooked", 1,
                    new[]
                    {
                        new RequirementConfig("CookedHareMeat", 1, 0, false),
                        new RequirementConfig("MushroomJotunPuffs", 3, 0, false),
                        new RequirementConfig("Carrot", 2, 0, false)
                    });
            }
            
            if (_honeyGlazedChickenUncookedEnabled.Value)
            {
                AddRecipe(CraftingStations.FoodPreparationTable, 1, "HoneyGlazedChickenUncooked", 1,
                    new[]
                    {
                        new RequirementConfig("CookedChickenMeat", 1, 0, false),
                        new RequirementConfig("Honey", 3, 0, false),
                        new RequirementConfig("MushroomJotunPuffs", 2, 0, false)
                    });
            }
            
            if (_piquantPieUncookedEnabled.Value)
            {
                AddRecipe(CraftingStations.FoodPreparationTable, 1, "PiquantPieUncooked", 1,
                    new[]
                    {
                        new RequirementConfig("Vineberry", 2, 0, false),
                        new RequirementConfig("CookedAsksvinMeat", 2, 0, false),
                        new RequirementConfig("BarleyFlour", 4, 0, false)
                    });
            }
            
            // MeadKetill
            if (_meadBasePoisonResistEnabled.Value)
            {
                AddRecipe(CraftingStations.MeadKetill, 1, "MeadBasePoisonResist", 1,
                    new[]
                    {
                        new RequirementConfig("Honey", 10, 0, false),
                        new RequirementConfig("Thistle", 5, 0, false),
                        new RequirementConfig("NeckTailGrilled", 1, 0, false),
                        new RequirementConfig("Coal", 10, 0, false)
                    });
            }
        }

        private void AddRecipe(string station, int level, string item, int amount, RequirementConfig[] requirements)
        {
            var recipeNewConfig = new RecipeConfig();
            recipeNewConfig.Item = item;
            recipeNewConfig.Name = "Recipe_" + item;
            recipeNewConfig.Amount = amount;
            recipeNewConfig.CraftingStation = station;
            recipeNewConfig.MinStationLevel = level;
            foreach (var requirementConfig in requirements) recipeNewConfig.AddRequirement(requirementConfig);
            ItemManager.Instance.AddRecipe(new CustomRecipe(recipeNewConfig));
        }
        
    }
    
}
