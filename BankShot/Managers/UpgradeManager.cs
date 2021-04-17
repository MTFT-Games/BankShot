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



        //constructor------------------------------------------------------------------------------
        public UpgradeManager(Texture2D damageTexture, Texture2D speedTexture, Texture2D healthTexture,
            Texture2D textureForShop, Rectangle transformForShop, List<Rectangle> collisionBoxesForShop,
            bool activeForShop)
        {
            upgrades = new List<Upgrade>();

            Upgrade upgrade1 = new Upgrade(true, 200,
               false, 0,
               false, 0,
               false, 0, 0,
               false, 0,
               false, 0,
               false, 0,
               false, 0,
               false, 0,
               false, 0,
               false, 0,
               false, 0,
               false, 0,
                 damageTexture,
                "Damage Boost", 
                "Doubles damage done by player",
                1);

            upgrades.Add(upgrade1);

            Upgrade upgrade2 = new Upgrade(
                false, 0,
               false, 0, 
               false, 0,
               true, 1.50f, 1,
               false, 0,
               false, 0,
               false, 0, 
               false, 0,
               false, 0,
               false, 0,
               false, 0, 
               false, 0, 
               false, 0,
               speedTexture,
               "Projectile Boost",
               "Speeds up projectiles by 50%",
               1);

            upgrades.Add(upgrade2);

            Upgrade upgrade3 = new Upgrade(false, 0,
               false, 0,
               false, 0,
               false, 0, 0,
               false, 0,
               false, 0,
               false, 0,
               false, 0,
               false, 0,
               true, 150,
               false, 0,
               false, 0,
               false, 0,
               healthTexture,
               "Health Boost",
               "Increases max health by 50%",
               1);

            upgrades.Add(upgrade3);

            int tWeight = 0;
            foreach(Upgrade u in upgrades)
            {
                tWeight += u.weight;
            }
            totalWeight = tWeight;

            textureShop = textureForShop;
            transformShop = transformForShop;
            activeShop = activeForShop;
            shops = new List<Shop>();
            collisionBoxesShop = new List<Rectangle> { transformShop };


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
            shops.Add(new Shop(textureShop, transformShop, collisionBoxesShop, activeShop, upgrades));

        }


        public void EndShopping()
        {
            for (int i = 0; i < shops.Count; i++)
            {
                shops[i].ExitScreen();
            }

            Game1.waveManager.WaveBreak = false;
        }

        public void ApplyUpgrades(Upgrade upgrade, Player p)
        {
            //takes in an upgrade and applies it to the Player
            if (upgrade.damageIsMultiplier)
            {
                p.CurrentWeapon.Damage *= 2;

            }
            else
            {
                p.CurrentWeapon.Damage += 2;
            }

            if (upgrade.projectileCountIsMultiplier)
            {
                //not implemented yet
            }
            else
            {
                //not implemented yet
            }

            if (upgrade.rateOfFireIsMultiplier)
            {
                //not implemented yet
            }
            else
            {
                //not implemented yet
            }

            if (upgrade.projectileSpeedIsMultiplier)
            {
                Gun g = (Gun)p.CurrentWeapon;
                g.Speed *= upgrade.projectileSpeedModifier;
                p.CurrentWeapon = g;
            }
            else
            {
                Gun g = (Gun)p.CurrentWeapon;
                g.Speed += upgrade.projectileSpeedModifier;
                p.CurrentWeapon = g;
            }

            if (upgrade.projectileSpreadIsMultiplier)
            {
                //not implemented yet
            }
            else
            {
                //not implemented yet
            }

            if (upgrade.projectileHomingIsMultiplier)
            {
                //not implemented yet
            }
            else
            {
                //not implemented yet
            }

            if (upgrade.shieldHealthIsMultiplier)
            {
                //not implemented yet
            }
            else
            {
                //not implemented yet
            }

            if (upgrade.shieldRegenIsMultiplier)
            {
                //not implemented yet
            }
            else
            {
                //not implemented yet
            }

            if (upgrade.shieldCooldownIsMultiplier)
            {
                //not implemented yet
            }
            else
            {
                //not implemented yet
            }

            if (upgrade.healthIsMultiplier)
            {
                p.Health *= upgrade.healthModifier;
            }
            else
            {
                p.Health += upgrade.healthModifier;
            }

            if (upgrade.healthRegenIsMultiplier)
            {
                //not implemented yet
            }
            else
            {
                //not implemented yet
            }

            if (upgrade.knockbackIsMultiplier)
            {
                //not implemented yet
            }
            else
            {
                //not implemented yet
            }

            if (upgrade.knockbackIsMultiplier)
            {
                //not implemented yet
            }
            else
            {
                //not implemented yet
            }


        }


        public string ReadUpgrades()
        {
            //will return a string list of upgrades that are applied to the player
            return "";

        }


    }
}
