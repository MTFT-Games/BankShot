using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    class SpawnerGun : Gun
    {
        Type enemyType;
        public SpawnerGun(bool visible, Rectangle transform,
                      List<Rectangle> collisionBoxes, bool active,
                      int damage, int knockback, bool interceptable,
                      double lifeSpan, int speed, Vector2 velocity,
                      Texture2D projectileTexture,Rectangle projectileTransform,
                      List<Rectangle> projectileCollisionBoxes,
                      double projectileHoming, bool projectileBounce,
                      bool projectileActive, bool fromEnemy, Type enemyType)
                      : base(visible, transform, collisionBoxes, active,
                            damage, knockback, interceptable, lifeSpan, 
                            speed, velocity, projectileTexture, projectileTransform, 
                            projectileCollisionBoxes, projectileHoming, 
                            projectileBounce, projectileActive, fromEnemy)
        {
            this.enemyType = enemyType;
        }
        public override void Attack()
        {
            Vector2 direction = Input.MousePosition - position;
            direction.Normalize();
            projectileTransform.X = X;
            projectileTransform.Y = Y;
            Game1.projectileManager.projectiles.Add(new SpawnerProjectile(projectileTexture,
                                           projectileTransform,
                                           projectileActive, interceptable,
                                           (int)(damage * Game1.player.DamageMods[0] + Game1.player.DamageMods[1]),
                                           Knockback, lifeSpan,
                                           direction * (int)(speed * Game1.player.ProjectileSpeedMods[0] + Game1.player.ProjectileSpeedMods[1]),
                                           (int)(speed * Game1.player.ProjectileSpeedMods[0] + Game1.player.ProjectileSpeedMods[1]), fromEnemy,
                                           projectileHoming * Game1.player.ProjectileHoming, projectileBounce,
                                           this, enemyType));
        }

        public override void Attack(Vector2 direction)
        {
            direction.Normalize();
            projectileTransform.X = X;
            projectileTransform.Y = Y;
            Game1.projectileManager.projectiles.Add(new SpawnerProjectile(projectileTexture,
                                           projectileTransform,
                                           projectileActive, interceptable,
                                           damage, Knockback, lifeSpan,
                                           direction * (int)speed, (int)speed, fromEnemy,
                                           projectileHoming, projectileBounce,
                                           this, enemyType));
        }
    }
}
