using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BankShot
{
    public class Shop : GameObject, IMoveable
    {
        //Fields
        private List<Upgrade> forSale;
        protected Vector2 velocity;
        private Rectangle upgrade1Rect;
        private Rectangle upgrade2Rect;
        private Rectangle upgrade3Rect;
        private bool leaving;
        private static Texture2D shopWindow;


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

        public static Texture2D ShopWindow
        {
            get { return shopWindow; }
            set { shopWindow = value; }
        }

        //Methods

        /// <summary>
        /// Constructor
        /// </summary>
        /// 
        public Shop(Texture2D texture, Rectangle transform, List<Rectangle> collisionBoxes, bool active, List<Upgrade> sale)
            : base(texture, transform, collisionBoxes, active)
        {
            forSale = sale;
            upgrade1Rect = new Rectangle(rect.X + (rect.Width / 2) - 200, rect.Y - 580, 100, 100);
            upgrade2Rect = new Rectangle(rect.X + (rect.Width / 2) - 50, rect.Y - 580, 100, 100);
            upgrade3Rect = new Rectangle(rect.X + (rect.Width / 2) + 100, rect.Y - 580, 100, 100);

            leaving = false;
        }


        //MOVED TO UPGRADE MANAGER
        public void Spawn(SpriteBatch sb, Color c)
        {
            

        }
        
        public void ExitScreen() 
        {
            leaving = true;
        }

        //These methods have not been explicitly defined:

        //Tell the upgrade manager to span another, end, or apply a bought upgrade

        // Check for player in front of upgrade and display info

        //Check for confirmation while player is in front of upgrade

        public override void Draw(SpriteBatch sb)
        {
            //shows upgrades, uses manager readUpgrades method
           // switch (state)
           // {
             //   case GameState.Game:
                sb.Draw(texture, rect, Color.White);
               //     break;
                //case GameState.Shop:

                    Color colorUp1 = Color.White;
                    Color colorUp2 = Color.White;
                    Color colorUp3 = Color.White;

                    Rectangle msLoc = new Rectangle(Input.MousePosition.ToPoint(), new Point(1, 1));

                    if (msLoc.Intersects(upgrade1Rect))
                    {
                        colorUp1 = Color.Gold;
                    }
                      
                    if (msLoc.Intersects(upgrade2Rect))
                    {
                        colorUp2 = Color.Gold;
                    }
                     
                    if (msLoc.Intersects(upgrade3Rect))
                    {
                        colorUp3 = Color.Gold;
                    }

            if (Game1.player.Rect.Intersects(rect))
            {
                sb.Draw(
                    shopWindow, 
                    new Rectangle((int)Position.X + (rect.Width / 2) - 250, (int)position.Y - 600, 500, 600),
                    Color.White);
                    sb.Draw(forSale[0].icon, upgrade1Rect, colorUp1);
                    sb.Draw(forSale[1].icon, upgrade2Rect, colorUp2);
                    sb.Draw(forSale[2].icon, upgrade3Rect, colorUp3);
            }

                   // break;
         //   }

           
        }

        public virtual void Move()
        {
            position += velocity;
        }

        public override void Update()
        {
            Rectangle msLoc = new Rectangle(Input.MousePosition.ToPoint(), new Point(1, 1));

            //calls apply upgrade upon clicking on a chosen upgrade
            
            if(Input.MouseClick(1) && msLoc.Intersects(upgrade1Rect))
            {
                Game1.upgradeManager.ApplyUpgrades(forSale[0], Game1.player);
            }

            if (Input.MouseClick(1) && msLoc.Intersects(upgrade2Rect))
            {
                Game1.upgradeManager.ApplyUpgrades(forSale[1], Game1.player);
            }

            if (Input.MouseClick(1) && msLoc.Intersects(upgrade3Rect))
            {
                Game1.upgradeManager.ApplyUpgrades(forSale[2], Game1.player);
            }

            if (Input.KeyClick(Keys.Tab))
            {
                Game1.upgradeManager.EndShopping();
            }
            if (leaving)
            {
                if (position.X > -100)
                {
                    //position = new Vector2(position.X - 5, position.Y);
                    position.X -= 5;
                    rect.X -= 5;
                } else
                {
                Game1.upgradeManager.Shops.Remove(this);
                }
            }
        }
    }
}
