using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BankShot
{
    class Shop : GameObject, IMoveable
    {
        //Fields
        private Upgrade[] forSale;
        private UpgradeManager manager;
        private bool drawn;
        protected Vector2 velocity;

        //Properties
        public Vector2 Velocity
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }

        //Methods
        /// <summary>
        /// Creates the shop by calling its draw method and moving it onto screen
        /// </summary>
        /// 

        public Shop(Texture2D texture, Rectangle transform, List<Rectangle> collisionBoxes, bool active)
            : base(texture, transform, collisionBoxes, active)
        {
            forSale = new Upgrade[3];
            manager = new UpgradeManager();
            rect = new Rectangle(new Point(-100, 40), new Point(50, 50));

        }

        public void EnterScreen(SpriteBatch sb, Color c)
        {
            if(!drawn)
            Draw(sb, c);

            while (rect.X != 100)
            {
                rect.X++;
            }
           
        }
        
        public void ExitScreen() 
        {
            while (rect.X != -100)
            {
                rect.X--;
            }

        }

        //These methods have not been explicitly defined:

        //Tell the upgrade manager to span another, end, or apply a bought upgrade

        // Check for player in front of upgrade and display info

        //Check for confirmation while player is in front of upgrade

        public void Draw(SpriteBatch sb, Color c)
        {
            sb.Draw(texture, rect, Color.White);
            drawn = true;
        }

        public void Move() { }
    }
}
