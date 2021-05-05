using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    public class UpgradeManager
    {
        //fields
        private Random rng;
        private List<Upgrade> upgrades;
        private int totalWeight;
        private List<Shop> shops;
        private Rectangle transformShop;
        private List<Rectangle> collisionBoxesShop;
        private bool activeShop;



        //constructor------------------------------------------------------------------------------
        public UpgradeManager(
            Rectangle transformForShop, List<Rectangle> collisionBoxesForShop,
            bool activeForShop)
        {
            rng = new Random();
            LoadUpgrades();

            int tWeight = 0;
            foreach (Upgrade u in upgrades)
            {
                tWeight += u.weight;
            }
            totalWeight = tWeight;

            transformShop = transformForShop;
            activeShop = activeForShop;
            shops = new List<Shop>();
            collisionBoxesShop = new List<Rectangle> { transformShop };

            Shop.shopTexture = Program.game.Content.Load<Texture2D>("Shop");
            Shop.ShopWindow = Program.game.Content.Load<Texture2D>("ShopWindow");
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

        public bool ActiveShop
        {
            get
            {
                return activeShop;
            }
            set
            {
                activeShop = value;
            }
        }

        //methods. currently only headers. --------------------------------------------------------

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < shops.Count; i++)
            {
                shops[i].Update(gameTime);
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
            Game1.soundEffects[4].Play();
            Upgrade upgrade1 = GetRandomUpgrade();
            Upgrade upgrade2 = GetRandomUpgrade();
            while (upgrade2.name == upgrade1.name)
            {
                upgrade2 = GetRandomUpgrade();
            }
            Upgrade upgrade3 = GetRandomUpgrade();
            while (upgrade3.name == upgrade1.name || upgrade3.name == upgrade2.name)
            {
                upgrade3 = GetRandomUpgrade();
            }      

            shops.Add(new Shop(rng.Next(300, 1100), collisionBoxesShop, activeShop, new Upgrade[] { upgrade1, upgrade2, upgrade3 }));

        }
        public void MakeShop(int x)
        {
            Game1.soundEffects[4].Play();
            Upgrade upgrade1 = GetRandomUpgrade();
            Upgrade upgrade2 = GetRandomUpgrade();
            while (upgrade2.name == upgrade1.name)
            {
                upgrade2 = GetRandomUpgrade();
            }
            Upgrade upgrade3 = GetRandomUpgrade();
            while (upgrade3.name == upgrade1.name || upgrade3.name == upgrade2.name)
            {
                upgrade3 = GetRandomUpgrade();
            }


            shops.Add(new Shop(x, collisionBoxesShop, activeShop, new Upgrade[] { upgrade1, upgrade2, upgrade3 }, false));

        }

        private Upgrade GetRandomUpgrade()
        {
            int rand = rng.Next(0, totalWeight);
            int checkedWeight = 0;
            foreach (Upgrade upgrade in upgrades)
            {
                if (rand >= checkedWeight && rand < checkedWeight + upgrade.weight)
                {
                    return upgrade;
                } else
                {
                    checkedWeight += upgrade.weight;
                }
            }
            return upgrades[0];
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
        public void ApplyUpgrade(Upgrade upgrade, Player p)
        {
            if (p.Money >= upgrade.cost)
            {
                //takes in an upgrade and applies it to the Player
                if (upgrade.damageIsMultiplier)
                {
                    p.CurrentWeapon.Damage = 
                        (int)(p.CurrentWeapon.Damage*upgrade.damageModifier);

                } else
                {
                    p.CurrentWeapon.Damage += (int)upgrade.damageModifier;
                }

                if (p.CurrentWeapon is Gun)
                {
                    if (upgrade.projectileCountIsMultiplier)
                    {
                        ((Gun)p.CurrentWeapon).ProjectileCount =
                            (int)(((Gun)p.CurrentWeapon).ProjectileCount 
                            * upgrade.projectileCountModifier);
                    } else
                    {
                        ((Gun)p.CurrentWeapon).ProjectileCount +=
                            (int)upgrade.projectileCountModifier;
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
                        (int)(tmpProjRect.Width * upgrade.projectileSizeModifier),
                        (int)(tmpProjRect.Height * upgrade.projectileSizeModifier));
                    if (((Gun)(p.CurrentWeapon)).ProjectileTransform.Width > 40)
                    {
                        ((Gun)(p.CurrentWeapon)).ProjectileTransform = new Rectangle(tmpProjRect.X, tmpProjRect.Y, 40, 40);
                    }

                    if (upgrade.projectileSpreadIsMultiplier)
                    {
                        ((Gun)p.CurrentWeapon).ProjectileSpread *=
                            (float)upgrade.projectileSpreadModifier;
                    } else
                    {
                        ((Gun)p.CurrentWeapon).ProjectileSpread +=
                            (float)upgrade.projectileSpreadModifier;
                    }

                    if (upgrade.projectileHomingIsMultiplier)
                    {
                        if (((Gun)p.CurrentWeapon).Homing == 0)
                        {
                            ((Gun)p.CurrentWeapon).Homing = .0035;                        
                        }
                        else
                        {
                            ((Gun)p.CurrentWeapon).Homing *= upgrade.projectileHomingModifier;
                        }
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
                        (int)(tmpWepRect.Width * upgrade.projectileSizeModifier),
                        (int)(tmpWepRect.Height * upgrade.projectileSizeModifier));
                }

                if (upgrade.rateOfFireIsMultiplier)
                {
                    p.CurrentWeapon.AttackRate *= (float)upgrade.rateOfFireModifier;
                } else
                {
                    p.CurrentWeapon.AttackRate += (float)upgrade.rateOfFireModifier;
                }

                if (upgrade.shieldHealthIsMultiplier)
                {
                    p.CurrentShield.MaxHealth =
                        (int)(p.CurrentShield.MaxHealth * upgrade.shieldHealthModifier);
                } else
                {
                    p.CurrentShield.MaxHealth += (int)upgrade.shieldHealthModifier;
                }

                if (upgrade.shieldRegenIsMultiplier)
                {
                    p.CurrentShield.RegenRate *= (float)upgrade.shieldRegenModifier;
                } else
                {
                    p.CurrentShield.RegenRate += (float)upgrade.shieldRegenModifier;
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
                    p.RegenRate *= (float)upgrade.healthRegenModifier;
                } else
                {
                    p.RegenRate += (float)upgrade.healthRegenModifier;
                }

                if (upgrade.knockbackIsMultiplier)
                {
                    p.CurrentWeapon.Knockback *= (float)upgrade.knockbackModifier;
                } else
                {
                    p.CurrentWeapon.Knockback += (float)upgrade.knockbackModifier;
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


        /// <summary>
        /// Loads all upgrades in from the file.
        /// </summary>
        private void LoadUpgrades()
        {
            StreamReader reader = null;
            try
            {
                upgrades = new List<Upgrade>();
                reader = new StreamReader("Content/upgrades.data");
                do
                {
                    string name = reader.ReadLine();
                    string description = "";
                    do
                    {
                        description += reader.ReadLine()+"\n";
                    } while (description.Substring(description.Length - 3) != "||\n");

                    string[] line = reader.ReadLine().Split(' ');
                    bool damageIsMultiplier = bool.Parse(line[0]);
                    double damageModifier = double.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    bool projectileCountIsMultiplier = bool.Parse(line[0]);
                    double projectileCountModifier = double.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    bool rateOfFireIsMultiplier = bool.Parse(line[0]);
                    double rateOfFireModifier = double.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    bool projectileSpeedIsMultiplier = bool.Parse(line[0]);
                    double projectileSpeedModifier = double.Parse(line[1]);

                    double projectileSizeModifier = double.Parse(reader.ReadLine());

                    line = reader.ReadLine().Split(' ');
                    bool projectileSpreadIsMultiplier = bool.Parse(line[0]);
                    double projectileSpreadModifier = double.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    bool projectileHomingIsMultiplier = bool.Parse(line[0]);
                    double projectileHomingModifier = double.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    bool shieldHealthIsMultiplier = bool.Parse(line[0]);
                    double shieldHealthModifier = double.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    bool shieldRegenIsMultiplier = bool.Parse(line[0]);
                    double shieldRegenModifier = double.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    bool shieldCooldownIsMultiplier = bool.Parse(line[0]);
                    double shieldCooldownModifier = double.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    bool healthIsMultiplier = bool.Parse(line[0]);
                    double healthModifier = double.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    bool healthRegenIsMultiplier = bool.Parse(line[0]);
                    double healthRegenModifier = double.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    bool knockbackIsMultiplier = bool.Parse(line[0]);
                    double knockbackModifier = double.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    bool knockbackResistIsMultiplier = bool.Parse(line[0]);
                    double knockbackResistModifier = double.Parse(line[1]);

                    bool additionalJump = bool.Parse(reader.ReadLine());

                    string iconPath = reader.ReadLine();
                    int weight = int.Parse(reader.ReadLine());
                    int cost = int.Parse(reader.ReadLine());

                    upgrades.Add(new Upgrade(
                        damageIsMultiplier,
                        damageModifier,
                        projectileCountIsMultiplier,
                        projectileCountModifier,
                        rateOfFireIsMultiplier,
                        rateOfFireModifier,
                        projectileSpeedIsMultiplier,
                        projectileSpeedModifier,
                        projectileSizeModifier,
                        projectileSpreadIsMultiplier,
                        projectileSpreadModifier,
                        projectileHomingIsMultiplier,
                        projectileHomingModifier,
                        shieldHealthIsMultiplier,
                        shieldHealthModifier,
                        shieldRegenIsMultiplier,
                        shieldRegenModifier,
                        shieldCooldownIsMultiplier,
                        shieldCooldownModifier,
                        healthIsMultiplier,
                        healthModifier,
                        healthRegenIsMultiplier,
                        healthRegenModifier,
                        knockbackIsMultiplier,
                        knockbackModifier,
                        knockbackResistIsMultiplier,
                        knockbackResistModifier,
                        additionalJump,
                        Program.game.Content.Load<Texture2D>("UpgradeIcons/" + iconPath.Substring(0, iconPath.Length-4)),
                        name,
                        description.Substring(0, description.Length - 2),
                        weight,
                        cost));
                    //
                } while (reader.ReadLine() != "|||");



            } catch (Exception)
            {
                throw;
            }
            if (reader != null)
            {
                reader.Close();
            }
        }


    }
}
