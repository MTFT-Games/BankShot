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

        /// <summary>
        /// Gets the current wave number.
        /// </summary>
        public int Wave { get { return wave; } }

        /// <summary>
        /// Gets weather or not the wave cycle is currently broken.
        /// </summary>
        public bool WaveBreak
        {
            get { return waveBreak; }
            set { waveBreak = value; }
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
                    "Enemy|400|480",
                    "Enemy|840|150",
                    "Enemy|970|470",
                    "Enemy|1180|480"
                }
            };
            waveBreak = false;
        }

        /// <summary>
        /// Performs all actions and checks that should occur every frame.
        /// </summary>
        /// <param name="time">The gametime object for this game.</param>
        public void Update(GameTime time)
        {
            // Check if the wave has been cleared or the time has run out
            if ((Game1.enemyManager.SpawnedEnemies.Count == 0) || (timer > 30))
            {
                if (waveBreak && (Game1.upgradeManager.Shops.Count == 0))
                {
                    Game1.upgradeManager.MakeShop();
                }

                if (!waveBreak)
                {
                NextWave();
                }
            }

            timer += time.ElapsedGameTime.TotalSeconds;
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
                Game1.enemyManager.Spawn<Enemy>(
                    new Vector2(
                        float.Parse(splitEntry[1]), 
                        float.Parse(splitEntry[2])));
            }

            if (wave % 3 == 0)
            {
                waveBreak = true;
            }
        }
    }
}
