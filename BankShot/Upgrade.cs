﻿using Microsoft.Xna.Framework.Graphics;

namespace BankShot
{
    /// <summary>
    /// Primary Author: Noah Emke
    /// A struct for holding all attributes of any upgrade.
    /// </summary>
    struct Upgrade
    {
        public bool damageIsMultiplier; 
        public int damageModifier;

        public bool projectileCountIsMultiplier;
        public int projectileCountModifier;

        public bool rateOfFireIsMultiplier;
        public int rateOfFireModifier;

        public bool projectileSpeedIsMultiplier;
        public int projectileSpeedModifier;

        public int projectileSizeModifier;

        public bool projectileSpreadIsMultiplier;
        public int projectileSpreadModifier;

        public bool projectileHomingIsMultiplier;
        public int projectileHomingModifier;

        public bool shieldHealthIsMultiplier;
        public int shieldHealthModifier;

        public bool shieldRegenIsMultiplier;
        public int shieldRegenModifier;

        public bool shieldCooldownIsMultiplier;
        public int shieldCooldownModifier;

        public bool healthIsMultiplier;
        public int healthModifier;

        public bool healthRegenIsMultiplier;
        public int healthRegenModifier;

        public bool knockbackIsMultiplier;
        public int knockbackModifier;

        public bool knockbackResistIsMultiplier;
        public int knockbackResistModifier;

        public Texture2D icon;
        public string name;
        public string description;
        public int weight;

        /// <summary>
        /// Create a new upgrade with all modifications to player stats.
        /// </summary>
        /// <param name="damageIsMultiplier">Denotes weather the damage 
        /// modifier should be interpreted as a percent multiplier or a value 
        /// to add.</param>
        /// <param name="damageModifier"></param>
        /// <param name="projectileCountIsMultiplier"></param>
        /// <param name="projectileCountModifier"></param>
        /// <param name="rateOfFireIsMultiplier"></param>
        /// <param name="rateOfFireModifier"></param>
        /// <param name="projectileSpeedIsMultiplier"></param>
        /// <param name="projectileSpeedModifier"></param>
        /// <param name="projectileSizeModifier"></param>
        /// <param name="projectileSpreadIsMultiplier"></param>
        /// <param name="projectileSpreadModifier"></param>
        /// <param name="projectileHomingIsMultiplier"></param>
        /// <param name="projectileHomingModifier"></param>
        /// <param name="shieldHealthIsMultiplier"></param>
        /// <param name="shieldHealthModifier"></param>
        /// <param name="shieldRegenIsMultiplier"></param>
        /// <param name="shieldRegenModifier"></param>
        /// <param name="shieldCooldownIsMultiplier"></param>
        /// <param name="shieldCooldownModifier"></param>
        /// <param name="healthIsMultiplier"></param>
        /// <param name="healthModifier"></param>
        /// <param name="healthRegenIsMultiplier"></param>
        /// <param name="healthRegenModifier"></param>
        /// <param name="knockbackIsMultiplier"></param>
        /// <param name="knockbackModifier"></param>
        /// <param name="knockbackResistIsMultiplier"></param>
        /// <param name="knockbackResistModifier"></param>
        /// <param name="icon"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="weight"></param>
        public Upgrade(bool damageIsMultiplier, int damageModifier, 
            bool projectileCountIsMultiplier, int projectileCountModifier, 
            bool rateOfFireIsMultiplier, int rateOfFireModifier, 
            bool projectileSpeedIsMultiplier, int projectileSpeedModifier, 
            int projectileSizeModifier, bool projectileSpreadIsMultiplier, 
            int projectileSpreadModifier, bool projectileHomingIsMultiplier, 
            int projectileHomingModifier, bool shieldHealthIsMultiplier, 
            int shieldHealthModifier, bool shieldRegenIsMultiplier, 
            int shieldRegenModifier, bool shieldCooldownIsMultiplier, 
            int shieldCooldownModifier, bool healthIsMultiplier, 
            int healthModifier, bool healthRegenIsMultiplier, 
            int healthRegenModifier, bool knockbackIsMultiplier, 
            int knockbackModifier, bool knockbackResistIsMultiplier, 
            int knockbackResistModifier, Texture2D icon, string name, 
            string description, int weight)
        {
            this.damageIsMultiplier = damageIsMultiplier;
            this.damageModifier = damageModifier;
            this.projectileCountIsMultiplier = projectileCountIsMultiplier;
            this.projectileCountModifier = projectileCountModifier;
            this.rateOfFireIsMultiplier = rateOfFireIsMultiplier;
            this.rateOfFireModifier = rateOfFireModifier;
            this.projectileSpeedIsMultiplier = projectileSpeedIsMultiplier;
            this.projectileSpeedModifier = projectileSpeedModifier;
            this.projectileSizeModifier = projectileSizeModifier;
            this.projectileSpreadIsMultiplier = projectileSpreadIsMultiplier;
            this.projectileSpreadModifier = projectileSpreadModifier;
            this.projectileHomingIsMultiplier = projectileHomingIsMultiplier;
            this.projectileHomingModifier = projectileHomingModifier;
            this.shieldHealthIsMultiplier = shieldHealthIsMultiplier;
            this.shieldHealthModifier = shieldHealthModifier;
            this.shieldRegenIsMultiplier = shieldRegenIsMultiplier;
            this.shieldRegenModifier = shieldRegenModifier;
            this.shieldCooldownIsMultiplier = shieldCooldownIsMultiplier;
            this.shieldCooldownModifier = shieldCooldownModifier;
            this.healthIsMultiplier = healthIsMultiplier;
            this.healthModifier = healthModifier;
            this.healthRegenIsMultiplier = healthRegenIsMultiplier;
            this.healthRegenModifier = healthRegenModifier;
            this.knockbackIsMultiplier = knockbackIsMultiplier;
            this.knockbackModifier = knockbackModifier;
            this.knockbackResistIsMultiplier = knockbackResistIsMultiplier;
            this.knockbackResistModifier = knockbackResistModifier;
            this.icon = icon;
            this.name = name;
            this.description = description;
            this.weight = weight;
        }
    }
}
