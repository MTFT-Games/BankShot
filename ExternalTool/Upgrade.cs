namespace ExternalTool
{
    /// <summary>
    /// Primary Author: Noah Emke
    /// A class for holding all attributes of any upgrade. It looks heinous but 
    /// it allows the upgrade system to be very flexible
    /// </summary>
    public class Upgrade
    {
        public bool damageIsMultiplier;
        public double damageModifier;

        public bool projectileCountIsMultiplier;
        public double projectileCountModifier;

        public bool rateOfFireIsMultiplier;
        public double rateOfFireModifier;

        public bool projectileSpeedIsMultiplier;
        public double projectileSpeedModifier;

        public double projectileSizeModifier;

        public bool projectileSpreadIsMultiplier;
        public double projectileSpreadModifier;

        public bool projectileHomingIsMultiplier;
        public double projectileHomingModifier;

        public bool shieldHealthIsMultiplier;
        public double shieldHealthModifier;

        public bool shieldRegenIsMultiplier;
        public double shieldRegenModifier;

        public bool shieldCooldownIsMultiplier;
        public double shieldCooldownModifier;

        public bool healthIsMultiplier;
        public double healthModifier;

        public bool healthRegenIsMultiplier;
        public double healthRegenModifier;

        public bool knockbackIsMultiplier;
        public double knockbackModifier;

        public bool knockbackResistIsMultiplier;
        public double knockbackResistModifier;

        public bool additionalJump;

        public string iconPath;
        public string name;
        public string description;
        public int weight;
        public int cost;

        /// <summary>
        /// Create a new upgrade with all modifications to player stats.
        /// </summary>
        /// <param name="damageIsMultiplier">Denotes weather the damage 
        /// modifier should be interpreted as a percent multiplier or a value 
        /// to add.</param>
        /// <param name="damageModifier">Modifier to be applied to the players 
        /// weapon damage as either a percentage multiplier or a flat value addition.</param>
        /// <param name="projectileCountIsMultiplier">Denotes weather the 
        /// projectile count modifier should be interpreted as a percent 
        /// multiplier or a value to add.</param>
        /// <param name="projectileCountModifier">Modifier to be applied to the 
        /// number of projectiles spawned per shot of the players weapon as 
        /// either a percentage multiplier or a flat value addition.</param>
        /// <param name="rateOfFireIsMultiplier">Denotes weather the 
        /// rate of fire modifier should be interpreted as a percent 
        /// multiplier or a value to add.</param>
        /// <param name="rateOfFireModifier">Modifier to be applied to the rate 
        /// of fire of the players weapon as either a percentage multiplier or 
        /// a flat value of shots per second.</param>
        /// <param name="projectileSpeedIsMultiplier">Denotes weather the 
        /// projectile speed modifier should be interpreted as a percent 
        /// multiplier or a value to add.</param>
        /// <param name="projectileSpeedModifier">Modifier to be applied to the 
        /// speed of any projectile spawned by the player as either a percentage
        /// multiplier or a flat value addition.</param>
        /// <param name="projectileSizeModifier">Modifier to be applied to the 
        /// size of any projectile spawned by the player as a percentage 
        /// multiplier.</param>
        /// <param name="projectileSpreadIsMultiplier">Denotes weather the 
        /// projectile spread modifier should be interpreted as a percent 
        /// multiplier or a value to add.</param>
        /// <param name="projectileSpreadModifier">Modifier to be applied to 
        /// the spread of projectiles shot by the player as either a 
        /// percentage multiplier or a flat value in degrees.</param>
        /// <param name="projectileHomingIsMultiplier">Denotes weather the 
        /// projectile homing modifier should be interpreted as a percent 
        /// multiplier or a value to add.</param>
        /// <param name="projectileHomingModifier">Modifier to be applied to 
        /// the players homing abilities of any projectile spawned by the 
        /// player as either a percentage multiplier or a flat value in 
        /// degrees per second.</param>
        /// <param name="shieldHealthIsMultiplier">Denotes weather the 
        /// shield health modifier should be interpreted as a percent 
        /// multiplier or a value to add.</param>
        /// <param name="shieldHealthModifier">Modifier to be applied to the 
        /// player's shield health maximum as either a percentage multiplier 
        /// or a flat value addition.</param>
        /// <param name="shieldRegenIsMultiplier">Denotes weather the 
        /// shield regen modifier should be interpreted as a percent 
        /// multiplier or a value to add.</param>
        /// <param name="shieldRegenModifier">Modifier to be applied to the 
        /// player's shield regeneration rate as either a percentage multiplier 
        /// or a flat value as health per second.</param>
        /// <param name="shieldCooldownIsMultiplier">Denotes weather the 
        /// shield cooldown modifier should be interpreted as a percent 
        /// multiplier or a value to add.</param>
        /// <param name="shieldCooldownModifier">Modifier to be applied to the 
        /// time to wait after being used before the shield starts to regenerate 
        /// as either a percentage multiplier or a flat value in seconds.</param>
        /// <param name="healthIsMultiplier">Denotes weather the 
        /// health modifier should be interpreted as a percent 
        /// multiplier or a value to add.</param>
        /// <param name="healthModifier">Modifier to be applied to the player's 
        /// maximum health as either a percentage multiplier or a flat value 
        /// addition.</param>
        /// <param name="healthRegenIsMultiplier">Denotes weather the 
        /// health regen modifier should be interpreted as a percent 
        /// multiplier or a value to add.</param>
        /// <param name="healthRegenModifier">Modifier to be applied to the 
        /// players health regeneration rate as either a percentage multiplier 
        /// or a flat value in health per second.</param>
        /// <param name="knockbackIsMultiplier">Denotes weather the 
        /// knockback modifier should be interpreted as a percent 
        /// multiplier or a value to add.</param>
        /// <param name="knockbackModifier">Modifier to be applied to the speed 
        /// with which the player knocks back enemies as either a percentage 
        /// multiplier or a flat value addition.</param>
        /// <param name="knockbackResistIsMultiplier">Denotes weather the 
        /// knockback resist modifier should be interpreted as a percent 
        /// multiplier or a value to add.</param>
        /// <param name="knockbackResistModifier">Modifier to be applied to the 
        /// players resistance to being knocked back as either a percentage 
        /// multiplier or a flat number of percentage points to add.</param>
        /// <param name="iconPath">The image to be displayed in the shop along side 
        /// this upgrade.</param>
        /// <param name="name">The name of this upgrade as displayed to the 
        /// player.</param>
        /// <param name="description">The description of the upgrade displayed 
        /// to the player.</param>
        /// <param name="weight">The weight associated with this upgrade to give 
        /// it rarity in the random generator.</param>
        /// <param name="cost">The cost of the upgrade.</param>
        public Upgrade(string name, string description, bool damageIsMultiplier, double damageModifier,
            bool projectileCountIsMultiplier, double projectileCountModifier,
            bool rateOfFireIsMultiplier, double rateOfFireModifier,
            bool projectileSpeedIsMultiplier, double projectileSpeedModifier,
            double projectileSizeModifier, bool projectileSpreadIsMultiplier,
            double projectileSpreadModifier, bool projectileHomingIsMultiplier,
            double projectileHomingModifier, bool shieldHealthIsMultiplier,
            double shieldHealthModifier, bool shieldRegenIsMultiplier,
            double shieldRegenModifier, bool shieldCooldownIsMultiplier,
            double shieldCooldownModifier, bool healthIsMultiplier,
            double healthModifier, bool healthRegenIsMultiplier,
            double healthRegenModifier, bool knockbackIsMultiplier,
            double knockbackModifier, bool knockbackResistIsMultiplier,
            double knockbackResistModifier, bool jump, string iconPath, 
            int weight, int cost)
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
            this.additionalJump = jump;
            this.iconPath = iconPath;
            this.name = name;
            this.description = description;
            this.weight = weight;
            this.cost = cost;
        }
    }
}
