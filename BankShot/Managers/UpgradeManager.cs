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
            List<Upgrade> upgrades = new List<Upgrade>();

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

            Upgrade upgrade2 = new Upgrade(false, 0,
               false, 0, 
               false, 0,
               true, 150, 100,
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
               speedTexture,
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





        }

        //accessors. each get and set for now, subject to change ----------------------------------

        public List<Upgrade> Upgrades
        {
            //could use an indexed accessor?
            get { return upgrades; }
            set { upgrades = value; }
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

        public void MakeShop(Upgrade[] options)
        {
            //takes in an array of objects and creates an instance of "Shop" to be used by the player
            Shop newShop = new Shop(textureShop, transformShop, collisionBoxesShop, activeShop, upgrades);

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
                g.s
            }
            else
            {

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

            }
            else
            {

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

        public void EndShopping()
        {
            //called when player is done using the store, store will exit the frame and game will continue


        }

        public string ReadUpgrades()
        {
            //will return a string list of upgrades that are applied to the player
            return "";

        }


    }
}
