using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    class Enemy : Character, IDamages
    {
        //Fields
        
        //Enemy Stats will be included as Fields

        //Constructor
        public Enemy(Texture2D texture, Rectangle rect, List<Rectangle> collisionBoxes, bool active, int maxHealth, Vector2 velocity)
            : base(texture,rect,collisionBoxes,active,maxHealth,velocity)
        {

        }
        //Methods
        public void DealDamage(IDamagable target)) { }

        /// <summary>
        /// Sets velocity in the direction of the player
        /// </summary>
        /// <param name="target"></param>
        public void Pathfind(GameObject target)
        {
            //determines difference between enemy position and target position
            int distanceX = this.X - target.X;

            //Determines whether target is to the left or the right of the enemy
            if (distanceX < 0)//target is to the left of enemy
            {
                velocity = new Vector2(-1, 0);
            }
            else if (distanceX > 0)//target is to the right of enemy
            {
                velocity = new Vector2(1, 0);
            }
        }

        public void Move()
        {
            rect.X
        }
        //I'm not sure that we know what these methods do yet
        //so I am just including the list we had in the 
        //diagram.
        //Move at player, Target player, General ai functions, Attack player
    }
}
