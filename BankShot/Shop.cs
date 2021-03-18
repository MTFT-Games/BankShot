using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BankShot
{
    class Shop : GameObject, IMovable
    {
        //Fields
        private Upgrade[] forSale;
        private UpgradeManager manager;

        //Methods
        public void EnterScreen() { }
        
        public void ExitScreen() { }

        //These methods have not been explicitly defined:

        //Tell the upgrade manager to span another, end, or apply a bought upgrade

        // Check for player in front of upgrade and display info

        //Check for confirmation while player is in front of upgrade
    }
}
