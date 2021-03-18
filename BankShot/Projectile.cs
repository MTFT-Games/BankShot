using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    class Projectile : GameObject, IMovable, IDamages
    {
        //Fields
        private bool interceptable;
        private int damage;
        private int knockback;
        private double lifeSpan;
        private Vector2 velocity;
        private bool fromEnemy;

        //Methods
        public void Move() { }

        public void DealDamage(IDamagable target)) { }
    }
}
