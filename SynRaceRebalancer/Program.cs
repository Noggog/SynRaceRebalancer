using System;
using System.Collections.Generic;
using System.Linq;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;
using System.Threading.Tasks;
using SynRaceRebalancer.Settings;
using SynRaceRebalancer.Utils;
using SynRaceRebalancer.Builders;
using Mutagen.Bethesda.FormKeys.SkyrimSE;

namespace SynRaceRebalancer
{
    public class Program
    {
        static Lazy<SettingsGlobal> _SettingsGlobal = null!;
        static SettingsGlobal SettingsGlobal => _SettingsGlobal.Value;

        static Lazy<SettingsPlayableRaces> _SettingsPlayableRaces = null!;
        static SettingsPlayableRaces SettingsPlayable => _SettingsPlayableRaces.Value;

        //static Lazy<SettingsAnimals> _SettingsAnimals = null!;
        //static SettingsAnimals SettingsAnimals => _SettingsAnimals.Value;

        static Lazy<SettingsCreatures> _SettingsCreatures = null!;
        static SettingsCreatures SettingsCreatures => _SettingsCreatures.Value;

        static Lazy<SettingsMechanical> _SettingsMechanical = null!;
        static SettingsMechanical SettingsMechanical => _SettingsMechanical.Value;

        static Lazy<SettingsMonsters> _SettingsMonsters = null!;
        public static SettingsMonsters SettingsMonsters => _SettingsMonsters.Value;

        public static async Task<int> Main(string[] args)
        {
            return await SynthesisPipeline.Instance
                .AddPatch<ISkyrimMod, ISkyrimModGetter>(RunPatch)
                .SetAutogeneratedSettings("Global Settings", "SettingsGlobal.json", out _SettingsGlobal)
                .SetAutogeneratedSettings("Playable Race Scaling", "SettingsPlayableRaces.json", out _SettingsPlayableRaces)
                //.SetAutogeneratedSettings("Animal Scaling", "SettingsAnimals.json", out _SettingsAnimals)
                .SetAutogeneratedSettings("Creature Scaling", "SettingsCreatures.json", out _SettingsCreatures)
                .SetAutogeneratedSettings("Mechanical Scaling", "SettingsMechanical.json", out _SettingsMechanical)
                .SetAutogeneratedSettings("Monster Scaling", "SettingsMonsters.json", out _SettingsMonsters)
                .SetTypicalOpen(GameRelease.SkyrimSE, "SynRaceRescaler.esp")
                .Run(args);
        }

        public class RacesToModify
        {
            public static List<RaceObject> PlayableRaceList = new List<RaceObject>(new RaceObject[] {
            new RaceObject(SettingsPlayable.Altmer.editorID, SettingsPlayable.Altmer.newName, SettingsPlayable.Altmer.aliases, SettingsPlayable.Altmer.targetKeywords,
                SettingsPlayable.Altmer.attributeHealth, SettingsPlayable.Altmer.attributeMagicka, SettingsPlayable.Altmer.attributeStamina,
                SettingsPlayable.Altmer.baseCarryWeight, SettingsPlayable.Altmer.baseMass,
                SettingsPlayable.Altmer.accelerationRate, SettingsPlayable.Altmer.decelerationRate,
                SettingsPlayable.Altmer.attributeHealthRegen, SettingsPlayable.Altmer.attributeMagickaRegen, SettingsPlayable.Altmer.attributeStaminaRegen,
                SettingsPlayable.Altmer.unarmedDamage, SettingsPlayable.Altmer.unarmedReach,
                SettingsPlayable.Altmer.canSwim, SettingsPlayable.Altmer.regenCombatHP,
                SettingsPlayable.Altmer.flagsToAdd, SettingsPlayable.Altmer.flagsToRemove,

                SettingsPlayable.Altmer.Skills.Skill0, SettingsPlayable.Altmer.Skills.Skill0Boost,
                SettingsPlayable.Altmer.Skills.Skill1, SettingsPlayable.Altmer.Skills.Skill1Boost,
                SettingsPlayable.Altmer.Skills.Skill2, SettingsPlayable.Altmer.Skills.Skill2Boost,
                SettingsPlayable.Altmer.Skills.Skill3, SettingsPlayable.Altmer.Skills.Skill3Boost,
                SettingsPlayable.Altmer.Skills.Skill4, SettingsPlayable.Altmer.Skills.Skill4Boost,
                SettingsPlayable.Altmer.Skills.Skill5, SettingsPlayable.Altmer.Skills.Skill5Boost,
                SettingsPlayable.Altmer.Skills.Skill6, SettingsPlayable.Altmer.Skills.Skill6Boost),
            new RaceObject(SettingsPlayable.Argonian.editorID, SettingsPlayable.Argonian.newName, SettingsPlayable.Argonian.aliases, SettingsPlayable.Argonian.targetKeywords,
                SettingsPlayable.Argonian.attributeHealth, SettingsPlayable.Argonian.attributeMagicka, SettingsPlayable.Argonian.attributeStamina,
                SettingsPlayable.Argonian.baseCarryWeight, SettingsPlayable.Argonian.baseMass,
                SettingsPlayable.Argonian.accelerationRate, SettingsPlayable.Argonian.decelerationRate,
                SettingsPlayable.Argonian.attributeHealthRegen, SettingsPlayable.Argonian.attributeMagickaRegen, SettingsPlayable.Argonian.attributeStaminaRegen,
                SettingsPlayable.Argonian.unarmedDamage, SettingsPlayable.Argonian.unarmedReach,
                SettingsPlayable.Argonian.canSwim, SettingsPlayable.Argonian.regenCombatHP,
                SettingsPlayable.Argonian.flagsToAdd, SettingsPlayable.Argonian.flagsToRemove,

                SettingsPlayable.Argonian.Skills.Skill0, SettingsPlayable.Argonian.Skills.Skill0Boost,
                SettingsPlayable.Argonian.Skills.Skill1, SettingsPlayable.Argonian.Skills.Skill1Boost,
                SettingsPlayable.Argonian.Skills.Skill2, SettingsPlayable.Argonian.Skills.Skill2Boost,
                SettingsPlayable.Argonian.Skills.Skill3, SettingsPlayable.Argonian.Skills.Skill3Boost,
                SettingsPlayable.Argonian.Skills.Skill4, SettingsPlayable.Argonian.Skills.Skill4Boost,
                SettingsPlayable.Argonian.Skills.Skill5, SettingsPlayable.Argonian.Skills.Skill5Boost,
                SettingsPlayable.Argonian.Skills.Skill6, SettingsPlayable.Argonian.Skills.Skill6Boost),
            new RaceObject(SettingsPlayable.Bosmer.editorID, SettingsPlayable.Bosmer.newName, SettingsPlayable.Bosmer.aliases, SettingsPlayable.Bosmer.targetKeywords,
                SettingsPlayable.Bosmer.attributeHealth, SettingsPlayable.Bosmer.attributeMagicka, SettingsPlayable.Bosmer.attributeStamina,
                SettingsPlayable.Bosmer.baseCarryWeight, SettingsPlayable.Bosmer.baseMass,
                SettingsPlayable.Bosmer.accelerationRate, SettingsPlayable.Bosmer.decelerationRate,
                SettingsPlayable.Bosmer.attributeHealthRegen, SettingsPlayable.Bosmer.attributeMagickaRegen, SettingsPlayable.Bosmer.attributeStaminaRegen,
                SettingsPlayable.Bosmer.unarmedDamage, SettingsPlayable.Bosmer.unarmedReach,
                SettingsPlayable.Bosmer.canSwim, SettingsPlayable.Bosmer.regenCombatHP,
                SettingsPlayable.Bosmer.flagsToAdd, SettingsPlayable.Bosmer.flagsToRemove,

                SettingsPlayable.Bosmer.Skills.Skill0, SettingsPlayable.Bosmer.Skills.Skill0Boost,
                SettingsPlayable.Bosmer.Skills.Skill1, SettingsPlayable.Bosmer.Skills.Skill1Boost,
                SettingsPlayable.Bosmer.Skills.Skill2, SettingsPlayable.Bosmer.Skills.Skill2Boost,
                SettingsPlayable.Bosmer.Skills.Skill3, SettingsPlayable.Bosmer.Skills.Skill3Boost,
                SettingsPlayable.Bosmer.Skills.Skill4, SettingsPlayable.Bosmer.Skills.Skill4Boost,
                SettingsPlayable.Bosmer.Skills.Skill5, SettingsPlayable.Bosmer.Skills.Skill5Boost,
                SettingsPlayable.Bosmer.Skills.Skill6, SettingsPlayable.Bosmer.Skills.Skill6Boost),
            new RaceObject(SettingsPlayable.Breton.editorID, SettingsPlayable.Breton.newName, SettingsPlayable.Breton.aliases, SettingsPlayable.Breton.targetKeywords,
                SettingsPlayable.Breton.attributeHealth, SettingsPlayable.Breton.attributeMagicka, SettingsPlayable.Breton.attributeStamina,
                SettingsPlayable.Breton.baseCarryWeight, SettingsPlayable.Breton.baseMass,
                SettingsPlayable.Breton.accelerationRate, SettingsPlayable.Breton.decelerationRate,
                SettingsPlayable.Breton.attributeHealthRegen, SettingsPlayable.Breton.attributeMagickaRegen, SettingsPlayable.Breton.attributeStaminaRegen,
                SettingsPlayable.Breton.unarmedDamage, SettingsPlayable.Breton.unarmedReach,
                SettingsPlayable.Breton.canSwim, SettingsPlayable.Breton.regenCombatHP,
                SettingsPlayable.Breton.flagsToAdd, SettingsPlayable.Breton.flagsToRemove,

                SettingsPlayable.Breton.Skills.Skill0, SettingsPlayable.Breton.Skills.Skill0Boost,
                SettingsPlayable.Breton.Skills.Skill1, SettingsPlayable.Breton.Skills.Skill1Boost,
                SettingsPlayable.Breton.Skills.Skill2, SettingsPlayable.Breton.Skills.Skill2Boost,
                SettingsPlayable.Breton.Skills.Skill3, SettingsPlayable.Breton.Skills.Skill3Boost,
                SettingsPlayable.Breton.Skills.Skill4, SettingsPlayable.Breton.Skills.Skill4Boost,
                SettingsPlayable.Breton.Skills.Skill5, SettingsPlayable.Breton.Skills.Skill5Boost,
                SettingsPlayable.Breton.Skills.Skill6, SettingsPlayable.Breton.Skills.Skill6Boost),
            new RaceObject(SettingsPlayable.Cyrodiil.editorID, SettingsPlayable.Cyrodiil.newName, SettingsPlayable.Cyrodiil.aliases, SettingsPlayable.Cyrodiil.targetKeywords,
                SettingsPlayable.Cyrodiil.attributeHealth, SettingsPlayable.Cyrodiil.attributeMagicka, SettingsPlayable.Cyrodiil.attributeStamina,
                SettingsPlayable.Cyrodiil.baseCarryWeight, SettingsPlayable.Cyrodiil.baseMass,
                SettingsPlayable.Cyrodiil.accelerationRate, SettingsPlayable.Cyrodiil.decelerationRate,
                SettingsPlayable.Cyrodiil.attributeHealthRegen, SettingsPlayable.Cyrodiil.attributeMagickaRegen, SettingsPlayable.Cyrodiil.attributeStaminaRegen,
                SettingsPlayable.Cyrodiil.unarmedDamage, SettingsPlayable.Cyrodiil.unarmedReach,
                SettingsPlayable.Cyrodiil.canSwim, SettingsPlayable.Cyrodiil.regenCombatHP,
                SettingsPlayable.Cyrodiil.flagsToAdd, SettingsPlayable.Cyrodiil.flagsToRemove,

                SettingsPlayable.Cyrodiil.Skills.Skill0, SettingsPlayable.Cyrodiil.Skills.Skill0Boost,
                SettingsPlayable.Cyrodiil.Skills.Skill1, SettingsPlayable.Cyrodiil.Skills.Skill1Boost,
                SettingsPlayable.Cyrodiil.Skills.Skill2, SettingsPlayable.Cyrodiil.Skills.Skill2Boost,
                SettingsPlayable.Cyrodiil.Skills.Skill3, SettingsPlayable.Cyrodiil.Skills.Skill3Boost,
                SettingsPlayable.Cyrodiil.Skills.Skill4, SettingsPlayable.Cyrodiil.Skills.Skill4Boost,
                SettingsPlayable.Cyrodiil.Skills.Skill5, SettingsPlayable.Cyrodiil.Skills.Skill5Boost,
                SettingsPlayable.Cyrodiil.Skills.Skill6, SettingsPlayable.Cyrodiil.Skills.Skill6Boost),
            new RaceObject(SettingsPlayable.Dunmer.editorID, SettingsPlayable.Dunmer.newName, SettingsPlayable.Dunmer.aliases, SettingsPlayable.Dunmer.targetKeywords,
                SettingsPlayable.Dunmer.attributeHealth, SettingsPlayable.Dunmer.attributeMagicka, SettingsPlayable.Dunmer.attributeStamina,
                SettingsPlayable.Dunmer.baseCarryWeight, SettingsPlayable.Dunmer.baseMass,
                SettingsPlayable.Dunmer.accelerationRate, SettingsPlayable.Dunmer.decelerationRate,
                SettingsPlayable.Dunmer.attributeHealthRegen, SettingsPlayable.Dunmer.attributeMagickaRegen, SettingsPlayable.Dunmer.attributeStaminaRegen,
                SettingsPlayable.Dunmer.unarmedDamage, SettingsPlayable.Dunmer.unarmedReach,
                SettingsPlayable.Dunmer.canSwim, SettingsPlayable.Dunmer.regenCombatHP,
                SettingsPlayable.Dunmer.flagsToAdd, SettingsPlayable.Dunmer.flagsToRemove,

                SettingsPlayable.Dunmer.Skills.Skill0, SettingsPlayable.Dunmer.Skills.Skill0Boost,
                SettingsPlayable.Dunmer.Skills.Skill1, SettingsPlayable.Dunmer.Skills.Skill1Boost,
                SettingsPlayable.Dunmer.Skills.Skill2, SettingsPlayable.Dunmer.Skills.Skill2Boost,
                SettingsPlayable.Dunmer.Skills.Skill3, SettingsPlayable.Dunmer.Skills.Skill3Boost,
                SettingsPlayable.Dunmer.Skills.Skill4, SettingsPlayable.Dunmer.Skills.Skill4Boost,
                SettingsPlayable.Dunmer.Skills.Skill5, SettingsPlayable.Dunmer.Skills.Skill5Boost,
                SettingsPlayable.Dunmer.Skills.Skill6, SettingsPlayable.Dunmer.Skills.Skill6Boost),
            new RaceObject(SettingsPlayable.Khajiit.editorID, SettingsPlayable.Khajiit.newName, SettingsPlayable.Khajiit.aliases, SettingsPlayable.Khajiit.targetKeywords,
                SettingsPlayable.Khajiit.attributeHealth, SettingsPlayable.Khajiit.attributeMagicka, SettingsPlayable.Khajiit.attributeStamina,
                SettingsPlayable.Khajiit.baseCarryWeight, SettingsPlayable.Khajiit.baseMass,
                SettingsPlayable.Khajiit.accelerationRate, SettingsPlayable.Khajiit.decelerationRate,
                SettingsPlayable.Khajiit.attributeHealthRegen, SettingsPlayable.Khajiit.attributeMagickaRegen, SettingsPlayable.Khajiit.attributeStaminaRegen,
                SettingsPlayable.Khajiit.unarmedDamage, SettingsPlayable.Khajiit.unarmedReach,
                SettingsPlayable.Khajiit.canSwim, SettingsPlayable.Khajiit.regenCombatHP,
                SettingsPlayable.Khajiit.flagsToAdd, SettingsPlayable.Khajiit.flagsToRemove,

                SettingsPlayable.Khajiit.Skills.Skill0, SettingsPlayable.Khajiit.Skills.Skill0Boost,
                SettingsPlayable.Khajiit.Skills.Skill1, SettingsPlayable.Khajiit.Skills.Skill1Boost,
                SettingsPlayable.Khajiit.Skills.Skill2, SettingsPlayable.Khajiit.Skills.Skill2Boost,
                SettingsPlayable.Khajiit.Skills.Skill3, SettingsPlayable.Khajiit.Skills.Skill3Boost,
                SettingsPlayable.Khajiit.Skills.Skill4, SettingsPlayable.Khajiit.Skills.Skill4Boost,
                SettingsPlayable.Khajiit.Skills.Skill5, SettingsPlayable.Khajiit.Skills.Skill5Boost,
                SettingsPlayable.Khajiit.Skills.Skill6, SettingsPlayable.Khajiit.Skills.Skill6Boost),
            new RaceObject(SettingsPlayable.Nord.editorID, SettingsPlayable.Nord.newName, SettingsPlayable.Nord.aliases, SettingsPlayable.Nord.targetKeywords,
                SettingsPlayable.Nord.attributeHealth, SettingsPlayable.Nord.attributeMagicka, SettingsPlayable.Nord.attributeStamina,
                SettingsPlayable.Nord.baseCarryWeight, SettingsPlayable.Nord.baseMass,
                SettingsPlayable.Nord.accelerationRate, SettingsPlayable.Nord.decelerationRate,
                SettingsPlayable.Nord.attributeHealthRegen, SettingsPlayable.Nord.attributeMagickaRegen, SettingsPlayable.Nord.attributeStaminaRegen,
                SettingsPlayable.Nord.unarmedDamage, SettingsPlayable.Nord.unarmedReach,
                SettingsPlayable.Nord.canSwim, SettingsPlayable.Nord.regenCombatHP,
                SettingsPlayable.Nord.flagsToAdd, SettingsPlayable.Nord.flagsToRemove,

                SettingsPlayable.Nord.Skills.Skill0, SettingsPlayable.Nord.Skills.Skill0Boost,
                SettingsPlayable.Nord.Skills.Skill1, SettingsPlayable.Nord.Skills.Skill1Boost,
                SettingsPlayable.Nord.Skills.Skill2, SettingsPlayable.Nord.Skills.Skill2Boost,
                SettingsPlayable.Nord.Skills.Skill3, SettingsPlayable.Nord.Skills.Skill3Boost,
                SettingsPlayable.Nord.Skills.Skill4, SettingsPlayable.Nord.Skills.Skill4Boost,
                SettingsPlayable.Nord.Skills.Skill5, SettingsPlayable.Nord.Skills.Skill5Boost,
                SettingsPlayable.Nord.Skills.Skill6, SettingsPlayable.Nord.Skills.Skill6Boost),
            new RaceObject(SettingsPlayable.Orsimer.editorID, SettingsPlayable.Orsimer.newName, SettingsPlayable.Orsimer.aliases, SettingsPlayable.Orsimer.targetKeywords,
                SettingsPlayable.Orsimer.attributeHealth, SettingsPlayable.Orsimer.attributeMagicka, SettingsPlayable.Orsimer.attributeStamina,
                SettingsPlayable.Orsimer.baseCarryWeight, SettingsPlayable.Orsimer.baseMass,
                SettingsPlayable.Orsimer.accelerationRate, SettingsPlayable.Orsimer.decelerationRate,
                SettingsPlayable.Orsimer.attributeHealthRegen, SettingsPlayable.Orsimer.attributeMagickaRegen, SettingsPlayable.Orsimer.attributeStaminaRegen,
                SettingsPlayable.Orsimer.unarmedDamage, SettingsPlayable.Orsimer.unarmedReach,
                SettingsPlayable.Orsimer.canSwim, SettingsPlayable.Orsimer.regenCombatHP,
                SettingsPlayable.Orsimer.flagsToAdd, SettingsPlayable.Orsimer.flagsToRemove,

                SettingsPlayable.Orsimer.Skills.Skill0, SettingsPlayable.Orsimer.Skills.Skill0Boost,
                SettingsPlayable.Orsimer.Skills.Skill1, SettingsPlayable.Orsimer.Skills.Skill1Boost,
                SettingsPlayable.Orsimer.Skills.Skill2, SettingsPlayable.Orsimer.Skills.Skill2Boost,
                SettingsPlayable.Orsimer.Skills.Skill3, SettingsPlayable.Orsimer.Skills.Skill3Boost,
                SettingsPlayable.Orsimer.Skills.Skill4, SettingsPlayable.Orsimer.Skills.Skill4Boost,
                SettingsPlayable.Orsimer.Skills.Skill5, SettingsPlayable.Orsimer.Skills.Skill5Boost,
                SettingsPlayable.Orsimer.Skills.Skill6, SettingsPlayable.Orsimer.Skills.Skill6Boost),
            new RaceObject(SettingsPlayable.Redguard.editorID, SettingsPlayable.Redguard.newName, SettingsPlayable.Redguard.aliases, SettingsPlayable.Redguard.targetKeywords,
                SettingsPlayable.Redguard.attributeHealth, SettingsPlayable.Redguard.attributeMagicka, SettingsPlayable.Redguard.attributeStamina,
                SettingsPlayable.Redguard.baseCarryWeight, SettingsPlayable.Redguard.baseMass,
                SettingsPlayable.Redguard.accelerationRate, SettingsPlayable.Redguard.decelerationRate,
                SettingsPlayable.Redguard.attributeHealthRegen, SettingsPlayable.Redguard.attributeMagickaRegen, SettingsPlayable.Redguard.attributeStaminaRegen,
                SettingsPlayable.Redguard.unarmedDamage, SettingsPlayable.Redguard.unarmedReach,
                SettingsPlayable.Redguard.canSwim, SettingsPlayable.Redguard.regenCombatHP,
                SettingsPlayable.Redguard.flagsToAdd, SettingsPlayable.Redguard.flagsToRemove,

                SettingsPlayable.Redguard.Skills.Skill0, SettingsPlayable.Redguard.Skills.Skill0Boost,
                SettingsPlayable.Redguard.Skills.Skill1, SettingsPlayable.Redguard.Skills.Skill1Boost,
                SettingsPlayable.Redguard.Skills.Skill2, SettingsPlayable.Redguard.Skills.Skill2Boost,
                SettingsPlayable.Redguard.Skills.Skill3, SettingsPlayable.Redguard.Skills.Skill3Boost,
                SettingsPlayable.Redguard.Skills.Skill4, SettingsPlayable.Redguard.Skills.Skill4Boost,
                SettingsPlayable.Redguard.Skills.Skill5, SettingsPlayable.Redguard.Skills.Skill5Boost,
                SettingsPlayable.Redguard.Skills.Skill6, SettingsPlayable.Redguard.Skills.Skill6Boost),
            new RaceObject(SettingsPlayable.Elder.editorID, SettingsPlayable.Elder.newName, SettingsPlayable.Elder.aliases, SettingsPlayable.Elder.targetKeywords,
                SettingsPlayable.Elder.attributeHealth, SettingsPlayable.Elder.attributeMagicka, SettingsPlayable.Elder.attributeStamina,
                SettingsPlayable.Elder.baseCarryWeight, SettingsPlayable.Elder.baseMass,
                SettingsPlayable.Elder.accelerationRate, SettingsPlayable.Elder.decelerationRate,
                SettingsPlayable.Elder.attributeHealthRegen, SettingsPlayable.Elder.attributeMagickaRegen, SettingsPlayable.Elder.attributeStaminaRegen,
                SettingsPlayable.Elder.unarmedDamage, SettingsPlayable.Elder.unarmedReach,
                SettingsPlayable.Elder.canSwim, SettingsPlayable.Elder.regenCombatHP,
                SettingsPlayable.Elder.flagsToAdd, SettingsPlayable.Elder.flagsToRemove,

                SettingsPlayable.Elder.Skills.Skill0, SettingsPlayable.Elder.Skills.Skill0Boost,
                SettingsPlayable.Elder.Skills.Skill1, SettingsPlayable.Elder.Skills.Skill1Boost,
                SettingsPlayable.Elder.Skills.Skill2, SettingsPlayable.Elder.Skills.Skill2Boost,
                SettingsPlayable.Elder.Skills.Skill3, SettingsPlayable.Elder.Skills.Skill3Boost,
                SettingsPlayable.Elder.Skills.Skill4, SettingsPlayable.Elder.Skills.Skill4Boost,
                SettingsPlayable.Elder.Skills.Skill5, SettingsPlayable.Elder.Skills.Skill5Boost,
                SettingsPlayable.Elder.Skills.Skill6, SettingsPlayable.Elder.Skills.Skill6Boost),
            new RaceObject(SettingsPlayable.SnowElf.editorID, SettingsPlayable.SnowElf.newName, SettingsPlayable.SnowElf.aliases, SettingsPlayable.SnowElf.targetKeywords,
                SettingsPlayable.SnowElf.attributeHealth, SettingsPlayable.SnowElf.attributeMagicka, SettingsPlayable.SnowElf.attributeStamina,
                SettingsPlayable.SnowElf.baseCarryWeight, SettingsPlayable.SnowElf.baseMass,
                SettingsPlayable.SnowElf.accelerationRate, SettingsPlayable.SnowElf.decelerationRate,
                SettingsPlayable.SnowElf.attributeHealthRegen, SettingsPlayable.SnowElf.attributeMagickaRegen, SettingsPlayable.SnowElf.attributeStaminaRegen,
                SettingsPlayable.SnowElf.unarmedDamage, SettingsPlayable.SnowElf.unarmedReach,
                SettingsPlayable.SnowElf.canSwim, SettingsPlayable.SnowElf.regenCombatHP,
                SettingsPlayable.SnowElf.flagsToAdd, SettingsPlayable.SnowElf.flagsToRemove,

                SettingsPlayable.SnowElf.Skills.Skill0, SettingsPlayable.SnowElf.Skills.Skill0Boost,
                SettingsPlayable.SnowElf.Skills.Skill1, SettingsPlayable.SnowElf.Skills.Skill1Boost,
                SettingsPlayable.SnowElf.Skills.Skill2, SettingsPlayable.SnowElf.Skills.Skill2Boost,
                SettingsPlayable.SnowElf.Skills.Skill3, SettingsPlayable.SnowElf.Skills.Skill3Boost,
                SettingsPlayable.SnowElf.Skills.Skill4, SettingsPlayable.SnowElf.Skills.Skill4Boost,
                SettingsPlayable.SnowElf.Skills.Skill5, SettingsPlayable.SnowElf.Skills.Skill5Boost,
                SettingsPlayable.SnowElf.Skills.Skill6, SettingsPlayable.SnowElf.Skills.Skill6Boost),
            new RaceObject(SettingsPlayable.Dremora.editorID, SettingsPlayable.Dremora.newName, SettingsPlayable.Dremora.aliases, SettingsPlayable.Dremora.targetKeywords,
                SettingsPlayable.Dremora.attributeHealth, SettingsPlayable.Dremora.attributeMagicka, SettingsPlayable.Dremora.attributeStamina,
                SettingsPlayable.Dremora.baseCarryWeight, SettingsPlayable.Dremora.baseMass,
                SettingsPlayable.Dremora.accelerationRate, SettingsPlayable.Dremora.decelerationRate,
                SettingsPlayable.Dremora.attributeHealthRegen, SettingsPlayable.Dremora.attributeMagickaRegen, SettingsPlayable.Dremora.attributeStaminaRegen,
                SettingsPlayable.Dremora.unarmedDamage, SettingsPlayable.Dremora.unarmedReach,
                SettingsPlayable.Dremora.canSwim, SettingsPlayable.Dremora.regenCombatHP,
                SettingsPlayable.Dremora.flagsToAdd, SettingsPlayable.Dremora.flagsToRemove,

                SettingsPlayable.Dremora.Skills.Skill0, SettingsPlayable.Dremora.Skills.Skill0Boost,
                SettingsPlayable.Dremora.Skills.Skill1, SettingsPlayable.Dremora.Skills.Skill1Boost,
                SettingsPlayable.Dremora.Skills.Skill2, SettingsPlayable.Dremora.Skills.Skill2Boost,
                SettingsPlayable.Dremora.Skills.Skill3, SettingsPlayable.Dremora.Skills.Skill3Boost,
                SettingsPlayable.Dremora.Skills.Skill4, SettingsPlayable.Dremora.Skills.Skill4Boost,
                SettingsPlayable.Dremora.Skills.Skill5, SettingsPlayable.Dremora.Skills.Skill5Boost,
                SettingsPlayable.Dremora.Skills.Skill6, SettingsPlayable.Dremora.Skills.Skill6Boost),
            });
        }

        public static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            List<IRaceGetter> RacesToPatch = new List<IRaceGetter>();
            foreach (IRaceGetter race in state.LoadOrder.PriorityOrder.WinningOverrides<IRaceGetter>())
            {
                RacesToPatch.Add(race);
            }

            Logger.Log($"{RacesToPatch.Count} races to patch");

            //For each race we have in our list
            foreach (IRaceGetter raceToPatch in RacesToPatch)
            {
                Logger.Log($"{raceToPatch.EditorID} found");

                //Base Attributes
                float baseHealth = raceToPatch.Starting[BasicStat.Health];
                float baseMagicka = raceToPatch.Starting[BasicStat.Magicka];
                float baseStamina = raceToPatch.Starting[BasicStat.Stamina];

                float baseCarryWeight = raceToPatch.BaseCarryWeight;
                float baseMass = raceToPatch.BaseMass;

                float baseAcceleration = raceToPatch.AccelerationRate;
                float baseDeceleration = raceToPatch.DecelerationRate;

                float baseHealthRegen = raceToPatch.Regen[BasicStat.Health];
                float baseMagickaRegen = raceToPatch.Regen[BasicStat.Magicka];
                float baseStaminaRegen = raceToPatch.Regen[BasicStat.Stamina];

                float baseUnarmedDamage = raceToPatch.UnarmedDamage;
                float baseUnarmedReach = raceToPatch.UnarmedReach;

                //Other
                Race patchedRace = state.PatchMod.Races.GetOrAddAsOverride(raceToPatch);

                var IPatchedStartingAttributes = patchedRace.Starting;
                var IPatchedRegenAttributes = patchedRace.Regen;

                float GlobalHPMod = SettingsGlobal.GlobalHPMultiplier;
                float MinimumHPAnchor = SettingsGlobal.MinimumHPAnchor;
                float GlobalHPShift = SettingsGlobal.GlobalHPShift;

                //Check each target
                foreach (RaceObject selectedRace in RacesToModify.PlayableRaceList)
                {
                    //Check to see if Aliases is null. If not, we can use it. Otherwise we'll just use a dummy string.
                    string aliases = selectedRace.aliases == null ? aliases = "NOASSIGNEDASLIASES" : aliases = selectedRace.aliases;

                    List<string> aliasesList = aliases.Split(',').ToList();

                    //If the raceToPatch contains the selectedRace editor ID in their own ID, we'll use it as a match. Otherwise if the alises make any matches, we'll use them.
                    //TODO: Keyword fail-safe. Make Editor ID an exact match, aliases a (keyword + contains string) match.
                    if (raceToPatch.EditorID?.Contains(selectedRace.editorID) == true || raceToPatch.EditorID != null && aliases.Any(x => raceToPatch.EditorID.Contains(x)))
                    {
                        var condVamp = (raceToPatch.Keywords?.Contains(Skyrim.Keyword.Vampire) == true && SettingsPlayable.General.PlayableRaceVampireOrChildMod);
                        var condChild = (raceToPatch.Flags.HasFlag((Race.Flag)4) && SettingsPlayable.General.PlayableRaceVampireOrChildMod);

                        var condStatChange = (SettingsPlayable.General.PlayableRaceStatChanges);
                        var condNameChange = (SettingsPlayable.General.PlayableRaceNameChanges);
                        var condSkillhange = (SettingsPlayable.General.PlayableRaceSkillChanges);

                        int targetHealth = (int)(condStatChange ? selectedRace.attributeHealth : baseHealth);
                        int targetMagicka = (int)(condStatChange ? selectedRace.attributeMagicka : baseMagicka);
                        int targetStamina = (int)(condStatChange ? selectedRace.attributeStamina : baseStamina);

                        float targetCarryWeight = (condStatChange ? selectedRace.baseCarryWeight : baseAcceleration);
                        float targetMass = (condStatChange ? selectedRace.baseMass : baseMass);

                        float targetAcceleration = (condStatChange ? selectedRace.accelerationRate : baseCarryWeight);
                        float targetDeceleration = (condStatChange ? selectedRace.decelerationRate : baseDeceleration);

                        float targetHealthRegen = (condStatChange ? selectedRace.attributeHealthRegen : baseHealthRegen);
                        float targetMagickaRegen = (condStatChange ? selectedRace.attributeMagickaRegen : baseMagickaRegen);
                        float targetStaminaRegen = (condStatChange ? selectedRace.attributeStaminaRegen : baseStaminaRegen);

                        var newUnarmedDamage = (condStatChange ? selectedRace.unarmedDamage : baseUnarmedDamage);
                        var newUnarmedReach = (condStatChange ? selectedRace.unarmedReach : baseUnarmedDamage);

                        var newName = (condNameChange ? selectedRace.newName : null);

                        PatchAttributes(newName, targetHealth, targetMagicka, targetStamina, targetCarryWeight, targetMass, targetAcceleration, targetDeceleration, targetHealthRegen, targetMagickaRegen, targetStaminaRegen, newUnarmedDamage, newUnarmedReach);

                        break;
                    }
                }
            }
        }

        private static void PatchAttributes(string? newName, int targetHealth, int targetMagicka, int targetStamina, float targetCarryWeight, float targetMass, float targetAcceleration, float targetDeceleration, float targetHealthRegen, float targetMagickaRegen, float targetStaminaRegen, float newUnarmedDamage, float newUnarmedReach)
        {
            
        }
    }
}
