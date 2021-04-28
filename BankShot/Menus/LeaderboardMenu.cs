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
    /// PURPOSE: to manage the drawing and logic of the main menu
    /// </summary>
    class LeaderboardMenu
    {
        //fields for spritefont and button rectangles
        private SpriteFont font;
        private Rectangle mainmenuBtn;
        int[] scores;



        public LeaderboardMenu(SpriteFont f, int[] s)
        {
            font = f;
            mainmenuBtn = new Rectangle(200, 400, 100, 50);
            scores = s;


        }

        public void Draw(SpriteBatch sb, GraphicsDeviceManager g, Texture2D buttonTx)
        {
            //draws leaderbaord
            sb.DrawString(font,
                $"LEADERBOARD\n" +
                $"1: {scores[0]}\n" +
                $"2: {scores[1]}\n" +
                $"3: {scores[2]}\n" +
                $"4: {scores[3]}\n" +
                $"5: {scores[4]}\n",
                new Vector2(g.PreferredBackBufferWidth / 2,
                g.PreferredBackBufferHeight / 2),
                Color.White);

            //button textures to be incorporated
            //main menu button
            sb.Draw(buttonTx, mainmenuBtn, Color.White);

            //writes text over buttons(will be gotten rid of once buttons 
            //textures created
            //main menu button text
            sb.DrawString(font,
                "RETURN TO MENU",
                new Vector2(200, 400),
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
            if (SingleClick(ms.LeftButton, ms, msPrev) && mousePosition.Intersects(mainmenuBtn))
            {
                //changes game state to main menu mode
                state = GameState.MainMenu;
            } else
            {
                state = GameState.Leaderboard;
            }

        }



    }
}
