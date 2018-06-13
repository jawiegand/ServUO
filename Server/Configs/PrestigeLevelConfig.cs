using System;

namespace Server.Configs
{
    /// <summary>
    /// Provides the values from the PrestigeLevel.cfg file. Used for default
    /// values for Prestige Level system. Note: These values only reload on
    /// server restart.
    /// </summary>
    public static class PrestigeLevelConfig
    {
        // Name of the cfg file appended with period.
        private static string CONFIG_NAME = "PrestigeLevel.";

        #region .cfg values
        private static string is_enabled = CONFIG_NAME + "IsEnabled";

        private static string base_skills_cap = CONFIG_NAME + "BaseSkillCap";
        private static string level_one_skills_cap = CONFIG_NAME + "LevelOneSkillCap";
        private static string level_two_skills_cap = CONFIG_NAME + "LevelTwoSkillCap";
        private static string level_three_skills_cap = CONFIG_NAME + "LevelThreeSkillCap";

        private static string base_power_scroll_max = CONFIG_NAME + "BasePowerScrollMax";
        private static string level_one_power_scroll_max = CONFIG_NAME + "LevelOnePowerScrollMax";
        private static string level_two_power_scroll_max = CONFIG_NAME + "LevelTwoPowerScrollMax";

        private static string luck_bonus = CONFIG_NAME + "LuckBonus";
        private static string stat_bonus = CONFIG_NAME + "StatBonus";
        private static string level_one_difficulty = CONFIG_NAME + "LevelOneDifficulty";
        private static string level_two_difficulty = CONFIG_NAME + "LevelTwoDifficulty";
        private static string max_one_difficulty = CONFIG_NAME + "MaxOneDifficulty";
        private static string max_two_difficulty = CONFIG_NAME + "MaxTwoDifficulty";
        private static string max_three_difficulty = CONFIG_NAME + "MaxThreeDifficulty";
        private static string max_difficulty = CONFIG_NAME + "MaxDifficulty";
        #endregion

        #region Configuration Settings

        /// <summary>
        /// Determines if the Prestige System is enabled.
        /// </summary>
        public static readonly bool IsEnabled;

        /// <summary>
        /// Value in fixed point for base skill cap
        /// </summary>
        public static readonly int BaseSkillCap;

        /// <summary>
        /// Value in fixed point for skill cap at PL 1
        /// </summary>
        public static readonly int LevelOneSkillCap;

        /// <summary>
        /// Value in fixed point for skill cap at PL 2
        /// </summary>
        public static readonly int LevelTwoSkillCap;

        /// <summary>
        /// Value in fixed point for skill cap at PL 3
        /// </summary>
        public static readonly int LevelThreeSkillCap;

        /// <summary>
        /// Determines the maximum value of a scroll of power usable at base
        /// </summary>
        public static readonly int BasePowerScrollMax;

        /// <summary>
        /// Determines the maximum value of a scroll of power usable at PL 1
        /// </summary>
        public static readonly int LevelOnePowerScrollMax;

        /// <summary>
        /// Determines the maximum value of a scroll of power usable at PL 2
        /// </summary>
        public static readonly int LevelTwoPowerScrollMax;

        /// <summary>
        /// Value to add to players base luck at PL 2
        /// </summary>
        public static readonly int LuckBonus;

        /// <summary>
        /// Value to add to base stats at PL 3
        /// </summary>
        internal static readonly int StatBonus;

        /// <summary>
        /// Skill gain difficulty at PL 1
        /// </summary>
        public static readonly double LevelOneDifficulty;

        /// <summary>
        /// Skill gain difficulty at PL 2
        /// </summary>
        public static readonly double LevelTwoDifficulty;

        /// <summary>
        /// Skill gain difficulty at PL 3 for skills >= 60
        /// </summary>
        public static readonly double MaxOneDifficulty;

        /// <summary>
        /// Skill gain difficulty at PL 3 for skills >= 80
        /// </summary>
        public static readonly double MaxTwoDifficulty;

        /// <summary>
        /// Skill gain difficulty at PL 3 for skills >= 100
        /// </summary>
        public static readonly double MaxThreeDifficulty;

        /// <summary>
        /// Skill gain difficulty at PL 3 for skills > 100
        /// </summary>
        public static readonly double MaxDifficulty;

        #endregion

        static PrestigeLevelConfig()
        {
            IsEnabled = Config.Get(is_enabled, false);

            BaseSkillCap = Config.Get(base_skills_cap, 7000);
            LevelOneSkillCap = Config.Get(level_one_skills_cap, 14000);
            LevelTwoSkillCap = Config.Get(level_two_skills_cap, 21000);
            LevelThreeSkillCap = Config.Get(level_three_skills_cap, 70000);

            // Skills cap validation
            LevelOneSkillCap = Math.Max(BaseSkillCap, LevelOneSkillCap);
            LevelTwoSkillCap = Math.Max(LevelOneSkillCap, LevelTwoSkillCap);
            LevelThreeSkillCap = Math.Max(LevelTwoSkillCap, LevelThreeSkillCap);

            BasePowerScrollMax = Config.Get(base_power_scroll_max, 105);
            LevelOnePowerScrollMax = Config.Get(level_one_power_scroll_max, 110);
            LevelTwoPowerScrollMax = Config.Get(level_two_power_scroll_max, 115);

            // PS validation
            LevelOnePowerScrollMax = Math.Max(BasePowerScrollMax, LevelOnePowerScrollMax);
            LevelTwoPowerScrollMax = Math.Max(LevelOnePowerScrollMax, LevelTwoPowerScrollMax);

            LuckBonus = Config.Get(luck_bonus, 150);
            StatBonus = Config.Get(stat_bonus, 140);

            LevelOneDifficulty = Config.Get(level_one_difficulty, 2.0);
            LevelTwoDifficulty = Config.Get(level_two_difficulty, 4.0);
            MaxOneDifficulty = Config.Get(max_one_difficulty, 4.0);
            MaxTwoDifficulty = Config.Get(max_two_difficulty, 6.0);
            MaxThreeDifficulty = Config.Get(max_three_difficulty, 8.0);
            MaxDifficulty = Config.Get(max_difficulty, 10.0);
        }
    }
}
