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
    /// PURPOSE: to manage the drawing and logic of the pause menu
    /// </summary>
    class PauseMenu
    {
        //fields for spritefont and button rectangles
        private SpriteFont font;
        private Rectangle resumeBtn;
        private Rectangle testBtn;
        private Texture2D buttonTx;
        //field that follows game1's test mode bool
        //used to determine text shown on test mode button
        bool testingStatus;



        public PauseMenu(SpriteFont f, Texture2D tx)
        {
            font = f;
            resumeBtn = new Rectangle(200, 200, 100, 50);
            testBtn = new Rectangle(200, 300, 200, 50);
            testingStatus = false;
            buttonTx = tx;
        }

        public void Draw(SpriteBatch sb, GraphicsDeviceManager g)
        {
            //draws pause title
            sb.DrawString(font,
                "PAUSED",
                new Vector2(g.PreferredBackBufferWidth / 2,
                g.PreferredBackBufferHeight / 2),
                Color.White);
            //button textures to be incorporated
            //resume button
            sb.Draw(buttonTx, resumeBtn, Color.White);
            //test button
            sb.Draw(buttonTx, testBtn, Color.White);
            //writes text over buttons(will be gotten rid of once buttons 
            //textures created
            //resume button text
            sb.DrawString(font,
                "RESUME",
                new Vector2(215, 215),
                Color.White);
            //test button text
            string testButtonText = "ENABLE TESTING MODE";
            if (Program.game.Test)
            {
                testButtonText = "DISABLE TESTING MODE";
            }
            sb.DrawString(font,
               testButtonText,
               new Vector2(215, 315),
               Color.White);

            //player stats
            if (Game1.player.CurrentWeapon is Gun)
            {
                Gun currentGun = (Gun)Game1.player.CurrentWeapon;

                sb.DrawString(
                    font,
                    "Weapon Power: " + currentGun.Damage +
                    "\nShot Speed: " + currentGun.Speed,
                    new Vector2(800, 300),
                    Color.White
                    );
            }
        }

        public void Update(bool testingMode, out GameState state)
        {
            if (Input.MouseClick(1) && resumeBtn.Contains(Input.MousePosition))
            {
                //resumes game (TO BE TUNED TO FIT ENUMERATOR)
                state = GameState.Game;
            } else
            {
                state = GameState.Pause;
            }
            if (Input.MouseClick(1) && testBtn.Contains(Input.MousePosition))
            {

                //enables/disables testing mode
                if (Program.game.Test)
                {
                    Program.game.Test = false;
                } else if (!Program.game.Test)
                {
                    Program.game.Test = true;

                }


            }
        }



    }
}
