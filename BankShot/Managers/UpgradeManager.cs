using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    public class UpgradeManager
    {
        //fields

        private List<Upgrade> upgrades;
        private int totalWeight;
        private List<Shop> shops;
        private Texture2D textureShop;
        private Rectangle transformShop;
        private List<Rectangle> collisionBoxesShop;
        private bool activeShop;
        private Texture2D exitTx;



        //constructor------------------------------------------------------------------------------
        public UpgradeManager(Texture2D damageTexture, Texture2D speedTexture, Texture2D healthTexture,
            Texture2D textureForShop, Rectangle transformForShop, List<Rectangle> collisionBoxesForShop,
            bool activeForShop, Texture2D exit)
        {
            upgrades = new List<Upgrade>();
            
            Upgrade upgrade1 = new Upgrade(
                true, 200,   //Damage
                false, 0,    //Projectile count
                false, 0,    //Rate of fire
                false, 0,    //Projectile speed
                0,           //Projectile size
                false, 0,    //Projectile spread
                false, 0,    //Projectile homing
                false, 0,    //Shield health
                false, 0,    //Shield regeneration
                false, 0,    //Shield cooldown
                false, 0,    //Health
                false, 0,    //Health regeneration
                false, 0,    //Knockback
                false, 0,    //Knockback resist
                false,      //Additional Jump
                damageTexture,
                "Damage Boost",
                "Doubles damage done by player",
                1,
                2000);

            upgrades.Add(upgrade1);

            Upgrade upgrade2 = new Upgrade(
                false, 0,   //Damage
                false, 0,   //Projectile count
                false, 0,   //Rate of fire
                true, 1.50f,//Projectile speed 
                1,          //Projectile size
                false, 0,   //Projectile spread
                false, 0,   //Projectile homing
                false, 0,   //Shield health
                false, 0,   //Shield regeneration
                false, 0,   //Shield cooldown
                false, 0,   //Health
                false, 0,   //Health regeneration
                false, 0,   //Knockback
                false, 0,   //Knockback resist
                false,      //Additional Jump
                speedTexture,
                "Projectile Boost",
                "Speeds up projectiles by 50%",
                1,
                1000);

            upgrades.Add(upgrade2);

            Upgrade upgrade3 = new Upgrade(
                false, 0,   //Damage
                false, 0,   //Projectile count
                false, 0,   //Rate of fire
                false, 0,   //Projectile speed
                0,          //Projectile size
                false, 0,   //Projectile spread
                false, 0,   //Projectile homing
                false, 0,   //Shield health
                false, 0,   //Shield regeneration
                false, 0,   //Shield cooldown
                true, 1.5f, //Health
                false, 0,   //Health regeneration
                false, 0,   //Knockback
                false, 0,   //Knockback resist
                false,      //Additional Jump
                healthTexture,
                "Health Boost",
                "Increases max health by 50%",
                1,
                1500);

            upgrades.Add(upgrade3);

            int tWeight = 0;
            foreach (Upgrade u in upgrades)
            {
                tWeight += u.weight;
            }
            totalWeight = tWeight;

            textureShop = textureForShop;
            transformShop = transformForShop;
            activeShop = activeForShop;
            shops = new List<Shop>();
            collisionBoxesShop = new List<Rectangle> { transformShop };

            Shop.ShopWindow = Program.game.Content.Load<Texture2D>("ShopWindow");

            exitTx = exit;

        }

        //accessors. each get and set for now, subject to change ----------------------------------

        public List<Upgrade> Upgrades
        {
            //could use an indexed accessor?
            get { return upgrades; }
            //set { upgrades = value; }
        }

        public int TotalWeight
        {
            get { return totalWeight; }
            set { totalWeight = value; }
        }

        public List<Shop> Shops
        {
            //might alsp need an indexed accessor
            get { return shops; }
            set { shops = value; }
        }

        //methods. currently only headers. --------------------------------------------------------

        public void Update()
        {
            for (int i = 0; i < shops.Count; i++)
            {
                shops[i].Update();
            }
        }

        public void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < shops.Count; i++)
            {
                shops[i].Draw(sb);
            }
        }

        public void MakeShop()
        {
            //takes in an array of objects and creates an instance of "Shop" to be used by the player
            shops.Add(new Shop(textureShop, transformShop, collisionBoxesShop, activeShop, upgrades, exitTx));

        }


        public void EndShopping()
        {
            for (int i = 0; i < shops.Count; i++)
            {
                shops[i].ExitScreen();
            }

            Game1.waveManager.WaveBreak = false;
        }

        /// <summary>
        /// Takes an upgrade and applies all of its effects to the player.
        /// </summary>
        /// <param name="upgrade">The upgrade to be applied.</param>
        /// <param name="p">The active player.</param>
        public void ApplyUpgrades(Upgrade upgrade, Player p)
        {
            if (p.Money >= upgrade.cost)
            {
                //takes in an upgrade and applies it to the Player
                if (upgrade.damageIsMultiplier)
                {
                    p.CurrentWeapon.Damage *= upgrade.damageModifier;

                } else
                {
                    p.CurrentWeapon.Damage += upgrade.damageModifier;
                }

                if (p.CurrentWeapon is Gun)
                {
                    if (upgrade.projectileCountIsMultiplier)
                    {
                        ((Gun)p.CurrentWeapon).ProjectileCount *=
                            upgrade.projectileCountModifier;
                    } else
                    {
                        ((Gun)p.CurrentWeapon).ProjectileCount +=
                            upgrade.projectileCountModifier;
                    }

                    if (upgrade.projectileSpeedIsMultiplier)
                    {
                        ((Gun)p.CurrentWeapon).Speed *= upgrade.projectileSpeedModifier;
                    } else
                    {
                        ((Gun)p.CurrentWeapon).Speed += upgrade.projectileSpeedModifier;
                    }

                    Rectangle tmpProjRect = ((Gun)p.CurrentWeapon).ProjectileTransform;
                    ((Gun)p.CurrentWeapon).ProjectileTransform = new Rectangle(
                        tmpProjRect.X,
                        tmpProjRect.Y,
                        tmpProjRect.Width * upgrade.projectileSizeModifier,
                        tmpProjRect.Height * upgrade.projectileSizeModifier);

                    if (upgrade.projectileSpreadIsMultiplier)
                    {
                        ((Gun)p.CurrentWeapon).ProjectileSpread *=
                            upgrade.projectileSpreadModifier;
                    } else
                    {
                        ((Gun)p.CurrentWeapon).ProjectileSpread +=
                            upgrade.projectileSpreadModifier;
                    }

                    if (upgrade.projectileHomingIsMultiplier)
                    {
                        ((Gun)p.CurrentWeapon).Homing *= upgrade.projectileHomingModifier;
                    } else
                    {
                        ((Gun)p.CurrentWeapon).Homing += upgrade.projectileHomingModifier;
                    }
                } else
                {
                    Rectangle tmpWepRect = p.CurrentWeapon.Rect;
                    p.CurrentWeapon.Rect = new Rectangle(
                        tmpWepRect.X,
                        tmpWepRect.Y,
                        tmpWepRect.Width * upgrade.projectileSizeModifier,
                        tmpWepRect.Height * upgrade.projectileSizeModifier);
                }

                if (upgrade.rateOfFireIsMultiplier)
                {
                    p.CurrentWeapon.AttackRate *= upgrade.rateOfFireModifier;
                } else
                {
                    p.CurrentWeapon.AttackRate += upgrade.rateOfFireModifier;
                }

                if (upgrade.shieldHealthIsMultiplier)
                {
                    p.CurrentShield.MaxHealth *= upgrade.shieldHealthModifier;
                } else
                {
                    p.CurrentShield.MaxHealth *= upgrade.shieldHealthModifier;
                }

                if (upgrade.shieldRegenIsMultiplier)
                {
                    p.CurrentShield.RegenRate *= upgrade.shieldRegenModifier;
                } else
                {
                    p.CurrentShield.RegenRate += upgrade.shieldRegenModifier;
                }

                if (upgrade.shieldCooldownIsMultiplier)
                {
                    p.CurrentShield.CoolDown *= upgrade.shieldCooldownModifier;
                } else
                {
                    p.CurrentShield.CoolDown += upgrade.shieldCooldownModifier;
                }

                if (upgrade.healthIsMultiplier)
                {
                    double temp = p.Health / (double)p.MaxHealth;
                    p.MaxHealth = (int)(p.MaxHealth * upgrade.healthModifier);
                    p.Health = (int)(p.MaxHealth * temp);
                } else
                {
                    double temp = p.Health / (double)p.MaxHealth;
                    p.Health += (int)upgrade.healthModifier;                    p.Health = (int)(p.MaxHealth * temp);
                    p.Health = (int)(p.MaxHealth * temp);
                }

                if (upgrade.healthRegenIsMultiplier)
                {
                    p.RegenRate *= upgrade.healthRegenModifier;
                } else
                {
                    p.RegenRate += upgrade.healthRegenModifier;
                }

                if (upgrade.knockbackIsMultiplier)
                {
                    p.CurrentWeapon.Knockback *= upgrade.knockbackModifier;
                } else
                {
                    p.CurrentWeapon.Knockback += upgrade.knockbackModifier;
                }

                if (upgrade.knockbackResistIsMultiplier)
                {
                    //not implemented yet
                } else
                {
                    //not implemented yet
                }

                if (upgrade.additionalJump)
                {
                    Game1.player.NumberOfJumps += 1;
                }

                p.Money -= upgrade.cost;
            }

        }


        public string ReadUpgrades()
        {
            //will return a string list of upgrades that are applied to the player
            return "";

        }


    }
}
