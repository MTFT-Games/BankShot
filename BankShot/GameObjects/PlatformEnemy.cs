using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    class PlatformEnemy : Enemy
    {
        private int speed;
        private Rectangle platformEdgeFinder;
        private Rectangle wallFinder;
        public PlatformEnemy(Texture2D texture, Rectangle rect, bool active,
            int maxHealth, Vector2 velocity, int attackPower,
            float knockbackDistance, int money, int speed) 
            : base(texture, rect, active, maxHealth, 
                   velocity, attackPower, knockbackDistance, money)
        {
            this.speed = speed;
            platformEdgeFinder = new Rectangle(X + speed, Y, rect.Width, rect.Height);
            wallFinder = new Rectangle(X, Y, rect.Width, rect.Height);
        }

        public override void Update()
        {
            base.Update();
            TurnAround();
        }
        public void TurnAround()
        {
            if (leftFacing)
            {
                platformEdgeFinder.X = X - speed * 35;
                wallFinder.X = X - speed * 35;
            }
            else
            {
                platformEdgeFinder.X = X + speed * 35;
                wallFinder.X = X + speed * 35;
            }
            platformEdgeFinder.Y = Y + 20;
            wallFinder.Y = Y - 5;
            bool checkForPlatform = false;
            bool checkForWall = false;
            foreach (GameObject wall in Game1.mapManager.CurrentMap.MapArray)
            {
                if (wall.Rect.Intersects(platformEdgeFinder))
                {
                    checkForPlatform = true;
                }
                if (wall.Rect.Intersects(wallFinder))
                {
                    checkForWall = true;
                }
            }
            if (!checkForPlatform || checkForWall)
            {
                leftFacing = !leftFacing;
            }
        }
        public override void Move()
        {
            if (leftFacing)
            {
                velocity.X = speed * -1;
            }
            else
            {
                velocity.X = speed;
            }
            ApplyGravity();
            ResolveCollisions();
            ApplyKnockBack();
            position += velocity;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!leftFacing)
            {
                spriteBatch.Draw(texture, rect, null, Color.Green, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 1);
            }
            else
            {
                spriteBatch.Draw(texture, rect, Color.Green);
            }
        }
    }
}
