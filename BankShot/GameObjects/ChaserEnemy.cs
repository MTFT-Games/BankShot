using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    class ChaserEnemy : Enemy
    {
        //Fields
        private int speed;
        public ChaserEnemy(Texture2D texture, Rectangle rect, List<Rectangle> collisionBoxes, bool active,
                           int maxHealth, Vector2 velocity, int attackPower, float knockbackDistance, int money, 
                           int speed) : 
                           base(texture, rect, collisionBoxes, active, maxHealth, velocity, 
                                attackPower, knockbackDistance, money)
        {
            this.speed = speed;
        }

        public override void Move()
        {
            base.Update();
            Pathfind(Game1.player);//find player
        }
        /// <summary>
        /// Sets velocity in the direction of the player
        /// <param name="target"></param>
        public void Pathfind(GameObject target)
        {
            //determines difference between enemy Xposition and target Xposition
            int distanceX = this.X - target.X;

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
        }
    }
}
