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

        public void Update(KeyboardState kbs, MouseState ms, MouseState msPrev, bool testingMode, out GameState state)
        {
            Rectangle mousePosition = new Rectangle(ms.X, ms.Y, 1, 1);
            if (SingleClick(ms.LeftButton, ms, msPrev) && mousePosition.Intersects(resumeBtn))
            {
                //resumes game (TO BE TUNED TO FIT ENUMERATOR)
                state = GameState.Game;
            }
            else
            {
                state = GameState.Pause;
            }
            if (SingleClick(ms.LeftButton, ms, msPrev) && mousePosition.Intersects(testBtn))
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
