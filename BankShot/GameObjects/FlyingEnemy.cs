using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot.GameObjects
{
    class FlyingEnemy : Enemy
    {
        //Fields
        private int speed;
        private Gun gun;
        private double reloadTime;
        private double elapsedTime;
        public FlyingEnemy(Texture2D texture, Rectangle rect, List<Rectangle> collisionBoxes, bool active,
                           int maxHealth, Vector2 velocity, int attackPower, float knockbackDistance, int money,
                           int speed, Gun gun, double reloadTime) :
                           base(texture, rect, collisionBoxes, active, maxHealth, velocity,
                                attackPower, knockbackDistance, money)
        {
            this.speed = speed;
            this.reloadTime = reloadTime;
            elapsedTime = 0;
        }
        public void Update(GameTime gameTime)
        {
            base.Update();
            this.Attack(gameTime);
            gun.X = this.X + this.Rect.Width / 2;
            gun.Y = this.Y + this.Rect.Height / 2;
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
        }
        public void Move(GameTime gameTime)
        {
            Pathfind(Game1.player, gameTime);//find player
            base.Move();
            ResolveCollisions();
        }
        /// <summary>
        /// Sets velocity in the direction of the player
        /// <param name="target"></param>
        public void Pathfind(GameObject target, GameTime gameTime)
        {
            //determines difference between enemy Xposition and target Xposition
            int distanceX = this.X - target.X;

            if (Math.Abs(distanceX) < 40)
            {
                //Determines whether target is to the left or the right of the enemy
                if (distanceX < -5)//target is to the left of enemy
                {
                    velocity.X = speed;
                    this.leftFacing = false;
                }
                else if (distanceX > 5)//target is to the right of enemy
                {
                    velocity.X = -1 * speed;
                    this.leftFacing = true;
                }
                else
                {
                    X = Game1.player.X;
                    velocity.X = 0;
                }
                if (distanceX < 20)
                {
                    this.Attack(gameTime);
                }
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
    }
}
