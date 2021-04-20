using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot {
    public class ProjectileManager
    {
        public List<Projectile> projectiles;
        public int height;
        public int width;

        public ProjectileManager()
        {
            projectiles = new List<Projectile>();
        }

        public void checkCollisions()
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                bool destroyed = false;
                //Checking this projectile against every projectile after it in the list.
                for (int j = i + 1; j < projectiles.Count; j++ )
                {
                    if (projectiles[i].gunOfOrigin != projectiles[j].gunOfOrigin)
                    {
                        if (projectiles[i].Rect.Intersects(projectiles[j].Rect))
                        {
                            if (projectiles[i].interceptable == true)
                            {
                                projectiles[i].Destroy();
                                i--;
                                destroyed = true;
                                break;
                            }

                            if (projectiles[j].interceptable == true)
                            {
                                projectiles[j].Destroy();
                            }
                        }
                    }
                }
                if (!destroyed)
                {
                    //Checking this projectile against the Player if it's from an Enemy.
                    if (projectiles[i].fromEnemy == true)
                    {
                        if (projectiles[i].Rect.Intersects(Game1.player.Rect))
                        {
                            projectiles[i].DealDamage((IDamageable)Game1.player);
                            projectiles[i].Destroy();
                            i--;
                            destroyed = true;
                        }
                    }
                    //Checking this projectile against enemies if it's from the Player.
                    else
                    {
                        foreach (Enemy enemy in Program.game.enemyManager.SpawnedEnemies)
                        {
                            if (projectiles[i].Rect.Intersects(enemy.Rect))
                            {
                                projectiles[i].DealDamage((IDamageable)enemy);
                                projectiles[i].Destroy();
                                i--;
                                destroyed = true;
                                break;
                            }
                        }
                    }
                    //Checking this projectile against walls.
                    if (!destroyed && !projectiles[i].fromEnemy)
                    {
                        foreach (GameObject wall in Game1.mapManager.CurrentMap.MapArray)
                        {

                            if (i < projectiles.Count)
                            {
                                if (projectiles[i].Rect.Intersects(wall.Rect))
                                {
                                    projectiles[i].Destroy();
                                }
                            }
                        }
                    }
                }
            }
        }

        public void UpdateProjectiles(GameTime gameTime)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Update(gameTime);
                //projectiles[i].ElapseTime += (double) (gameTime.TotalGameTime.TotalSeconds);
            }
            this.checkCollisions();
        }

        public void DrawProjectiles(SpriteBatch sb)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(sb);
            }
        }
    }
}
