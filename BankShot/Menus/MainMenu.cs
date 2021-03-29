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

        public void Update(KeyboardState kbs, MouseState ms, out GameState state) 
        {
            Rectangle mousePosition = new Rectangle(ms.X, ms.Y, 1, 1);
            if(ms.LeftButton == ButtonState.Pressed && mousePosition.Intersects(startBtn))
            {
                //changes game state to game mode
                state = GameState.Game;
            }
            else
            {
                state = GameState.MainMenu;
            }
            if (ms.LeftButton == ButtonState.Pressed && mousePosition.Intersects(exitBtn))
            {
                //exits game
                
            }
        }



    }
}
