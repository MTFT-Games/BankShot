using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    public class EnemyManager
    {
        //fields

        //list of stats of each enemy. 
        //stats format: texture, rectangle, boxes(list rectangle),
        //active(bool), maxhp(int), velocity (vector2), atk power (int),
        //knock distance (float)
        private List<List<object>> enemies;
        private List<Enemy> spawnedEnemies;

        //constructor -----------------------------------------------------------------------------

        public EnemyManager(List<List<object>> e)
        {
            //takes in number of enemies and a list of their stats
            enemies = e;
            spawnedEnemies = new List<Enemy>();
        }

        //accessors------------------------------------------------------------
        public List<List<object>> Enemies
        {
            //probably wont need a set. may need indexed accessor
            get { return enemies; }
            set { enemies = value; }
        }

        public List<Enemy> SpawnedEnemies
        {
            //probably wont need a set. may need indexed accessor
            get { return spawnedEnemies; }
            set { spawnedEnemies = value; }
        }

        //methods--------------------------------------------------------------

        /// <summary>
        /// goes through stats lists and creates an enemy object from each one
        /// </summary>
        public void SpawnEnemies()
        {
           
           foreach(List<object> stats in enemies)
            {
                //stats format: texture, rectangle, boxes(list rectangle),
                //active(bool), maxhp(int), velocity (vector2), atk power (int),
                //knock distance (float)

                Enemy e = new Enemy((Texture2D) stats[0],
                    (Rectangle) stats[1],
                    (List<Rectangle>) stats[2],
                    (bool) stats[3],
                    (int) stats[4], 
                    (Vector2) stats[5],
                    (int) stats[6], 
                    (float) stats[7]);

                spawnedEnemies.Add(e);
            }
        }

        /// <summary>
        /// Spawns a new enemy of the given type with the stats of the stored 
        /// template scaled to the current wave.
        /// </summary>
        /// <typeparam name="enemyType">The type of enemy to spawn.</typeparam>
        public void Spawn<enemyType>(Vector2  position) where enemyType : Enemy
        {
            // TODO: Setup for multiple enemy types when we make them.
            // TODO: Setup with new stats template when we get to that.
            // TODO: Implement scaling.
            spawnedEnemies.Add(new Enemy(
                (Texture2D)enemies[0][0],
                new Rectangle((int)position.X, (int)position.Y, 100, 100),
                (bool)enemies[0][3],
                (int)enemies[0][4],
                (Vector2)enemies[0][5],
                (int)enemies[0][6],
                (float)enemies[0][7]));
        }

        public void UpdateEnemies()
        {
            //update logic for Enemy objects stored in "enemies"
            for(int i = 0; i < spawnedEnemies.Count; i++)
            {
                if (spawnedEnemies[i].Health <= 0)
                {
                    spawnedEnemies.RemoveAt(i);
                    i--;
                    continue;
                }

                spawnedEnemies[i].Update();
            }
        }

        public void DrawEnemies(SpriteBatch sb)
        {
            //Draws the enemy objects in "enemies" using the given spritebatch
            foreach(Enemy e in spawnedEnemies)
            {
                e.Draw(sb);
            }

        }

        public string ReadStats(int index)
        {
            //returns a string with information on each enemy's stats
            return $"HP: {spawnedEnemies[index].Health}\n" +
                $"Attack Power: {spawnedEnemies[index].AttackPower}\n";


        }

    }
}
