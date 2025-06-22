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
        private static ConfigEntry<bool> _meadBasePoisonResistEnabled;

        public void Awake()
        {
            _modEnabled = Config.Bind("General", "ModEnabled", true, "Enable or disable the mod.");
            _boarJerkyEnabled = Config.Bind("General", "BoarJerky", true,
                "Enable or disable alternative Boar Jerky recipe.");
            _minceMeatSauceEnabled = Config.Bind("General", "MinceMeatSauce", true,
                "Enable or disable alternative Mince Meat Sauce recipe.");
            _sausagesEnabled =
                Config.Bind("General", "Sausages", true, "Enable or disable alternative Sausages recipe.");
            _turnipStewEnabled = Config.Bind("General", "TurnipStew", true,
                "Enable or disable alternative Turnip Stew recipe.");
            _wolfJerkyEnabled = Config.Bind("General", "Wolfjerky", true,
                "Enable or disable alternative Wolf jerky recipe.");
            _wolfMeatSkewerEnabled = Config.Bind("General", "WolfMeatSkewer", true,
                "Enable or disable alternative Wolf Skewer recipe.");
            _meadBasePoisonResistEnabled = Config.Bind("General", "MeadBasePoisonResist", true,
                "Enable or disable alternative Poison Resist Mead recipe.");
            if (_modEnabled.Value)
                AddRecipes();
        }

        private void AddRecipes()
        {
            // Cauldron
            // lvl 1
            if (_boarJerkyEnabled.Value)
                AddRecipe(CraftingStations.Cauldron, 1, "BoarJerky", 2,
                    new[]
                    {
                        new RequirementConfig("CookedMeat", 1, 0, false),
                        new RequirementConfig("Honey", 1, 0, false)
                    });

            if (_minceMeatSauceEnabled.Value)
                AddRecipe(CraftingStations.Cauldron, 1, "MinceMeatSauce", 1,
                    new[]
                    {
                        new RequirementConfig("CookedMeat", 1, 0, false),
                        new RequirementConfig("NeckTailGrilled", 1, 0, false),
                        new RequirementConfig("Carrot", 1, 0, false)
                    });

            // lvl 2
            if (_sausagesEnabled.Value)
                AddRecipe(CraftingStations.Cauldron, 2, "Sausages", 4,
                    new[]
                    {
                        new RequirementConfig("CookedMeat", 4, 0, false),
                        new RequirementConfig("Entrails", 1, 0, false),
                        new RequirementConfig("Thistle", 1, 0, false)
                    });

            if (_turnipStewEnabled.Value)
                AddRecipe(CraftingStations.Cauldron, 2, "TurnipStew", 1,
                    new[]
                    {
                        new RequirementConfig("CookedMeat", 1, 0, false),
                        new RequirementConfig("Turnip", 3, 0, false)
                    });

            // lvl 3
            if (_wolfJerkyEnabled.Value)
                AddRecipe(CraftingStations.Cauldron, 3, "Wolfjerky", 2,
                    new[]
                    {
                        new RequirementConfig("CookedWolfMeat", 1, 0, false),
                        new RequirementConfig("Honey", 1, 0, false)
                    });

            if (_wolfMeatSkewerEnabled.Value)
                AddRecipe(CraftingStations.Cauldron, 3, "WolfMeatSkewer", 1,
                    new[]
                    {
                        new RequirementConfig("CookedWolfMeat", 1, 0, false),
                        new RequirementConfig("Onion", 1, 0, false),
                        new RequirementConfig("Mushroom", 2, 0, false)
                    });

            // MeadKetill
            if (_meadBasePoisonResistEnabled.Value)
                AddRecipe(CraftingStations.MeadKetill, 1, "MeadBasePoisonResist", 1,
                    new[]
                    {
                        new RequirementConfig("Honey", 10, 0, false),
                        new RequirementConfig("Thistle", 5, 0, false),
                        new RequirementConfig("NeckTailGrilled", 1, 0, false),
                        new RequirementConfig("Coal", 10, 0, false)
                    });
        }

        private void AddRecipe(string station, int level, string item, int amount,
            RequirementConfig[] requirements)
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