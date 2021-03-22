using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    interface IMoveable
    {
        //movable objects must have a velocity, with set and get accessors
        Vector2 Velocity { get; set; }

        //movable objects must have a rectangle, with set and get accessors
        Rectangle Rect { get; set; }

        /// <summary>
        ///movable objects have a method that governs their movement
        /// </summary>
        void Move();

    }
}
