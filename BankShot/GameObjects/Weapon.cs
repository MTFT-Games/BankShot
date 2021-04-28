using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    public class Weapon : GameObject, IMoveable
    {
        //Fields
        protected int damage;
        protected float knockback;
        protected Vector2 velocity;

        //Properties
        public Vector2 Velocity
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }

        public int Damage
        {
            get
            {
                return damage;
            }
            set
            {
                damage = value;
            }
        }

        //Parameterized Constructor
        public Weapon(Texture2D texture, Rectangle transform,
                      List<Rectangle> collisionBoxes, bool active,
                      int damage, float knockback, bool fromEnemy)
                      : base(texture, transform, collisionBoxes, active)
        {
            this.damage = damage;
            this.knockback = knockback;
        }

        //Methods
        public virtual void Attack() { }

        public void Move()
        {
            position += velocity;
        }

        public override void Update()
        {
            Move();
            X = (int)position.X;
            Y = (int)position.Y;
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(
                texture,
                rect,
                null,
                Color.White,
                //(Input.MousePosition - Game1.player.Position).
                (float)Math.Atan2((Input.MousePosition - (Game1.player.Position + new Vector2(25.5f, 30.5f))).Y, (Input.MousePosition - Game1.player.Position).X),
                new Vector2(45.5f, 50.5f),
                SpriteEffects.None,
                0);

        }
    }
}
