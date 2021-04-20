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
        public RangedEnemy(Texture2D texture, Rectangle rect, List<Rectangle> collisionBoxes, bool active,
            int maxHealth, Vector2 velocity, int attackPower, float knockbackDistance, Gun gun, double reloadTime)
            : base(texture, rect, collisionBoxes, active, maxHealth, velocity, attackPower, knockbackDistance)
        {
            this.gun = gun;
            this.reloadTime = reloadTime;
            this.elapsedTime = 0;
        }

        public void Update(GameTime gameTime)
        {
            base.Update();
            this.Attack(gameTime);
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Attack(GameTime gameTime)
        {
            if (elapsedTime >= reloadTime && 
               (int)Math.Sqrt(Math.Pow(this.X - Game1.player.X, 2) + 
               Math.Pow(this.Y - Game1.player.Y, 2)) <= 20)
            {
                gun.Attack(Game1.player.Position - this.position);
                elapsedTime = 0;
            }
        }
    }
}
