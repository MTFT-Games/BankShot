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

        public void Draw(SpriteBatch sb, GraphicsDeviceManager g)
        {
            //draws game over title
            sb.DrawString(font,
                "GAME OVER",
                new Vector2(g.PreferredBackBufferWidth / 2,
                g.PreferredBackBufferHeight / 2),
                Color.White);
            //button textures to be incorporated
            //main menu button
            sb.Draw(null, menuBtn, Color.White);
            //leaderboard button
            sb.Draw(null, leaderBtn, Color.White);
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

        public void Update(KeyboardState kbs, MouseState ms, out GameState state)
        {
            Rectangle mousePosition = new Rectangle(ms.X, ms.Y, 1, 1);
            if (ms.LeftButton == ButtonState.Pressed && mousePosition.Intersects(menuBtn))
            {
                //changes game state to main menu
                state = GameState.MainMenu;
            }
            
            if (ms.LeftButton == ButtonState.Pressed && mousePosition.Intersects(leaderBtn))
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
