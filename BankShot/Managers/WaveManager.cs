using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    /// <summary>
    /// Author: Noah Emke<br/>
    /// Manages wave advancement, pausing, count, and shop spawning.
    /// </summary>
    public class WaveManager
    {
        private Random rng;
        private int wave;
        private double timer;
        private List<List<string>> waves;
        private bool waveBreak;
        private double timeBetweenWaves;
        private double timePassed;

        /// <summary>
        /// Gets the current wave number.
        /// </summary>
        public int Wave { get { return wave; } }

        public double Timer { get { return timer; } }

        /// <summary>
        /// Gets weather or not the wave cycle is currently broken.
        /// </summary>
        public bool WaveBreak
        {
            get { return waveBreak; }
            set { waveBreak = value; }
        }
        public double TimePassed
        {
            get
            {
                return timePassed;
            }
            set
            {
                timePassed = value;
                if (timePassed > 10)
                {
                    timePassed = 10;
                }
            }
        }

        /// <summary>
        /// Initialize a new wave manager and read a list of waves from a file.
        /// </summary>
        public WaveManager()
        {
            rng = new Random();
            wave = 0;
            timer = 0;
            // TODO: Read from file
            waves = new List<List<string>>
            {
                new List<string>
                {
                    "Chaser|400|480",
                    "Chaser|840|150",
                    "Platform|970|470",
                    "Chaser|1180|480",
                    "Ranged|810|200",
                    "Flying|810|150",
                    "Platform|400|680"
                }
            };
            waveBreak = false;
            timeBetweenWaves = 2;
            //This can be changed to change the amount of time before the first wave.
            timePassed = 10;
        }

        /// <summary>
        /// Performs all actions and checks that should occur every frame.
        /// </summary>
        /// <param name="time">The gametime object for this game.</param>
        public void Update(GameTime time)
        {


            // Check if the wave has been cleared or the time has run out
            if ((Program.game.enemyManager.SpawnedEnemies.Count == 0) || (timer > 30))
            {
                if (waveBreak && (Game1.upgradeManager.Shops.Count == 0))
                {
                    Game1.player.Heal(Game1.player.MaxHealth / 5);
                    Game1.upgradeManager.MakeShop();
                }
                if (!waveBreak)
                {
                    if (timePassed < 0)
                    {
                        timePassed = 0;
                    }
                    timePassed += time.ElapsedGameTime.TotalSeconds;
                    Game1.player.Heal(Game1.player.MaxHealth / 10);
                    if (timePassed > timeBetweenWaves)
                    {
                        NextWave();
                        timePassed = -1;
                    }
                }
            }

            if (!(Program.game.enemyManager.SpawnedEnemies.Count == 0))
            {
                timer += time.ElapsedGameTime.TotalSeconds;
            }
        }

        /// <summary>
        /// Advances the wave number and spawns a new wave.
        /// </summary>
        public void NextWave()
        {
            wave++;
            timer = 0;
            int waveToSpawn = rng.Next(0, waves.Count);

            for (int i = 0; i < waves[waveToSpawn].Count; i++)
            {
                string[] splitEntry = waves[waveToSpawn][i].Split('|');
                switch (splitEntry[0])
                {
                    case "Enemy":
                        Program.game.enemyManager.Spawn<Enemy>(
                        new Vector2(
                            float.Parse(splitEntry[1]),
                            float.Parse(splitEntry[2])));
                        break;

                    case "Chaser":
                        Program.game.enemyManager.Spawn<ChaserEnemy>(
                        new Vector2(
                            float.Parse(splitEntry[1]),
                            float.Parse(splitEntry[2])));
                        break;

                    case "Ranged":
                        Program.game.enemyManager.Spawn<RangedEnemy>(
                        new Vector2(
                            float.Parse(splitEntry[1]),
                            float.Parse(splitEntry[2])));
                        break;

                    case "Flying":
                        Program.game.enemyManager.Spawn<FlyingEnemy>(
                        new Vector2(
                            float.Parse(splitEntry[1]),
                            float.Parse(splitEntry[2])));
                        break;
                    case "Platform":
                        Program.game.enemyManager.Spawn<PlatformEnemy>(
                        new Vector2(
                            float.Parse(splitEntry[1]),
                            float.Parse(splitEntry[2])));
                        break;
                }
            }

            if (wave % 3 == 0)
            {
                waveBreak = true;
            }
        }
    }
}
