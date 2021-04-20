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
                return;
            }
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
        /// Sets velocity in the direction of the player
        /// <param name="target"></param>
        public void Pathfind(GameObject target)
        {
            //determines difference between enemy Xposition and target Xposition
            int distanceX = this.X - target.X;

            //Determines whether target is to the left or the right of the enemy
            if (distanceX < -5)//target is to the left of enemy
            {
                velocity.X = 1;
                this.leftFacing = false;
            }
            else if (distanceX > 5)//target is to the right of enemy
            {
                velocity.X = -1;
                this.leftFacing = true;
            }
            else 
            {
                X = Game1.player.X;
                velocity.X = 0;
            }
        }
        /// <summary>
        /// Sets enemy direction and moves
        /// </summary>
        public override void Move()
        {
            velocity += new Vector2(0, 1);//apply gravity
            base.Move();
            ResolveCollisions();
            Pathfind(Game1.player);//find player
        }

        public override void TakeDamage(int damage, float knockback)
        {
            base.TakeDamage(damage, knockback);
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
                    Rectangle collisionRect = Rectangle.Intersect(rect, ground.Rect);
                    if (collisionRect.Width >= collisionRect.Height)//vertical collision
                    {
                        velocity.Y = 0;
                        if (enemyPosition.Y <= ground.Y)
                        {
                            enemyPosition.Y -= collisionRect.Height;                            
                        }
                        else
                        {
                            enemyPosition.Y += collisionRect.Height;
                        }
                    }
                    else if (collisionRect.Height >= collisionRect.Width)//horizontal collision
                    {
                        if (enemyPosition.X <= ground.X)
                        {
                            enemyPosition.X -= collisionRect.Width;
                        }
                        else
                        {
                            enemyPosition.X += collisionRect.Width;
                        }
                    }
                    //sync enemyposition with new proposed position
                    position.X = enemyPosition.X;
                    position.Y = enemyPosition.Y;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch, !leftFacing);
        }
    }
}
