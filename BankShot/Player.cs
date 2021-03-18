using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    class Player : Character
    {
        //Fields
        private Mobility mobility;
        private Weapon weapon;
        private Shield shield;

        //Player Stats will also be included as Fields

        //Default Contructor
        public Player(int maxHealth, Vector2 velocity) : base(maxHealth, velocity) { }

        //Methods
        public override void Update()
        {
            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Move()
        {
            base.Move();
        }

        //The collison checking method in GameObject might
        //also be overridden here.
    }
}
