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
                            }

                            if (projectiles[j].interceptable == true)
                            {
                                projectiles[j].Destroy();
                            }
                        }
                    }
                }
                //Checking this projectile against the Player if it's from an Enemy.
                if (projectiles[i].fromEnemy == true)
                {
                    if (projectiles[i].Rect.Intersects(Game1.player.Rect))
                    {
                        projectiles[i].DealDamage((IDamageable)Game1.player);
                        projectiles[i].Destroy();
                    }
                }
                //Checking this projectile against enemies if it's from the Player.
                else
                {
                    foreach (Enemy enemy in Game1.enemyManager.SpawnedEnemies)
                    {
                        if (projectiles[i].Rect.Intersects(enemy.Rect))
                        {
                            projectiles[i].DealDamage((IDamageable)enemy);
                            projectiles[i].Destroy();
                        }
                    }
                }
                //Checking this projectile against walls.
                foreach (GameObject wall in Game1.walls)
                {
                    if (i < projectiles.Count && projectiles[i].Rect.Intersects(wall.Rect))
                    {
                        if (projectiles[i].bounce)
                        {
                            Rectangle prediction = new Rectangle(projectiles[i].Rect.X + (int) projectiles[i].velocity.X, 
                                projectiles[i].Rect.Y + (int)projectiles[i].velocity.Y, projectiles[i].Rect.Width, 
                                projectiles[i].Rect.Height);
                            if (prediction.Intersects(wall.Rect))
                            {
                                Rectangle intersection = Rectangle.Intersect(prediction, wall.Rect);
                                height = intersection.Height;
                                width = intersection.Width;
                                if (intersection.Width <= intersection.Height)
                                {
                                    if (prediction.X <= wall.X)
                                    {
                                        prediction.X -= intersection.Width;
                                    }
                                    else
                                    {
                                        prediction.X += intersection.Width;
                                    }
                                    projectiles[i].velocity.X *= -1;
                                    if (intersection.Width == intersection.Height)
                                    {
                                        //projectiles[i].velocity.Y *= -1;
                                    }
                                }
                                else
                                {
                                    if (prediction.Y <= wall.Y)
                                    {
                                        prediction.Y -= intersection.Height;
                                    }
                                    else
                                    {
                                        prediction.Y += intersection.Height;
                                    }
                                    projectiles[i].velocity.Y *= -1;
                                }
                                projectiles[i].Rect = prediction;
                            }
                        }
                        else
                        {
                            projectiles[i].Destroy();
                        }
                    }
                }
            }
        }

        public void UpdateProjectiles()
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Update();
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
