using Microsoft.Xna.Framework.Graphics;

namespace BankShot
{
    /// <summary>
    /// Primary Author: Noah Emke
    /// A struct for holding all attributes of any upgrade. It looks heinous but 
    /// it allows the upgrade system to be very flexible
    /// </summary>
    public struct Upgrade
    {
        public bool damageIsMultiplier;
        public int damageModifier;

        public bool projectileCountIsMultiplier;
        public int projectileCountModifier;

        public bool rateOfFireIsMultiplier;
        public float rateOfFireModifier;

        public bool projectileSpeedIsMultiplier;
        public float projectileSpeedModifier;

        public int projectileSizeModifier;

        public bool projectileSpreadIsMultiplier;
        public float projectileSpreadModifier;

        public bool projectileHomingIsMultiplier;
        public float projectileHomingModifier;

        public bool shieldHealthIsMultiplier;
        public int shieldHealthModifier;

        public bool shieldRegenIsMultiplier;
        public float shieldRegenModifier;

        public bool shieldCooldownIsMultiplier;
        public float shieldCooldownModifier;

        public bool healthIsMultiplier;
        public float healthModifier;

        public bool healthRegenIsMultiplier;
        public float healthRegenModifier;

        public bool knockbackIsMultiplier;
        public float knockbackModifier;

        public bool knockbackResistIsMultiplier;
        public int knockbackResistModifier;

        public bool additionalJump;

        public Texture2D icon;
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
        /// <param name="icon">The image to be displayed in the shop along side 
        /// this upgrade.</param>
        /// <param name="name">The name of this upgrade as displayed to the 
        /// player.</param>
        /// <param name="description">The description of the upgrade displayed 
        /// to the player.</param>
        /// <param name="weight">The weight associated with this upgrade to give 
        /// it rarity in the random generator.</param>
        /// <param name="cost">The cost of the upgrade.</param>
        public Upgrade(bool damageIsMultiplier, int damageModifier,
            bool projectileCountIsMultiplier, int projectileCountModifier,
            bool rateOfFireIsMultiplier, float rateOfFireModifier,
            bool projectileSpeedIsMultiplier, float projectileSpeedModifier,
            int projectileSizeModifier, bool projectileSpreadIsMultiplier,
            float projectileSpreadModifier, bool projectileHomingIsMultiplier,
            float projectileHomingModifier, bool shieldHealthIsMultiplier,
            int shieldHealthModifier, bool shieldRegenIsMultiplier,
            float shieldRegenModifier, bool shieldCooldownIsMultiplier,
            float shieldCooldownModifier, bool healthIsMultiplier,
            float healthModifier, bool healthRegenIsMultiplier,
            float healthRegenModifier, bool knockbackIsMultiplier,
            float knockbackModifier, bool knockbackResistIsMultiplier,
            int knockbackResistModifier, bool jump, Texture2D icon, string name,
            string description, int weight, int cost)
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
            this.icon = icon;
            this.name = name;
            this.description = description;
            this.weight = weight;
            this.cost = cost;
        }
    }
}
