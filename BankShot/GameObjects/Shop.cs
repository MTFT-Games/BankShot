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
        /// Constructor
        /// </summary>
        /// 
        public Shop(Texture2D texture, Rectangle transform, List<Rectangle> collisionBoxes, bool active, List<Upgrade> sale)
            : base(texture, transform, collisionBoxes, active)
        {
            forSale = sale;
            upgrade1Rect = new Rectangle(100, 100, 50, 50);
            upgrade2Rect = new Rectangle(200, 100, 50, 50);
            upgrade3Rect = new Rectangle(150, 150, 50, 50);


        }


        //MOVED TO UPGRADE MANAGER
        public void Spawn(SpriteBatch sb, Color c)
        {
            

        }
        
        public void ExitScreen() 
        {
            while (position.X != -100)
            {
                position.X--;
            }

        }

        //These methods have not been explicitly defined:

        //Tell the upgrade manager to span another, end, or apply a bought upgrade

        // Check for player in front of upgrade and display info

        //Check for confirmation while player is in front of upgrade

        public void Draw(SpriteBatch sb, Color c, GameState state, MouseState ms)
        {
            //shows upgrades, uses manager readUpgrades method
            switch (state)
            {
                case GameState.Game:
                sb.Draw(texture, rect, Color.White);
                    break;
                case GameState.Shop:

                    Color colorUp1 = Color.White;
                    Color colorUp2 = Color.White;
                    Color colorUp3 = Color.White;

                    Rectangle msLoc = new Rectangle(ms.Position, new Point(1, 1));

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
                      
                    sb.Draw(forSale[0].icon, upgrade1Rect, colorUp1);
                    sb.Draw(forSale[1].icon, upgrade2Rect, colorUp2);
                    sb.Draw(forSale[2].icon, upgrade3Rect, colorUp3);

                    break;
            }

           
        }

        public virtual void Move()
        {
            position += velocity;
        }

        public void Update(UpgradeManager umg, MouseState ms, Player p)
        {
            Rectangle msLoc = new Rectangle(ms.Position, new Point(1, 1));

            //calls apply upgrade upon clicking on a chosen upgrade
            
            if(Input.MouseClick(1) && msLoc.Intersects(upgrade1Rect))
            {
                umg.ApplyUpgrades(forSale[0], p);
            }

            if (Input.MouseClick(1) && msLoc.Intersects(upgrade2Rect))
            {
                umg.ApplyUpgrades(forSale[1], p);
            }

            if (Input.MouseClick(1) && msLoc.Intersects(upgrade3Rect))
            {
                umg.ApplyUpgrades(forSale[2], p);
            }

        }
    }
}
