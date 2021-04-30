using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    class SpawnerProjectile : Projectile
    {
        Type type;
        public SpawnerProjectile(Texture2D texture, Rectangle transform, bool active,
            bool interceptable, int damage, float knockback, double lifeSpan,
            Vector2 velocity, int speed, bool fromEnemy, double homing, bool bounce,
            Gun gunOfOrigin, Type enemyType) 
            : base (texture, transform, active, interceptable, damage, knockback, lifeSpan, 
                    velocity, speed, fromEnemy, homing, bounce, gunOfOrigin)
        {
            type = enemyType;
        }

        public override void Destroy()
        {
            this.position.Y -= 25;
            this.position.X -= 20;
            if (type == typeof(ChaserEnemy))
            {
                Program.game.enemyManager.Spawn<ChaserEnemy>(this.position);
                base.Destroy();
                return;
            }
            if (type == typeof(RangedEnemy))
            {
                Program.game.enemyManager.Spawn<RangedEnemy>(this.position);
                base.Destroy();
                return;
            }
            if (type == typeof(PlatformEnemy))
            {
                Program.game.enemyManager.Spawn<PlatformEnemy>(this.position);
                base.Destroy();
                return;
            }
            if (type == typeof(FlyingEnemy))
            {
                Program.game.enemyManager.Spawn<FlyingEnemy>(this.position);
                base.Destroy();
                return;
            }

        }
    }
}
