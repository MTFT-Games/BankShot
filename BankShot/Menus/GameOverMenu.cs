using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    /// <summary>
    /// AUTHOR: AIDAN VANBURGER
    /// PURPOSE: to manage the drawing and logic of the game over menu
    /// </summary>
    class GameOverMenu
    {
        //fields for spritefont and button rectangles
        private SpriteFont font;
        private Rectangle menuBtn;
        private Rectangle leaderBtn;


        public GameOverMenu(SpriteFont f)
        {
            font = f;
            menuBtn = new Rectangle(200, 400, 100, 50);
            leaderBtn = new Rectangle(200, 550, 100, 50);
        }

        public void Draw(SpriteBatch sb, GraphicsDeviceManager g, Texture2D buttonTx)
        {
            //draws game over title
            sb.DrawString(font,
                "GAME OVER",
                new Vector2(g.PreferredBackBufferWidth / 2,
                g.PreferredBackBufferHeight / 2),
                Color.White);
            //button textures to be incorporated
            //main menu button
            sb.Draw(buttonTx, menuBtn, Color.White);
            //leaderboard button
            sb.Draw(buttonTx, leaderBtn, Color.White);
            //writes text over buttons(will be gotten rid of once buttons 
            //textures created
            //main menu button text
            sb.DrawString(font,
                "MAIN MENU",
                new Vector2(200, 400),
                Color.White);
            //leaderboard button text
            sb.DrawString(font,
               "LEADERBOARD",
               new Vector2(200, 550),
               Color.White);
        }

        /// <summary>
        /// checks for single mouse click
        /// </summary>
        /// <param name="clicked"></param>
        /// <param name="ms"></param>
        /// current mouse state
        /// <param name="msPrev"></param>
        /// previous mouse state
        /// <returns></returns>
        public bool SingleClick(ButtonState clicked, MouseState ms, MouseState msPrev)
        {
            //if the button was clicked, and there was no mouse buttons
            //pressed in the previous state, returns true
            if (clicked == ButtonState.Pressed &&
                msPrev.LeftButton != ButtonState.Pressed &&
                msPrev.RightButton != ButtonState.Pressed)
            {
                return true;
            }
            //returns false otherwise
            return false;

        }

        public void Update(KeyboardState kbs, MouseState ms, MouseState msPrev, out GameState state)
        {
            Rectangle mousePosition = new Rectangle(ms.X, ms.Y, 1, 1);
            if (SingleClick(ms.LeftButton, ms, msPrev) && mousePosition.Intersects(menuBtn))
            {
                //changes game state to main menu
                state = GameState.MainMenu;
            }
            
            if (SingleClick(ms.LeftButton, ms, msPrev) && mousePosition.Intersects(leaderBtn))
            {
                //changes game state to leaderboard
                state = GameState.Leaderboard;
            }
            else
            {
                state = GameState.GameOver;
            }
        }

       



    }
}
