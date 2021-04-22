using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    class RangedEnemy : Enemy
    {
        private Gun gun;
        private double reloadTime;
        private double elapsedTime;
        private int range;
        public RangedEnemy(Texture2D texture, Rectangle rect, List<Rectangle> collisionBoxes, bool active,
            int maxHealth, Vector2 velocity, int attackPower, float knockbackDistance, int money, Gun gun, double reloadTime, int range)
            : base(texture, rect, collisionBoxes, active, maxHealth, velocity, attackPower, knockbackDistance, money)
        {
            this.gun = gun;
            this.reloadTime = reloadTime;
            this.elapsedTime = 0;
            this.range = range;
        }

        public void Update(GameTime gameTime)
        {
            base.Update();
            this.Attack(gameTime);
            gun.X = this.X + this.Rect.Width / 2;
            gun.Y = this.Y + this.Rect.Height / 2;
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Attack(GameTime gameTime)
        {
            int distance = (int)Math.Sqrt(Math.Pow(this.X - Game1.player.X, 2) +
               Math.Pow(this.Y - Game1.player.Y, 2));
            if (elapsedTime >= reloadTime &&
               distance <= range)
            {
                Vector2 vector = Game1.player.Position - this.position;
                //vector.Y = 0;
                vector.Normalize();
                gun.Attack(vector);
                elapsedTime = 0;
                if (vector.X > 0)
                {
                    leftFacing = false;
                }
                else if (vector.X < 0)
                {
                    leftFacing = true;
                }
            }
        }

        public override void Move()
        {
            velocity += new Vector2(0, 1);//apply gravity
            position += velocity;
            ResolveCollisions();
            velocity.X = 0;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (leftFacing)
            {
                spriteBatch.Draw(texture, rect, Color.Red);
            }
            else
            {
                spriteBatch.Draw(texture, rect, null, Color.Red, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 1);
            }
        }

        public override void TakeDamage(int damage, float knockback, GameObject damageDealer)
        {
            health -= damage;
            if (health < 0)
            {
                health = 0;
            }
        }
    }
}
