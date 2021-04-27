using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    public delegate void enemyDelegate(Enemy sender);
    /// <summary>
    /// generic enemy class, handles movement, dealing damage, and death.
    /// Coded by Machi
    /// </summary>
    public class Enemy : Character, IDamages
    {
        //Fields
        protected int attackPower;
        protected float knockbackDistance;
        protected int money;
        private List<object> stats;
        public event enemyDelegate enemyDeath;

        protected bool leftFacing;
        //Enemy Stats will be included as Fields

        //Properties
        public int Money
        {
            get { return money; }
        }
        //Constructor
        public Enemy(Texture2D texture, Rectangle rect, List<Rectangle> collisionBoxes, bool active, 
            int maxHealth, Vector2 velocity, int attackPower, float knockbackDistance, int money)
            : base(texture,rect,collisionBoxes,active,maxHealth,velocity)
        {
            this.attackPower = attackPower;
            this.knockbackDistance = knockbackDistance;
            this.money = money;
            this.leftFacing = true;

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
            stats.Add(money);
        }

        public Enemy(Texture2D texture, Rectangle rect, bool active, 
            int maxHealth, Vector2 velocity, int attackPower, 
            float knockbackDistance, int money) 
            : this(texture, rect, new List<Rectangle> { rect }, active, maxHealth,
                  velocity, attackPower, knockbackDistance, money) { }

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
                if (X + rect.Width / 2 > victim.X + victim.Rect.Width / 2)
                {
                    target.TakeDamage(attackPower, -1 * knockbackDistance, this);
                }
                else
                {
                    target.TakeDamage(attackPower, knockbackDistance, this);
                }
            }
        }
        /// <summary>
        /// Updates enemy position and deals damage if enemy is not dead
        /// </summary>
        public override void Update()
        {
            //foreach gameobject in Game1.MapManager.Map
            //ground/gameobject collision
            Move();
            DealDamage(Game1.player);
            base.Update();
        }

        //accessors

        public int AttackPower
        {
            get { return attackPower; }
        }


        /// <summary>
        /// Sets enemy direction and moves
        /// </summary>
        public override void Move()
        {
            this.ApplyGravity();
            base.Move();
            ResolveCollisions();
        }

        public virtual void ApplyGravity()
        {
            velocity += new Vector2(0, 1);//apply gravity
        }

        public override void TakeDamage(int damage, float knockback, GameObject damageDealer)
        {
            base.TakeDamage(damage, knockback, damageDealer);
            if (health == 0 && enemyDeath != null)
            {
                enemyDeath(this);
            }
        }

        public void ResolveCollisions()
        {
            foreach (GameObject ground in Game1.mapManager.CurrentMap.MapArray)
            {
                Rectangle enemyPosition = new Rectangle((int)position.X, (int)position.Y, rect.Width, rect.Height);
                //wider = left
                if (enemyPosition.Intersects(ground.Rect))
                {
                    Rectangle intersection = Rectangle.Intersect(enemyPosition, ground.Rect);
                    if (intersection.Width <= intersection.Height)
                    {
                        if (enemyPosition.X <= ground.X)
                        {
                            enemyPosition.X -= intersection.Width;
                        }
                        else
                        {
                            enemyPosition.X += intersection.Width;
                        }
                    }
                    else
                    {
                        velocity.Y = 0;
                        if (enemyPosition.Y <= ground.Y)
                        {
                            enemyPosition.Y -= intersection.Height;
                        }
                        else
                        {
                            enemyPosition.Y += intersection.Height;
                        }
                    }
                }
                position.X = enemyPosition.X;
                position.Y = enemyPosition.Y;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch, !leftFacing);
        }
    }
}
