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
        private int enemyAmt;


        //constructor -----------------------------------------------------------------------------

        public EnemyManager(List<List<object>> e)
        {
            //takes in number of enemies and a list of their stats
            enemies = e;
            enemyAmt = enemies.Count;

        }

        //accessors------------------------------------------------------------
        public List<List<object>> Enemies
        {
            //probably wont need a set. may need indexed accessor
            get { return enemies; }
            set { enemies = value; }
        }

        public int EnemyAmt
        {
            get { return enemyAmt; }
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

        public void UpdateEnemies()
        {
            //update logic for Enemy objects stored in "enemies"
            foreach(Enemy e in spawnedEnemies)
            {
                if (e.Health <= 0)
                {
                    spawnedEnemies.Remove(e);
                    enemyAmt--;
                }

                e.Update();
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
