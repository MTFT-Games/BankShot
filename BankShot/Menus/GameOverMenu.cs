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

        public void Update(out GameState state)
        {
            if (Input.MouseClick(1) && menuBtn.Contains(Input.MousePosition))
            {
                //changes game state to main menu
                state = GameState.MainMenu;
                Program.game.resetGame();
            } else if (Input.MouseClick(1) && leaderBtn.Contains(Input.MousePosition))
            {
                //changes game state to leaderboard
                state = GameState.Leaderboard;
            } else
            {
                state = GameState.GameOver;
            }

        }





    }
}
