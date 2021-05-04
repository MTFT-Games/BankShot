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

        //Properties
        public int Speed
        {
            get { return speed; }
        }
        //Constructor
        public ChaserEnemy(Texture2D texture, Rectangle rect, bool active,
                           int maxHealth, Vector2 velocity, int attackPower, float knockbackDistance, int money,
                           int speed) :
                           base(texture, rect, active, maxHealth, velocity,
                                attackPower, knockbackDistance, money)
        {
            this.speed = speed;
        }

        public ChaserEnemy(ChaserEnemy template, Vector2 position)
            : base(template, position)
        {
            speed = template.Speed;
        }
        //Methods
        /// <summary>
        /// Sets velocity in the direction of the player
        /// <param name="target"></param>
        public override void Pathfind(GameObject target)
        {
            //determines difference between enemy Xposition and target Xposition
            int distanceX = X - target.X;

            if (Math.Abs(distanceX) < 800)
            {
                //Determines whether target is to the left or the right of the enemy
                if (distanceX < -5)//target is to the left of enemy
                {
                    velocity.X = speed;
                    leftFacing = false;
                }
                else if (distanceX > 5)//target is to the right of enemy
                {
                    velocity.X = speed * -1;
                    leftFacing = true;
                }
                else
                {
                    X = Game1.player.X;
                    velocity.X = 0;
                }
            }
        }
    }
}
