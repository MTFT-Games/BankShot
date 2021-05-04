using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BankShot
{
    public class Shop : GameObject, IMoveable
    {
        //Fields
        private Upgrade[] forSale;
        protected Vector2 velocity;
        private Rectangle upgrade1Rect;
        private Rectangle upgrade2Rect;
        private Rectangle upgrade3Rect;
        private Rectangle rerollRect;
        private Rectangle exitRect;
        private bool leaving;
        private static Texture2D shopWindow;
        public static Texture2D shopTexture;
        private Random rng;
        private bool rerollable;
        

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
        public Shop(int whereToDrive, List<Rectangle> collisionBoxes, bool active, Upgrade[] sale)
            : base(shopTexture, new Rectangle(whereToDrive, 960 - MapManager.tileSize - 145, 200, 145), collisionBoxes, active)
        {
            forSale = sale;
            upgrade1Rect = new Rectangle(rect.X + (rect.Width / 2) - 200, rect.Y - 580, 100, 100);
            upgrade2Rect = new Rectangle(rect.X + (rect.Width / 2) - 50, rect.Y - 580, 100, 100);
            upgrade3Rect = new Rectangle(rect.X + (rect.Width / 2) + 100, rect.Y - 580, 100, 100);
            rerollRect = new Rectangle(rect.X + (rect.Width / 2) + 50, rect.Y - 200, 100, 100);
            exitRect = new Rectangle(rect.X + (rect.Width / 2) -150, rect.Y - 200, 100, 100);
            rng = new Random();
            rerollable = true;

            leaving = false;
        }

        public void ExitScreen()
        {
            leaving = true;
        }

        //These methods have not been explicitly defined:

        //Tell the upgrade manager to span another, end, or apply a bought upgrade

        // Check for player in front of upgrade and display info

        //Check for confirmation while player is in front of upgrade

        public void Draw(SpriteBatch sb)
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

            if (Game1.player.Rect.Intersects(rect))
            {
                sb.Draw(
                    shopWindow,
                    new Rectangle((int)Position.X + (rect.Width / 2) - 250, (int)position.Y - 600, 500, 600),
                    Color.White);

                Color hoverExit = Color.White;

                if (msLoc.Intersects(exitRect))
                {
                    hoverExit = Color.Red;
                }

                Color hoverReroll = Color.White;

                if (msLoc.Intersects(rerollRect))
                {
                    hoverReroll = Color.Red;
                }

                sb.Draw(
                Game1.buttonTx,
                exitRect,
                hoverExit);

                sb.DrawString(Game1.font, "EXIT", new Vector2(exitRect.X + 25, exitRect.Y + 40), Color.White);

                if (msLoc.Intersects(upgrade1Rect))
                {
                    colorUp1 = Color.Gold;
                    sb.DrawString(Program.game.Font, forSale[0].name, new Vector2(rect.X + (rect.Width / 2) - 240, Y - 460), Color.White);
                    sb.DrawString(Program.game.Font, forSale[0].description, new Vector2(rect.X + (rect.Width / 2) - 240, Y - 440), Color.White);
                    sb.DrawString(Program.game.Font, $"Cost: {forSale[0].cost}", new Vector2(rect.X + (rect.Width / 2) - 240, Y - 480), Color.White);

                }

                if (msLoc.Intersects(upgrade2Rect))
                {
                    colorUp2 = Color.Gold;
                    sb.DrawString(Program.game.Font, forSale[1].name, new Vector2(rect.X + (rect.Width / 2) - 240, Y - 460), Color.White);
                    sb.DrawString(Program.game.Font, forSale[1].description, new Vector2(rect.X + (rect.Width / 2) - 240, Y - 440), Color.White);
                    sb.DrawString(Program.game.Font, $"Cost: {forSale[1].cost}", new Vector2(rect.X + (rect.Width / 2) - 240, Y - 480), Color.White);
                }

                if (msLoc.Intersects(upgrade3Rect))
                {
                    colorUp3 = Color.Gold;
                    sb.DrawString(Program.game.Font, forSale[2].name, new Vector2(rect.X + (rect.Width / 2) - 240, Y - 460), Color.White);
                    sb.DrawString(Program.game.Font, forSale[2].description, new Vector2(rect.X + (rect.Width / 2) - 240, Y - 440), Color.White);
                    sb.DrawString(Program.game.Font, $"Cost: {forSale[2].cost}", new Vector2(rect.X + (rect.Width / 2) - 240, Y - 480), Color.White);
                }

                sb.Draw(Game1.buttonTx, rerollRect, hoverReroll);
                sb.DrawString(Game1.font, "REROLL", new Vector2(rerollRect.X + 25, rerollRect.Y + 40), Color.White);
                sb.Draw(forSale[0].icon, upgrade1Rect, colorUp1);
                sb.Draw(forSale[1].icon, upgrade2Rect, colorUp2);
                sb.Draw(forSale[2].icon, upgrade3Rect, colorUp3);
                // break;
            }


        }

        public virtual void Move()
        {
            position += velocity;
        }

        public override void Update()
        {
            Rectangle msLoc = new Rectangle(Input.MousePosition.ToPoint(), new Point(1, 1));

            //check cost with player wallet

            //calls apply upgrade upon clicking on a chosen upgrade

            if (Input.MouseClick(1) && msLoc.Intersects(upgrade1Rect))
            {
                Game1.upgradeManager.ApplyUpgrade(forSale[0], Game1.player);
            }

            if (Input.MouseClick(1) && msLoc.Intersects(upgrade2Rect))
            {
                Game1.upgradeManager.ApplyUpgrade(forSale[1], Game1.player);
            }

            if (Input.MouseClick(1) && msLoc.Intersects(upgrade3Rect))
            {
                Game1.upgradeManager.ApplyUpgrade(forSale[2], Game1.player);
            }

            if (Input.MouseClick(1) && msLoc.Intersects(exitRect))
            {
                
                    Game1.upgradeManager.EndShopping();
                
            }

            if(Input.MouseClick(1) && msLoc.Intersects(rerollRect))
            {
                if (Game1.player.Money > 100)
                {
                    Game1.player.Money -= 100;
                    Game1.upgradeManager.MakeShop();
                }

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
