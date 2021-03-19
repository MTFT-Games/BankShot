using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    public static class Input
    {
        //Fields
        public static KeyboardState kbState = Keyboard.GetState();
        public static KeyboardState kbStatePrev;
        public static MouseState mouseState = Mouse.GetState();
        public static MouseState mouseStatePrev;

        //Properties
        public static Point MousePosition
        {
            get
            {
                return mouseState.Position;
            }
        }

        //Methods
        public static void Update()
        {
            kbStatePrev = kbState;
            mouseStatePrev = mouseState;
            kbState = Keyboard.GetState();
            mouseState = Mouse.GetState();
        }

        public static bool KeyClick(Keys key)
        {
            if (kbState.IsKeyDown(key) && !kbStatePrev.IsKeyDown(key))
            {
                return true;
            }
            return false;
        }

        public static bool KeyHeld(Keys key)
        {
            if (kbState.IsKeyDown(key) && kbStatePrev.IsKeyDown(key))
            {
                return true;
            }
            return false;
        }
    }
}
