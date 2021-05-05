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
        private List<Enemy> enemies;
        private List<Enemy> spawnedEnemies;

        //constructor -----------------------------------------------------------------------------

        public EnemyManager()
        {
            //takes in number of enemies and a list of their stats
            enemies = new List<Enemy>();
            spawnedEnemies = new List<Enemy>();

            //Registering Chaser Enemy
            enemies.Add(new ChaserEnemy(
                Program.game.enemyTextureSlime,
                new Rectangle(0, 0, 100, 100), //enemy rectangle
                true, //enemy active state
                5, //enemy health
                new Vector2(0, 0), //enemy velocity
                5, //enemy attack power
                15f, //Enemy knockback distance
                250,//Enemy's money value
                2));
            

            //Registering Ranged Enemy
            enemies.Add(new RangedEnemy(
                Program.game.enemyTextureCat,
                new Rectangle(0, 0, 80, 120), //enemy rectangle
                new List<Rectangle>(), //enemy hitboxes
                true, //enemy active state
                5, //enemy health
                new Vector2(0, 0), //enemy velocity
                5, //enemy attack power
                15f, //Enemy knockback distance
                250,//Enemy's money value
                new Gun(false,
                    new Rectangle(100, 100, 1, 1), new List<Rectangle>(), true, 6, 10,
                    true, 1.4, 13, new Vector2(0, 0),
                    Program.game.Content.Load<Texture2D>("CoinBullet"),
                    new Rectangle(400, 100, 20, 20),
                    new List<Rectangle>(), 0, false, true, true),
                2,
                800));

            //Registering Platform Enemy
            enemies.Add(new PlatformEnemy(
                Program.game.enemyTextureSlime,
                new Rectangle(0, 0, 100, 100), //enemy rectangle
                true, //enemy active state
                5, //enemy health
                new Vector2(0, 0), //enemy velocity
                5, //enemy attack power
                15f, //Enemy knockback distance
                250,//Enemy's money value
                2));

            //Registering Flying enemy
            enemies.Add(new FlyingEnemy(
                Program.game.enemyTextureChest,
                new Rectangle(0, 0, 100, 100), //enemy rectangle
                new List<Rectangle>(), //enemy hitboxes
                true, //enemy active state
                5, //enemy health
                new Vector2(0, 0), //enemy velocity
                5, //enemy attack power
                15f, //Enemy knockback distance
                250,//Enemy's money value
                2,
                new SpawnerGun(false,
                        new Rectangle(100, 100, 1, 1), new List<Rectangle>(), true, 6, 10,
                        true, 1.4, 13, new Vector2(0, 0),
                        Program.game.Content.Load<Texture2D>("CoinBullet"), new Rectangle(400, 100, 20, 20),
                        new List<Rectangle>(), 0, false, true, true, typeof(ChaserEnemy)),
                2));

            //Registering Basic Enemy
            enemies.Add(new Enemy(
                Program.game.enemyTextureSlime,
                new Rectangle(0, 0, 100, 100), //enemy rectangle
                new List<Rectangle>(), //enemy hitboxes
                true, //enemy active state
                5, //enemy health
                new Vector2(0, 0), //enemy velocity
                5, //enemy attack power
                15f, //Enemy knockback distance
                250//Enemy's money value
            ));
        }

        //accessors------------------------------------------------------------
        public List<Enemy> Enemies
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

            foreach (Enemy stats in enemies)
            {
                Enemy copy = new Enemy(stats, new Vector2(0,0));

                spawnedEnemies.Add(copy);
            }
        }

        /// <summary>
        /// Spawns a new enemy of the given type with the stats of the stored 
        /// template scaled to the current wave.
        /// </summary>
        /// <typeparam name="enemyType">The type of enemy to spawn.</typeparam>
        public void Spawn<enemyType>(Vector2 position) where enemyType : Enemy
        {
            // TODO: Setup for multiple enemy types when we make them.
            // TODO: Setup with new stats template when we get to that.
            // TODO: Implement scaling.
            Type type = typeof(enemyType);
            Enemy enemy;
            if  (type == typeof(ChaserEnemy))
            {
                enemy = new ChaserEnemy((ChaserEnemy)enemies[0], position);
                enemy.AttackPower += (Game1.waveManager.Wave - 1) * 3;
                enemy.MaxHealth += (Game1.waveManager.Wave - 1) * 3;
                ((ChaserEnemy)enemy).Speed += (Game1.waveManager.Wave - 1) / 5;
                if (((ChaserEnemy)enemy).Speed > 10)
                {
                    ((ChaserEnemy)enemy).Speed = 10;
                }
                enemy.Health = enemy.MaxHealth;
                spawnedEnemies.Add((ChaserEnemy)enemy);
            }
            if (type == typeof(RangedEnemy))
            {
                enemy = new RangedEnemy((RangedEnemy)enemies[1], position);
                enemy.AttackPower += (Game1.waveManager.Wave - 1) * 3;
                enemy.MaxHealth += (Game1.waveManager.Wave - 1) * 3;
                enemy.Health = enemy.MaxHealth;
                spawnedEnemies.Add((RangedEnemy)enemy);
            }
            if (type == typeof(PlatformEnemy))
            {
                enemy = new PlatformEnemy((PlatformEnemy)enemies[2], position);
                enemy.AttackPower += (Game1.waveManager.Wave - 1) * 3;
                enemy.MaxHealth += (Game1.waveManager.Wave - 1) * 3;
                enemy.Health = enemy.MaxHealth;
                spawnedEnemies.Add((PlatformEnemy)enemy);
            }
            if (type == typeof(FlyingEnemy))
            {
                enemy = new FlyingEnemy((FlyingEnemy)enemies[3], position);
                enemy.AttackPower += (Game1.waveManager.Wave - 1) * 3;
                enemy.MaxHealth += (Game1.waveManager.Wave - 1) * 3;
                enemy.Health = enemy.MaxHealth;
                spawnedEnemies.Add((FlyingEnemy)enemy);
            }
        }


        public void UpdateEnemies(GameTime time)
        {
            //update logic for Enemy objects stored in "enemies"
            for (int i = 0; i < spawnedEnemies.Count; i++)
            {
                if (spawnedEnemies[i].Health <= 0)
                {
                    Game1.player.Money += spawnedEnemies[i].Money;
                    Program.game.score += spawnedEnemies[i].Money;
                    spawnedEnemies.RemoveAt(i);
                    i--;
                    continue;
                }

                if (spawnedEnemies[i] is ChaserEnemy)
                {
                    ((ChaserEnemy)spawnedEnemies[i]).Update();
                }
                else if (spawnedEnemies[i] is RangedEnemy)
                {
                    ((RangedEnemy)spawnedEnemies[i]).Update(time);
                }
                else if (spawnedEnemies[i] is PlatformEnemy)
                {
                    ((PlatformEnemy)spawnedEnemies[i]).Update();
                }
                else if (spawnedEnemies[i] is FlyingEnemy)
                {
                    ((FlyingEnemy)spawnedEnemies[i]).Update(time);
                }
                else
                {
                    spawnedEnemies[i].Update();
                }
            }
        }

        public void DrawEnemies(SpriteBatch sb)
        {
            //Draws the enemy objects in "enemies" using the given spritebatch
            foreach (Enemy e in spawnedEnemies)
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
