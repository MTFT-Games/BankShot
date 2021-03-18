using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    class Weapon : GameObject, IMovable
    {
        //Fields
        private int damage;
        private int knockback;

        //Methods
        public virtual void Attack() { }

        public void Move() { }
    }
}
