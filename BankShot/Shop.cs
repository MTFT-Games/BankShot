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
        private Texture2D shopTx;
        private Rectangle rect;
        private bool drawn;

        //Methods
        /// <summary>
        /// Creates the shop by calling its draw method and moving it onto screen
        /// </summary>
        /// 

        public Shop(Texture2D tx)
        {
            shopTx = tx;
            forSale = new Upgrade[3];
            manager = new UpgradeManager();
            rect = new Rectangle(new Point(-100, 40), new Point(50, 50));

        }

        public void EnterScreen(SpriteBatch sb, Color c)
        {
            if(!drawn)
            Draw(sb, c);

           
            
        
        }
        
        public void ExitScreen() { }

        //These methods have not been explicitly defined:

        //Tell the upgrade manager to span another, end, or apply a bought upgrade

        // Check for player in front of upgrade and display info

        //Check for confirmation while player is in front of upgrade

        public void Draw(SpriteBatch sb, Color c)
        {
            sb.Draw(shopTx, shopLoc, Color.White);
            drawn = true;
        }

    }
}
