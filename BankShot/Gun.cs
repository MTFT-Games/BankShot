using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BankShot
{
    class Gun : Weapon
    {
        //Fields

        //Projectile Base Fields:

        //Projectile Stats:
        private bool interceptable;
        private double lifeSpan;
        private Vector2 velocity;
        private List<Projectile> projectiles; 

        //Parameterized Constructor
        public Gun(Texture2D texture, Rectangle transform,
                      List<Rectangle> collisionBoxes, bool active,
                      int damage, int knockback, bool interceptable, 
                      double lifeSpan, Vector2 velocity)
                      : base(texture, transform, collisionBoxes, 
                             active, damage, knockback)
        {
            this.interceptable = interceptable;
            this.lifeSpan = lifeSpan;
            this.velocity = velocity;
            projectiles = new List<Projectile>();
        }

        //Methods

        //Attack() will create a Projectile object
        //using the Gun's fields as parameters.
        public override void Attack() 
        { 
            //projectiles.Add(new Projectile())
            base.Attack(); 
        }
    }
}
