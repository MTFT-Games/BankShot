using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    delegate void enemyMethods(Enemy sender);
    /// <summary>
    /// generic enemy class, handles movement, dealing damage, and death
    /// </summary>
    class Enemy : Character, IDamages
    {
        //Fields
        protected int attackPower;
        protected int knockbackDistance;
        public event enemyMethods enemyDeath;
        //Enemy Stats will be included as Fields

        //Constructor
        public Enemy(Texture2D texture, Rectangle rect, List<Rectangle> collisionBoxes, bool active, int maxHealth, Vector2 velocity, int attackPower, int knockbackDistance)
            : base(texture,rect,collisionBoxes,active,maxHealth,velocity)
        {
            this.attackPower = attackPower;
            this.knockbackDistance = knockbackDistance;
        }
        //Methods
        /// <summary>
        /// Damages a target the enemy makes contact with
        /// </summary>
        /// <param name="target"></param>
        public void DealDamage(IDamageable target)
        {
            GameObject victim = (GameObject)target;
            if (rect.Intersects(victim.Rect))
            {
                target.TakeDamage(attackPower,knockbackDistance);
            }
        }
        /// <summary>
        /// Updates enemy position and deals damage if enemy is not dead
        /// </summary>
        public override void Update()
        {
            if(health <= 0)
            {
                enemyDeath(this);
                return;
            }
            //foreach gameobject in Game1.MapManager.Map
            //ground/gameobject collision
            //If player downcast and deal damage
            //else take care of collision
            Move();
            //DealDamage(Game1.player);
        }

        /// <summary>
        /// Sets velocity in the direction of the player
        /// </summary>
        /// <param name="target"></param>
        public void Pathfind(GameObject target)
        {
            //determines difference between enemy Xposition and target Xposition
            int distanceX = this.X - target.X;

            //Determines whether target is to the left or the right of the enemy
            if (distanceX < 0)//target is to the left of enemy
            {
                velocity.X = -1;
            }
            else if (distanceX > 0)//target is to the right of enemy
            {
                velocity.X = -1;
            }
        }
        /// <summary>
        /// Sets enemy direction and fires
        /// </summary>
        public override void Move()
        {
            //Pathfind(Game1.player);
            base.Move();
        }
        
    }
}
