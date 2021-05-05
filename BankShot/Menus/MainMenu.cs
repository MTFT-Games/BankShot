using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

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
                new Vector2(225, 215),
                Color.White);
            //exit button text
            sb.DrawString(font,
               "EXIT",
               new Vector2(225, 315),
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

        public void Update(out GameState state)
        {
            if (Input.MouseClick(1) && startBtn.Contains(Input.MousePosition))
            {
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(Game1.song);
               
                MediaPlayer.Volume = .5f;
                //changes game state to game mode

                state = GameState.Game;
                

            } else
            {
                // TODO: Simplify this by making a property in Game1 and using that instead of an out.
                state = GameState.MainMenu;
            }
            if (Input.MouseClick(1) && exitBtn.Contains(Input.MousePosition))
            {
                //exits game
                Program.game.Exit();

            }
        }





    }
}
