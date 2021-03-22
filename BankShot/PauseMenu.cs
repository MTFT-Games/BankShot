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
        //field that follows game1's test mode bool
        //used to determine text shown on test mode button
        bool testingStatus;
        


        public PauseMenu(SpriteFont f)
        {
            font = f;
            resumeBtn = new Rectangle(200, 400, 100, 50);
            testBtn = new Rectangle(200, 550, 100, 50);
            testingStatus = false;
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
            sb.Draw(null, resumeBtn, Color.White);
            //test button
            sb.Draw(null, testBtn, Color.White);
            //writes text over buttons(will be gotten rid of once buttons 
            //textures created
            //resume button text
            sb.DrawString(font,
                "RESUME",
                new Vector2(200, 400),
                Color.White);
            //test button text
            string testButtonText = "ENABLE TESTING MODE";
            if (testingStatus)
            {
                testButtonText = "DISABLE TESTING MODE";
            }
            sb.DrawString(font,
               testButtonText,
               new Vector2(200, 550),
               Color.White);
        }

        public void Update(KeyboardState kbs, MouseState ms, bool testingMode, out GameState state)
        {
            Rectangle mousePosition = new Rectangle(ms.X, ms.Y, 1, 1);
            if (ms.LeftButton == ButtonState.Pressed && mousePosition.Intersects(resumeBtn))
            {
                //resumes game (TO BE TUNED TO FIT ENUMERATOR)
                state = GameState.Game;
            }
            else
            {
                state = GameState.Pause;
            }
            if (ms.LeftButton == ButtonState.Pressed && mousePosition.Intersects(testBtn))
            {
                //enables/disables testing mode
                if (testingMode)
                {
                    testingMode = false;
                   
                }
                if (!testingMode)
                {
                    testingMode = true;
                    
                }
                testingStatus = testingMode;

            }  
        }



    }
}
