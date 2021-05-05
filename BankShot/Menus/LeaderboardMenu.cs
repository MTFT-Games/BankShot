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
        private int currentScore;
        int[] scores;



        public LeaderboardMenu(SpriteFont f, int[] s, int score)
        {
            font = f;
            mainmenuBtn = new Rectangle(200, 400, 100, 50);
            scores = s;
            currentScore = score;

        }

        public void Draw(SpriteBatch sb, GraphicsDeviceManager g, Texture2D buttonTx)
        {
            //draws leaderbaord
            sb.DrawString(font,
                $"LEADERBOARD\n" +
                $"1: {scores[5]}\n" +
                $"2: {scores[4]}\n" +
                $"3: {scores[3]}\n" +
                $"4: {scores[2]}\n" +
                $"5: {scores[1]}\n\n" +
                $"This attempts score: {currentScore}",
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


        public void Update(out GameState state)
        {
            if (Input.MouseClick(1) && mainmenuBtn.Contains(Input.MousePosition))
            {
                //changes game state to main menu mode
                state = GameState.MainMenu;
                Program.game.resetGame();
            } else
            {
                state = GameState.Leaderboard;
            }

        }



    }
}
