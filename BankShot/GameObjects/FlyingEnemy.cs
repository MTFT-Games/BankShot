using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    class FlyingEnemy : Enemy
    {
        //Fields
        private int speed;
        private Gun gun;
        private double reloadTime;
        private double elapsedTime;
        //Properties
        public int Speed
        {
            get { return speed; }
        }

        public Gun Gun
        {
            get { return gun; }
        }

        public double ReloadTime
        {
            get { return reloadTime; }
        }
        //Constructors
        public FlyingEnemy(Texture2D texture, Rectangle rect, List<Rectangle> collisionBoxes, bool active,
                           int maxHealth, Vector2 velocity, int attackPower, float knockbackDistance, int money,
                           int speed, Gun gun, double reloadTime) :
                           base(texture, rect, collisionBoxes, active, maxHealth, velocity,
                                attackPower, knockbackDistance, money)
        {
            this.speed = speed;
            this.reloadTime = reloadTime;
            elapsedTime = 0;
            this.gun = gun;
        }

        public FlyingEnemy(FlyingEnemy template, Vector2 position)
            : base(template, position)
        {
            speed = template.Speed;
            reloadTime = template.ReloadTime;
            elapsedTime = 0;
            gun = template.Gun;
        }
        //Methods
        public void Update(GameTime gameTime)
        {
            ApplyKnockBack();
            Move(gameTime);
            DealDamage(Game1.player);
            X = (int)position.X;
            Y = (int)position.Y;
            truePosition.X = X + rect.Width / 2;
            truePosition.Y = Y + rect.Height / 2;
            gun.X = X + Rect.Width / 2;
            gun.Y = Y + Rect.Height / 2;
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
        }
        public void Move(GameTime gameTime)
        {
            ApplyKnockBack();
            Pathfind(Game1.player, gameTime);//find player
            position += velocity;
            ResolveCollisions(); 
        }
        /// <summary>
        /// Sets velocity in the direction of the player
        /// <param name="target"></param>
        public void Pathfind(GameObject target, GameTime gameTime)
        {
            //determines difference between enemy Xposition and target Xposition
            int distanceX = X - target.X;

                //Determines whether target is to the left or the right of the enemy
                if (distanceX < -5)//target is to the left of enemy
                {
                    velocity.X = speed;
                    leftFacing = false;
                } else if (distanceX > 5)//target is to the right of enemy
                {
                    velocity.X = -1 * speed;
                    leftFacing = true;
                } else
                {
                    X = Game1.player.X;
                    velocity.X = 0;
                }
                if (Math.Abs(distanceX) < 20)
                {
                    Attack(gameTime);
                }
        }
        public void Attack(GameTime gameTime)
        {

            if (elapsedTime >= reloadTime)
            {
                Vector2 vector = new Vector2(0, 1);
                gun.Attack(vector);
                elapsedTime = 0;
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!leftFacing)
            {
                spriteBatch.Draw(texture, rect, null, Color.DimGray, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 1);
            }
            else
            {
                spriteBatch.Draw(texture, rect, Color.DimGray);
            }
        }
    }
}
