﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    public class MainMenu
    {
        private SpriteFont font;
        private Rectangle startBtn;
        private Rectangle exitBtn;


        public MainMenu(SpriteFont f)
        {
            font = f;
            startBtn = new Rectangle(200, 400, 100, 50);
            exitBtn = new Rectangle(200, 550, 100, 50);
        }

        public void Draw(SpriteBatch sb, GraphicsDeviceManager g)
        {
            //draws game title
            sb.DrawString(font,
                "BANK SHOT",
                new Vector2(g.PreferredBackBufferWidth / 2,
                g.PreferredBackBufferHeight / 2),
                Color.White);
            //button textures to be incorporated
            //start button
            sb.Draw(null, startBtn, Color.White);
            //exit button
            sb.Draw(null, exitBtn, Color.White);
            //writes text over buttons(will be gotten rid of once buttons 
            //textures created
            //start button text
            sb.DrawString(font, 
                "START",
                new Vector2(200,400),
                Color.White);
            //exit button text
            sb.DrawString(font,
               "EXIT",
               new Vector2(200, 550),
               Color.White);
        }

        public void Update(KeyboardState kbs, MouseState ms) 
        {
            Rectangle mousePosition = new Rectangle(ms.X, ms.Y, 1, 1);
            if(ms.LeftButton == ButtonState.Pressed && mousePosition.Intersects(startBtn))
            {
                //changes game state to game mode
            }
            if (ms.LeftButton == ButtonState.Pressed && mousePosition.Intersects(exitBtn))
            {
                //exits game
            }
        }



    }
}
