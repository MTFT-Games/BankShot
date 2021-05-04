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
        //Properties
        public Gun Gun
        {
            get { return gun; }
        }

        public double ReloadTime
        {
            get { return reloadTime; }
        }

        public int Range
        {
            get { return range; }
        }
        //Constructors
        public RangedEnemy(Texture2D texture, Rectangle rect, List<Rectangle> collisionBoxes, bool active,
            int maxHealth, Vector2 velocity, int attackPower, float knockbackDistance, int money, Gun gun, double reloadTime, int range)
            : base(texture, rect, collisionBoxes, active, maxHealth, velocity, attackPower, knockbackDistance, money)
        {
            this.gun = gun;
            this.reloadTime = reloadTime;
            elapsedTime = 0;
            this.range = range;
        }

        public RangedEnemy(RangedEnemy template, Vector2 position)
            : base(template, position)
        {
            gun = template.Gun;
            reloadTime = template.ReloadTime;
            elapsedTime = 0;
            range = template.Range;
        }
        //Methods
        public void Update(GameTime gameTime)
        {
            base.Update();
            Attack(gameTime);
            gun.X = X + Rect.Width / 2;
            gun.Y = Y + Rect.Height / 2;
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Attack(GameTime gameTime)
        {
         
            int distance = (int)Math.Sqrt(Math.Pow(X - Game1.player.X, 2) +
               Math.Pow(Y - Game1.player.Y, 2));
            if (elapsedTime >= reloadTime &&
               distance <= range)
            {
                Vector2 vector = Game1.player.Position - position;
                //vector.Y = 0;
                vector.Normalize();
                gun.Attack(vector);
                if (Game1.waveManager.Wave > 5)
                {
                    Vector2 perp = new Vector2(vector.Y * -1, vector.X);
                    Vector2 leftVect = Game1.player.Position + (perp * 75);
                    Vector2 rightVect = Game1.player.Position + (-1 * perp * 75);
                    leftVect = leftVect - position;
                    rightVect = rightVect - position;
                    leftVect.Normalize();
                    rightVect.Normalize();
                    
                    gun.Attack(leftVect);
                    gun.Attack(rightVect);
                    if (Game1.waveManager.Wave > 12)
                    {
                        leftVect = Game1.player.Position + (perp * 75 * 2);
                        rightVect = Game1.player.Position + (-1 * perp * 75 * 2);
                        leftVect = leftVect - position;
                        rightVect = rightVect - position;
                        leftVect.Normalize();
                        rightVect.Normalize();
                        gun.Attack(leftVect);
                        gun.Attack(rightVect);
                    }
                }
                elapsedTime = 0;
                if (vector.X > 0)
                {
                    leftFacing = false;
                } else if (vector.X < 0)
                {
                    leftFacing = true;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (leftFacing)
            {
                spriteBatch.Draw(texture, rect, Color.White);
            } else
            {
                spriteBatch.Draw(texture, rect, null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 1);
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
