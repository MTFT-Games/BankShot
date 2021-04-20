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
    public class MainMenu
    {
        //fields for spritefont and button rectangles
        private SpriteFont font;
        private Rectangle startBtn;
        private Rectangle exitBtn;
        Texture2D buttonTx;


        public MainMenu(SpriteFont f, Texture2D tx)
        {
            font = f;
            buttonTx = tx;
            startBtn = new Rectangle(200, 200, 100, 50);
            exitBtn = new Rectangle(200, 300, 100, 50);
        }

        public void Draw(SpriteBatch sb, GraphicsDeviceManager g)
        {
            //draws game title
            sb.DrawString(font,
                "BANK SHOT",
                new Vector2(350,
               100),
                Color.White);
            //button textures to be incorporated
            //start button
            sb.Draw(buttonTx, startBtn, Color.White);
            //exit button
            sb.Draw(buttonTx, exitBtn, Color.White);
            //writes text over buttons(will be gotten rid of once buttons 
            //textures created
            //start button text
            sb.DrawString(font, 
                "START",
                new Vector2(200,200),
                Color.White);
            //exit button text
            sb.DrawString(font,
               "EXIT",
               new Vector2(200, 300),
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
            if(SingleClick(ms.LeftButton, ms, msPrev) && mousePosition.Intersects(startBtn))
            {
                //changes game state to game mode
                state = GameState.Game;

            }
            else
            {
                state = GameState.MainMenu;
            }
            if (SingleClick(ms.LeftButton, ms, msPrev) && mousePosition.Intersects(exitBtn))
            {
                //exits game
                Program.game.Exit();
               
            }
        }

       // public void resetGame()
            //RESETS ALL GAME VALUES



    }
}
