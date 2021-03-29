using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    class UpgradeManager
    {
        //fields

        private List<Upgrade> upgrades;
        private int totalWeight;
        private List<Shop> shops;

        //constructor------------------------------------------------------------------------------
        public UpgradeManager()
        {


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


        }

        public void ApplyUpgrades(Upgrade upgrade)
        {
            //takes in an upgrade and applies it to the Player

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
