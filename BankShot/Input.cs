using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    //Michael Robinson
    //Input
    //Stores both current and previous keyboard states,
    //as well as mouse states.
    //Also contains method to check for single key presses and held keys.
    public static class Input
    {
        //Fields
        public static KeyboardState kbState = Keyboard.GetState();
        public static KeyboardState kbStatePrev;
        public static MouseState mouseState = Mouse.GetState();
        public static MouseState mouseStatePrev;

        //Properties
        public static Vector2 MousePosition
        {
            get
            {
                return new Vector2(mouseState.Position.X, mouseState.Position.Y);
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

        //Checks for a single key pressed of a key
        //passed in as a parameter.
        public static bool KeyClick(Keys key)
        {
            if (kbState.IsKeyDown(key) && !kbStatePrev.IsKeyDown(key))
            {
                return true;
            }
            return false;
        }

        //Checks if a key, passed in as a parameter, is held
        public static bool KeyHeld(Keys key)
        {
            if (kbState.IsKeyDown(key) && kbStatePrev.IsKeyDown(key))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks for a single click of a mouse button 
        /// passed in as a parameter.
        /// 1 refers to the left mouse button.
        /// 2 refers to the right mouse button.
        /// If 1 or 2 is not passed, false is returned.
        /// </summary>
        /// <param name="mouseButton">Represents which mouse button 
        /// is being checked.</param>
        /// <returns></returns>
        public static bool MouseClick(int mouseButton)
        {
            switch (mouseButton)
            {
                case 1:
                    if (mouseState.LeftButton == ButtonState.Pressed &&
                        mouseStatePrev.LeftButton == ButtonState.Released)
                    {
                        return true;
                    }
                    return false;

                case 2:
                    if (mouseState.RightButton == ButtonState.Pressed &&
                        mouseStatePrev.RightButton == ButtonState.Released)
                    {
                        return true;
                    }
                    return false;

                default:
                    return false;
            }
        }

        /// <summary>
        /// Checks if a mouse button is held.
        /// The button is passed in as a parameter.
        /// 1 refers to the left mouse button.
        /// 2 refers to the right mouse button.
        /// If 1 or 2 is not passed, false is returned.
        /// </summary>
        /// <param name="mouseButton">Represents which mouse button 
        /// is being checked.</param>
        /// <returns></returns>
        public static bool MouseHeld(int mouseButton)
        {
            switch (mouseButton)
            {
                case 1:
                    if (mouseState.LeftButton == ButtonState.Pressed &&
                        mouseStatePrev.LeftButton == ButtonState.Pressed)
                    {
                        return true;
                    }
                    return false;

                case 2:
                    if (mouseState.RightButton == ButtonState.Pressed &&
                        mouseStatePrev.RightButton == ButtonState.Pressed)
                    {
                        return true;
                    }
                    return false;

                default:
                    return false;
            }
        }
    }
}
