using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    public delegate void enemyMethods(Enemy sender);
    /// <summary>
    /// generic enemy class, handles movement, dealing damage, and death.
    /// Coded by Machi
    /// </summary>
    public class Enemy : Character, IDamages
    {
        //Fields
        protected int attackPower;
        protected float knockbackDistance;
        private List<object> stats;
        public event enemyMethods enemyDeath;
        //Enemy Stats will be included as Fields

        //Constructor
        public Enemy(Texture2D texture, Rectangle rect, List<Rectangle> collisionBoxes, bool active, 
            int maxHealth, Vector2 velocity, int attackPower, float knockbackDistance)
            : base(texture,rect,collisionBoxes,active,maxHealth,velocity)
        {
            this.attackPower = attackPower;
            this.knockbackDistance = knockbackDistance;

            //adds stats to a list for manager
            //stats format: texture, rectangle, boxes(list rectangle),
            //active(bool), maxhp(int), velocity (vector2), atk power (int),
            //knock distance (float)
            stats = new List<object>();
            stats.Add(texture);
            stats.Add(rect);
            stats.Add(collisionBoxes);
            stats.Add(active);
            stats.Add(maxHealth);
            stats.Add(velocity);
            stats.Add(attackPower);
            stats.Add(knockbackDistance);
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
                //enemyDeath(this);
                return;
            }
            //foreach gameobject in Game1.MapManager.Map
            //ground/gameobject collision
            //If player downcast and deal damage
            //else take care of collision
            Move();
            //DealDamage(Game1.player);
        }

        //accessors

        public int AttackPower
        {
            get { return attackPower; }
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
        /// Sets enemy direction and moves
        /// </summary>
        public override void Move()
        {
            //Pathfind(Game1.player);
            base.Move();
        }

        /*public override void CollisionCheck()
        {
            
        }*/
    }
}
